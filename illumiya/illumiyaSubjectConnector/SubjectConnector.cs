using AutoMapper;
using illumiyaEntities.Subjects.Requests;
using illumiyaEntities.Subjects.Responses;
using illumiyaFramework.Crypto;
using illumiyaFramework.Entities;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using illumiyaSubjectsRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaSubjectConnector
{
    public class SubjectConnector : ISubjectConnector
    {
        private IMapper _mapper;
        private readonly ISubjectsRepository _repository;

        public SubjectConnector(IMapper mapper, ISubjectsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Get Methods
        public async Task<GetSubjectsListResponse> GetAllAsync(GetSubjectsListResponse response)
        {
            try
            {
                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.GetSubjectsListResponse>();
                serviceResponse = await _repository.GetSubjectsListAsync(serviceResponse);
                if (serviceResponse.IsSuccess)
                {
                    response.SubjectList = serviceResponse.SubjectList;
                    response.Success("SubjectConnector > GetSubjectsListAsync");
                }
                else
                {
                    response.Failed("SubjectConnector > GetSubjectsListAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<GetSubjectDetailsResponse> GetAsync(GetSubjectDetailsRequest request, GetSubjectDetailsResponse response)
        {
            try
            {
                var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Subjects.Requests.GetSubjectDetailsRequest>(request);
                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.GetSubjectDetailsResponse>();
                serviceResponse = await _repository.GetAsync(serviceRequest, serviceResponse);
                if (serviceResponse.IsSuccess)
                {
                    response.SubjectDetails = serviceResponse.SubjectDetails;
                    response.Success("SubjectConnector > GetAsync");
                }
                else
                {
                    response.Failed("SubjectConnector > GetAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<GetSubjectsListByCountryResponse> GetSubjectsListByCountryAsync(GetSubjectsListByCountryRequest request, GetSubjectsListByCountryResponse response) {
            try
            {
                var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Subjects.Requests.GetSubjectsListByCountryRequest>(request);
                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.GetSubjectsListByCountryResponse>();
                serviceResponse = await _repository.GetSubjectListByCountryAsync(serviceRequest, serviceResponse);
                if (serviceResponse.IsSuccess)
                {
                    response.Subjects = serviceResponse.Subjects;
                    response.Success("SubjectConnector > GetSubjectsListByCountryAsync");
                }
                else
                {
                    response.Failed("SubjectConnector > GetSubjectsListByCountryAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }
        #endregion

        #region Curd
        public async Task<SaveSubjectDetailsResponse> PostAsync(SaveSubjectDetailsRequest request, SaveSubjectDetailsResponse response)
        {
            try
            {
                OwherToken owherToken;
                Crypto.DecryptOwherToken(request.Header.OwnerToken, out owherToken);

                var checkServiceRequest = new illumiyaConnectorEntities.Subjects.Requests.CheckSubjectExistsRequest()
                {
                    CountryId = request.SubjectDetails.CountryId,
                    Name = request.SubjectDetails.Name
                };
                var checkServiceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.CheckSubjectExistsResponse>();
                checkServiceResponse = await _repository.CheckExistsAsync(checkServiceRequest, checkServiceResponse);

                if (checkServiceResponse.IsSuccess && checkServiceResponse.SubjectId == 0)
                {
                    var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Subjects.Requests.SaveSubjectDetailsRequest>(request);
                    serviceRequest.SubjectDetails.CreatedBy = owherToken.UserId;

                    var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.SaveSubjectDetailsResponse>();
                    serviceResponse = await _repository.PostAsync(serviceRequest, serviceResponse);
                    if (serviceResponse.IsSuccess)
                    {
                        response.SubjectId = serviceResponse.SubjectId;
                        response.Success("SubjectConnector > PostAsync");
                    }
                    else
                    {
                        response.Failed("SubjectConnector > PostAsync");
                    }
                }
                else {
                    response.Failed("Subject already exists");
                }

                
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<UpdateSubjectDetailsResponse> PutAsync(UpdateSubjectDetailsRequest request, UpdateSubjectDetailsResponse response)
        {
            try
            {
                OwherToken owherToken;
                Crypto.DecryptOwherToken(request.Header.OwnerToken, out owherToken);

                var checkServiceRequest = new illumiyaConnectorEntities.Subjects.Requests.CheckSubjectExistsRequest()
                {
                    CountryId = request.SubjectDetails.CountryId,
                    Name = request.SubjectDetails.Name
                };
                var checkServiceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.CheckSubjectExistsResponse>();
                checkServiceResponse = await _repository.CheckExistsAsync(checkServiceRequest, checkServiceResponse);
                if (checkServiceResponse.IsSuccess) {
                    if (checkServiceResponse.SubjectId == 0 || checkServiceResponse.SubjectId == request.SubjectDetails.Id)
                    {
                        var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Subjects.Requests.UpdateSubjectDetailsRequest>(request);
                        serviceRequest.SubjectDetails.ModifiedBy = owherToken.UserId;

                        var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.UpdateSubjectDetailsResponse>();
                        serviceResponse = await _repository.PutAsync(serviceRequest, serviceResponse);
                        if (serviceResponse.IsSuccess)
                        {
                            response.IsUpdated = serviceResponse.IsUpdated;
                            response.Success("SubjectConnector > PostAsync");
                        }
                        else
                        {
                            response.Failed("SubjectConnector > PostAsync");
                        }
                    }
                    else {
                        response.Failed("Subject already exists");
                    }
                }

                
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request, DeleteSubjectResponse response)
        {
            try
            {
                var serviceRequest = _mapper.Map<illumiyaConnectorEntities.Subjects.Requests.DeleteSubjectRequest>(request);
                
                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Subjects.Responses.DeleteSubjectResponse>();
                serviceResponse = await _repository.DeleteAsync(serviceRequest, serviceResponse);
                if (serviceResponse.IsSuccess)
                {
                    response.IsDeleted = serviceResponse.IsDeleted;
                    response.Success("SubjectConnector > PostAsync");
                }
                else
                {
                    response.Failed("SubjectConnector > PostAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }
        #endregion
    }
}
