using OrderPurches.WebApi.Features.Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Crypto.Tls;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrderPurches.WebApi.Features.Documents.DTO
{
    public class DocumentDTO: Document
    {

        public string userName { get; set; }


    }
}
