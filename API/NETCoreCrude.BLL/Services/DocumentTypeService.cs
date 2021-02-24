using NETCoreCrude.DAL.Models;
using NETCoreCrude.DAL.Repositories;
using System.Collections.Generic;

namespace NETCoreCrude.BLL.Services
{
    /// <summary>
    ///
    /// </summary>
    public class DocumentTypeService
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        internal IDocumentTypeRepository _Repository;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="pRepository"></param>
        public DocumentTypeService(IDocumentTypeRepository pRepository)
        {
            _Repository = pRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DocumentType> GetList()
        {
            return _Repository.GetList();
        }

        #endregion Constructor
    }
}