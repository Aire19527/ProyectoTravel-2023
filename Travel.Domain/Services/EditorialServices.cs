using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Domain.DTO.Library.Editorial;
using Travel.Domain.Services.Interface;

namespace Travel.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods

        public List<Editorial_Dto> GetAllEditorial()
        {
            IEnumerable<EditorialEntity> list = _unitOfWork.EditorialRepository.GetAll();
            List<Editorial_Dto> result = list.Select(x => new Editorial_Dto()
            {
                Id = x.Id,
                Name = x.Name,
                Sede = x.Sede
            }).ToList();

            return result;
        }

        #endregion
    }
}
