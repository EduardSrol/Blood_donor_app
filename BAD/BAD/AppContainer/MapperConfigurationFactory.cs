using AutoMapper;
using BAD.DTO;
using BAD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.AppContainer
{
    public class MapperConfigurationFactory
    {

        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserDetailModel>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => GetUserFullName(src)))
                    .ReverseMap();

            });
        }

        #region Helpers
        public static string GetUserFullName(User user)
        {
            string fullName = string.Empty;
            if (user == null)
                return fullName;
            if (!string.IsNullOrEmpty(user.FirstName))
                fullName += user.FirstName;
            if (!string.IsNullOrEmpty(user.MiddleName))
                fullName = !string.IsNullOrEmpty(fullName) ? fullName + " " + user.MiddleName : user.MiddleName;
            if (!string.IsNullOrEmpty(user.LastName))
                fullName = !string.IsNullOrEmpty(fullName) ? fullName + " " + user.LastName : user.LastName;
            return fullName;
        }
        #endregion
    }
}