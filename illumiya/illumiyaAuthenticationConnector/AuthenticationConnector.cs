using AutoMapper;
using illumiyaAuthenticationRepository.Repository;
using illumiyaEntities.Authentication.Requests;
using illumiyaEntities.Authentication.Responses;
using illumiyaFramework.Crypto;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaAuthenticationConnector
{
    public class AuthenticationConnector : IAuthenticationConnector
    {
        private IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationConnector(IMapper mapper, IAuthenticationRepository authenticationRepository)
        {
            _mapper = mapper;
            _authenticationRepository = authenticationRepository;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, AuthenticationResponse response)
        {
            try
            {
                var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Authentication.Requests.AuthenticationRequest>(request);

                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Authentication.Responses.AuthenticationResponse>();

                serviceResponse = await _authenticationRepository.AuthenticateAsync(serviceResponse, serviceRequest);
                if (serviceResponse.IsSuccess)
                {
                    response.User = serviceResponse.User;
                    response.OwnerToken = Crypto.EncryptOwherToken(response.User.Id, response.User.Name);
                    response.Success("AuthenticationConnector > AuthenticateAsync");
                }
                else
                {
                    response.Failed("AuthenticationConnector > AuthenticateAsync > Invalid Credendials");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex);
            }
            return response;
        }
    }
}
