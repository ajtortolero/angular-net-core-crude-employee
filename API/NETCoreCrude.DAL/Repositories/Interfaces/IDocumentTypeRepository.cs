using System.Collections.Generic;

namespace NETCoreCrude.DAL.Repositories
{
    using DAL.Models;

    /// <summary>
    ///
    /// </summary>
    public interface IDocumentTypeRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<DocumentType> GetList();
    }
}