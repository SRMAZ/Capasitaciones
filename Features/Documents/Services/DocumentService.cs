using BaseApi.WebApi.Features.Documents.DTO;
using BaseApi.WebApi.Features.Documents.Entities;
using BaseApi.WebApi.Infraestructure;
using System.Collections.Generic;
using System.Linq;

namespace BaseApi.WebApi.Features.Documents.Services
{
    public class DocumentService
    {
        private readonly BaseApiDbContext _context;

        public DocumentService(BaseApiDbContext context)
        {
            _context = context;
        }

        public List<DocumentDTO> GetDocument()
        {
            var result = (from Document in _context.Document
                          join tbUsers  in _context.User on Document.CreateBy equals tbUsers.UserId
                          select new DocumentDTO
                          {
                              Id = Document.Id,
                              Name = tbUsers.Name,
                              CreateBy = Document.CreateBy,
                              CreatebyDate = Document.CreatebyDate,
                              UpdateBy = Document.UpdateBy,
                              UpdateDate  = Document.UpdateDate

                          }).ToList();

            return result;
        }

        public List<DocumentDTO> GetDocumentById(int Id)
        {
            var result = (from Document in _context.Document
                          join tbUsers in _context.User on Document.CreateBy equals tbUsers.UserId
                          where Document.Id == Id
                          select new DocumentDTO
                          {
                              Id = Document.Id,
                              Name = Document.Name,
                              CreateBy = Document.CreateBy,
                              CreatebyDate = Document.CreatebyDate,
                              UpdateBy = Document.UpdateBy,
                              UpdateDate = Document.UpdateDate

                          }).ToList();

            return result;
        }

        public List<DocumentDTO> Add(Document request)
        {
            request.IsValid();

            _context.Document.Add(request);
            _context.SaveChanges();
            return GetDocument();
        }

    }
}
