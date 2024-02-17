using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace BaseApi.WebApi.Features.ServiceLayer.DTO
{
    public class DocumentDTO
    {
        public int DocEntry {  get; set; }
        public int DocNum {  get; set; }
        public string  DocCode {  get; set; }
        public DateTime DocDate {  get; set; }
        public DateTime DocDueDate {  get; set; }
        public int Serie {  get; set; }
        public List<DocumentDetailDTO> DocumenLines {  get; set; }
    }
}
