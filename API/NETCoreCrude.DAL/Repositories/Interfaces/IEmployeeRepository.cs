using NETCoreCrude.DAL.Models;
using System.Collections.Generic;

namespace NETCoreCrude.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocumentNumber"></param>
        /// <returns></returns>
        Employee GetByDocumentNumber(string pDocumentNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        Employee Create(Employee pEmployee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        Employee Update(int pEmployeeID, Employee pEmployee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <returns></returns>
        int Delete(int pEmployeeID);
    }
}