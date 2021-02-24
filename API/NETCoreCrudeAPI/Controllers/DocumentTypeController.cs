using Microsoft.AspNetCore.Mvc;

namespace NETCoreCrudeAPI.Controllers
{
    using NETCoreCrude.BLL.Services;
    using NETCoreCrude.DAL.Repositories;

    /// <summary>
    ///
    /// </summary>
    [Produces("application/json")]
    [Route("api/DocumentType")]
    public class DocumentTypeController
        : Controller
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        internal DocumentTypeService _Service;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="pRepository"></param>
        public DocumentTypeController(IDocumentTypeRepository pRepository)
        {
            _Service = new DocumentTypeService(pRepository);
        }

        #endregion Constructor

        #region Operations

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DocumentTypes/GetList")]
        public IActionResult GetList()
        {
            var varResult = _Service.GetList();
            return new OkObjectResult(varResult);
        }

        #endregion Operations
    }
}