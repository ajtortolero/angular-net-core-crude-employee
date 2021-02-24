using FleetControl.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using NETCoreCrude.DAL.Models;
using NETCoreCrude.DAL.Repositories;
using System;

namespace NETCoreCrudeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController
        : Controller
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        private EmployeeService _Service;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="pIEmployeeRepository"></param>
        public EmployeeController(IEmployeeRepository pIEmployeeRepository)
        {
            _Service = new EmployeeService(pIEmployeeRepository);
        }

        #endregion Constructor

        #region Operations

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Employees/GetList")]
        public IActionResult GetList()
        {
            var varResult = _Service.GetList();
            return new OkObjectResult(varResult);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pDocumentNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Employees/GetByDocumentNumber/{pDocumentNumber}")]
        public IActionResult GetByDocumentNumber(string pDocumentNumber)
        {
            var varResult = _Service.GetByDocumentNumber(pDocumentNumber);
            return new OkObjectResult(varResult);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Employees/Create")]
        public IActionResult Create([FromBody] Employee pEmployee)
        {
            try
            {
                var varResult = _Service.Create(pEmployee);
                return new OkObjectResult(varResult);
            }
            catch (Exception varException)
            {
                return new BadRequestObjectResult(varException.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Employees/Update/{pEmployeeID}")]
        public IActionResult Update(int pEmployeeID, [FromBody] Employee pEmployee)
        {
            try
            {
                var varResult = _Service.Update(pEmployeeID, pEmployee);
                return new OkObjectResult(varResult);
            }
            catch (Exception varException)
            {
                return new BadRequestObjectResult(varException.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Employees/Delete/{pEmployeeID}")]
        public IActionResult Delete(int pEmployeeID)
        {
            try
            {
                var varResult = _Service.Delete(pEmployeeID);
                return new OkObjectResult(varResult);
            }
            catch (Exception varException)
            {
                return new BadRequestObjectResult(varException.Message);
            }
        }

        #endregion Operations
    }
}