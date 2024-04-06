using OrderPurches.WebApi.Features.Documents.DTO;
using OrderPurches.WebApi.Features.Documents.Entities;
using OrderPurches.WebApi.Infraestructure;
using System.Collections.Generic;
using System.Linq;

namespace OrderPurches.WebApi.Features.Documents.Services
{
    public class DocumentService
    {
        private readonly OrderPurchesDbContext _context;

        public DocumentService(OrderPurchesDbContext context)
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
                              Name = Document.Name,
                              userName = tbUsers.Name,
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
                              userName = tbUsers.Name,
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
        
        public List<DocumentDTO> Update(Document request)
        {
            request.IsValid();
            _context.Document.Update(request);
            _context.SaveChanges();
            return GetDocument();
        }
        
        public List<DocumentDTO> Delete(Document request)
        {
            request.IsValid();

            _context.Document.Remove(request);
            _context.SaveChanges();
            return GetDocument();
        }

    }
}
