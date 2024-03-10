using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace OrderPurches.WebApi.Features.ServiceLayer.DTO
{
    public class DocumentsDTO
    {
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public string CardCode { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public int Serie { get; set; }
        public string U_FIS { get; set; }
        public List<DocumentDetailDTO> DocumenLines {  get; set; }
    }
}
