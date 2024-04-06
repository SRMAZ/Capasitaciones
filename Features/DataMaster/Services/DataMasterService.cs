using OrderPurches.WebApi.Features.DataMaster.DTO;
using OrderPurches.WebApi.Infraestructure;
//using Sap.Data.Hana;
using System.Collections.Generic;

namespace OrderPurches.WebApi.Features.DataMaster.Services
{
    public class DataMasterService
    {
        private readonly HanaDbContext _context;

        public DataMasterService (HanaDbContext context)
        {
            _context = context;
        }

        //public List<DataMasterDTO> GetSupplir()
        //{
        //    List<DataMasterDTO> supplir = new List<DataMasterDTO>();

        //    _context.Conn.Open();
        //    string query = $@"SELECT T0.""CardCode"", T0.""CardName"" FROM ""PRUEBAS_INTERCOSMO"".""OCRD"" T0 WHERE T0.""CardType"" ='S' AND  T0.""CardCode"" LIKE 'PN%'"; 
        //    HanaCommand selectCmd= new HanaCommand(query, _context.Conn);
        //    HanaDataReader dr = selectCmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        DataMasterDTO Data = new DataMasterDTO
        //        {

        //            Code = dr.GetString(0),
        //            Name = dr.GetString(1)

        //        };
        //        supplir.Add(Data);
        //    }

        //    dr.Close();
        //    _context.Conn.Close();
        //    return supplir;

        //}

        //public List<DataMasterDTO> GetItems()
        //{
        //    List<DataMasterDTO> ItemsList = new List<DataMasterDTO>();

        //    _context.Conn.Open();
        //    string query = $@"SELECT T0.""ItemCode"", T0.""ItemName"" FROM ""PRUEBAS_INTERCOSMO"".""OITM"" T0 WHERE T0.""ItemCode"" LIKE 'P%'";
        //    HanaCommand selectCmd = new HanaCommand(query, _context.Conn);
        //    HanaDataReader dr = selectCmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        DataMasterDTO Data = new DataMasterDTO
        //        {

        //            Code = dr.GetString(0),
        //            Name = dr.GetString(1)

        //        };
        //        ItemsList.Add(Data);
        //    }

        //    dr.Close();
        //    _context.Conn.Close();
        //    return ItemsList;
        //}

    }
}
