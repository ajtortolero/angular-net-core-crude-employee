using NETCoreCrude.DAL.Models;
using NETCoreCrude.DAL.Repositories;
using System.Collections.Generic;

namespace FleetControl.BLL.Services
{
    /// <summary>
    ///
    /// </summary>
    public class EmployeeService
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        private IEmployeeRepository _Repository;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="_IEmployeeRepository"></param>
        public EmployeeService(IEmployeeRepository pRepository)
        {
            _Repository = pRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetList()
        {
            return _Repository.GetList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Employee GetByDocumentNumber(string pDocumentNumber)
        {
            return _Repository.GetByDocumentNumber(pDocumentNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        public Employee Create(Employee pEmployee)
        {
            return _Repository.Create(pEmployee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        public Employee Update(int pEmployeeID, Employee pEmployee)
        {
            return _Repository.Update(pEmployeeID, pEmployee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <returns></returns>
        public int Delete(int pEmployeeID)
        {
            return _Repository.Delete(pEmployeeID);
        }

        #endregion Constructor
    }
}