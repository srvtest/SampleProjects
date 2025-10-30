using illumiyaModels.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace illumiyaSubjectsRepository.Mappers
{
    public static class SubjectMapper
    {
        public static IEnumerable<Entities.Models.Subject> Map(this IEnumerable<Entities.DB.Subject> list)
        {
            return list.Select(i => i.MapToSubject());
        }

        public static Entities.Models.Subject MapToSubject(this Entities.DB.Subject item)
        {
            return new Entities.Models.Subject()
            {
                Id = item.Id,
                CountryId = item.CountryId,
                Name = item.Name,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedBy = item.CreatedBy,
                ModifiedBy = item.ModifiedBy,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn
            };
        }

        public static IEnumerable<Entities.Models.SubjectList> Map(this IEnumerable<Entities.DB.SubjectList> list)
        {
            return list.Select(i => i.MapToSubject());
        }

        public static Entities.Models.SubjectList MapToSubject(this Entities.DB.SubjectList item)
        {
            return new Entities.Models.SubjectList()
            {
                Id = item.Id,
                CountryId = item.CountryId,
                Name = item.Name,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedBy = item.CreatedBy,
                ModifiedBy = item.ModifiedBy,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn,
                CountryName = item.CountryName
            };
        }

        public static IEnumerable<Subject> Map(this IEnumerable<Entities.Models.Subject> list)
        {
            return list.Select(i => i.MapToSubject());
        }

        public static Subject MapToSubject(this Entities.Models.Subject item)
        {
            return new Subject()
            {
                Id = item.Id,
                CountryId = item.CountryId,
                Name = item.Name,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedBy = item.CreatedBy,
                ModifiedBy = item.ModifiedBy,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn
            };
        }

        public static IEnumerable<Subject> Map(this IEnumerable<Entities.Models.SubjectList> list)
        {
            return list.Select(i => i.MapToSubject());
        }

        public static Subject MapToSubject(this Entities.Models.SubjectList item)
        {
            return new Subject()
            {
                Id = item.Id,
                CountryId = item.CountryId,
                Name = item.Name,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedBy = item.CreatedBy,
                ModifiedBy = item.ModifiedBy,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn,
                Country = new illumiyaModels.Countries.Country() { 
                    Id = item.CountryId,
                    Name = item.CountryName
                }
            };
        }
    }
}
