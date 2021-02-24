using System.Collections.Generic;

namespace NETCoreCrude.BLL.Services
{
    using NETCoreCrude.DAL.Models;
    using NETCoreCrude.DAL.Repositories;

    /// <summary>
    ///
    /// </summary>
    public class AreaService
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        internal IAreaRepository _Repository;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="pRepository"></param>
        public AreaService(IAreaRepository pRepository)
        {
            _Repository = pRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Area> GetList()
        {
            return _Repository.GetList();
        }

        #endregion Constructor
    }
}