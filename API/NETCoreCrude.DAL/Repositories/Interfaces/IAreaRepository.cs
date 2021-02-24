using System.Collections.Generic;

namespace NETCoreCrude.DAL.Repositories
{
    using DAL.Models;

    /// <summary>
    ///
    /// </summary>
    public interface IAreaRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<Area> GetList();
    }
}