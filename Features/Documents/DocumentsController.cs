using BaseApi.WebApi.Features.Documents.Entities;
using BaseApi.WebApi.Features.Documents.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.WebApi.Features.Documents
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult GetDocument()
        {
            try
            {
                var Document = _documentService.GetDocument();
                return Ok(Document);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetdocumentById{id}")]
        public ActionResult GetDocumentById(int id)
        {
            try
            {
                var Document = _documentService.GetDocumentById(id);
                return Ok(Document);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Add(Document request)
        {
            try
            {
                var result = _documentService.Add(request);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
