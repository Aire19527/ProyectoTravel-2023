using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library;
using Travel.Domain.DTO.Library.Autor;
using Travel.Domain.Services.Travel.Interface;

namespace Travel.Domain.Services.Travel
{
    public class AutorServices : IAutorServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AutorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods

        public List<ConsultAutor_DTO> GetAllAutores()
        {
            IEnumerable<AutorEntity> listAutors = _unitOfWork.AutorRepository.GetAll();
            List<ConsultAutor_DTO> result = listAutors.Select(x => new ConsultAutor_DTO()
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                FullName = x.FullName
            }).ToList();

            return result;
        }

        public async Task<bool> InsertAutor(Autor_DTO autor)
        {
            AutorEntity newAutor = new AutorEntity()
            {
                Name = autor.Name,
                LastName = autor.LastName,
            };
            _unitOfWork.AutorRepository.Insert(newAutor);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateAutor(ConsultAutor_DTO autor)
        {
            AutorEntity updateAutor = GetAutor(autor.Id);
            updateAutor.Name = autor.Name;
            updateAutor.LastName = autor.LastName;

            _unitOfWork.AutorRepository.Update(updateAutor);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteAutor(int idAutor)
        {
            AutorEntity autor = GetAutor(idAutor);
            _unitOfWork.AutorRepository.Delete(autor);

            return await _unitOfWork.Save() > 0;
        }


        private AutorEntity GetAutor(int idAutor) => _unitOfWork.AutorRepository.FirstOrDefaultNotTracking(x => x.Id == idAutor);

        #endregion
    }
}
