using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Autor;
using Travel.Domain.DTO.Library;
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

        public async Task<bool> InsertEditorial(AddEditorial_Dto editorial)
        {
            EditorialEntity newEditorial = new EditorialEntity()
            {
                Name = editorial.Name,
                Sede = editorial.Sede
            };

            _unitOfWork.EditorialRepository.Insert(newEditorial);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateEditorial(Editorial_Dto edit)
        {
            EditorialEntity editorial = GetEditorial(edit.Id);

            editorial.Name = edit.Name;
            editorial.Sede = edit.Sede;

            _unitOfWork.EditorialRepository.Update(editorial);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteEditorial(int idEditorial)
        {
            EditorialEntity editorial = GetEditorial(idEditorial);
            _unitOfWork.EditorialRepository.Delete(editorial);

            return await _unitOfWork.Save() > 0;
        }


        private EditorialEntity GetEditorial(int idEditorial) => _unitOfWork.EditorialRepository.FirstOrDefaultNotTracking(x => x.Id == idEditorial);



        #endregion
    }
}
