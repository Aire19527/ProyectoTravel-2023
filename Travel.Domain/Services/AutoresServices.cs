using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Domain.DTO.Library;
using Travel.Domain.Services.Interface;

namespace Travel.Domain.Services
{
    public class AutoresServices : IAutoresServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AutoresServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods

        public List<Autor_DTO> GetAllAutores()
        {
            IEnumerable<AutoresEntity> listAutors = _unitOfWork.AutorRepository.GetAll();
            List<Autor_DTO> result = listAutors.Select(x => new Autor_DTO()
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
            }).ToList();

            return result;
        }

        private AutoresEntity GetAutor(int idAutor) => _unitOfWork.AutorRepository.FirstOrDefaultNotTracking(x => x.Id == idAutor);





        #endregion
    }
}
