using AutoMapper;
using BAD.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BAD.Management.BaseModel
{
    public abstract class ManagerBase
    {
        #region Protected props
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        #endregion

        public ManagerBase()
        {
            unitOfWork = AppContainer.AppContainer.Resolve<IUnitOfWork>();
            mapper = AppContainer.AppContainer.Resolve<IMapper>();
        }


        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public string GetResouceValue(string resourceName)
        {
            //TODO premysli cultures
            return Resources.Models.ResourceManager.GetString(resourceName, new CultureInfo("sk-SK"));
        }
    }
}