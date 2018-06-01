﻿using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Base.Implementation;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models;
using FamilyTracker.Data.Entity;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Managers.Implementation
{
    public class LogManager : CrudManager<Log, LogModel>, ILogManager
    {
        #region Consctructors

        public LogManager(
            IUnitOfWork unitOfWork,
            IObjectMapper objectMapper)
            : base(unitOfWork, unitOfWork.Logs, objectMapper)
        {
        }

        #endregion

        #region Interface members



        #endregion
    }
}