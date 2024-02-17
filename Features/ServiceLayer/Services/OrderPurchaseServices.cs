using BaseApi.WebApi.Features.Documents.DTO;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System.Net;
using System;
using RestSharp;
using BaseApi.WebApi.Features.ServiceLayer.DTO;
using DocumentDTO = BaseApi.WebApi.Features.ServiceLayer.DTO.DocumentDTO;

namespace BaseApi.WebApi.Features.ServiceLayer.Services
{
    public class OrderPurchaseServices
    {
        private readonly AuthSapServices _authSapServices;

        public OrderPurchaseServices(AuthSapServices authSapServices)
        {
            _authSapServices = authSapServices;
        }

        public int CreatePurchaseOrder(DocumentDTO purchaseOrderModel)
        {
            var login = _authSapServices.Login();
            if (login)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(purchaseOrderModel, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    var client = new RestClient($"{Global.sURL}PurchaseOrders");
                    var request = new RestRequest(Method.POST)
                    {
                        RequestFormat = DataFormat.Json
                    };

                    request.AddHeader("Cache-Control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                    request.AddCookie("B1SESSION", _authSapServices.SLSessionID);

                    IRestResponse response = client.Execute(request);

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        // docEntry = ObtenerAbsEntrys.ObtenerDocEntry(response.Content);
                        // Conexion.LogOut();
                        return 1;
                    }
                    else if (response.Content.Contains("Invalid session."))
                    {
                        _authSapServices.Login();
                    }
                    else
                    {
                        // string errorMessage = ObtenerMensajeError(response.Content);
                        // throw new Exception($"Error al crear la orden de compra: {errorMessage}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return 0;
        }

    }
}
