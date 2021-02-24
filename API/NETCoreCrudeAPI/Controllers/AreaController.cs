using NETCoreCrude.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using NETCoreCrude.DAL.Repositories;

namespace NETCoreCrudeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Area")]
    public class AreaController
        : Controller
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        internal AreaService _Service;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="pRepository"></param>
        public AreaController(IAreaRepository pRepository)
        {
            _Service = new AreaService(pRepository);
        }

        #endregion Constructor

        #region Operations

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Areas/GetList")]
        public IActionResult GetList()
        {
            var varResult = _Service.GetList();
            return new OkObjectResult(varResult);
        }

        #endregion Operations
    }
}