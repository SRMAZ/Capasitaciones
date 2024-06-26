﻿using OrderPurches.WebApi.Features.Documents.DTO;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System.Net;
using System;
using RestSharp;
using OrderPurches.WebApi.Features.ServiceLayer.DTO;
using System.Text.Json;

namespace OrderPurches.WebApi.Features.ServiceLayer.Services
{
    public class OrderPurchaseServices
    {
        private readonly AuthSapServices _authSapServices;

        public OrderPurchaseServices(AuthSapServices authSapServices)
        {
            _authSapServices = authSapServices;
        }

        public (int, int) CreatePurchaseOrder(DocumentsDTO purchaseOrderModel)
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
                        // Deserializar el JSON en un objeto para acceder a las propiedades
                        var responseObject = JsonConvert.DeserializeObject<DocumentsDTO>(response.Content);
                        // Acceder a las propiedades
                        int docEntry = responseObject.DocEntry;
                        int docNum = responseObject.DocNum;
                        return (docEntry, docNum);
                    }
                    else if (response.Content.Contains("Invalid session."))
                    {
                        _authSapServices.Login();
                    }
                    else
                    {
                        using (JsonDocument doc = JsonDocument.Parse(response.Content))
                        {
                            // Obtener la raíz del documento JSON
                            var root = doc.RootElement;
                            // Verificar si hay un objeto "error" en el JSON
                            if (root.TryGetProperty("error", out JsonElement errorElement))
                            {
                                // Verificar si hay una propiedad "message" en el objeto "error"
                                if (errorElement.TryGetProperty("message", out JsonElement messageElement))
                                {
                                    // Obtener el valor de la propiedad "value" del mensaje de error
                                    string errorMessage = messageElement.GetProperty("value").GetString();
                                    // Lanzar una excepción con el mensaje de error
                                    throw new Exception(errorMessage);
                                }
                                else
                                {
                                    // Si no hay una propiedad "message", lanzar una excepción genérica
                                    throw new Exception("Error desconocido: no se pudo encontrar el mensaje de error.");
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return (0, 0);
        }

    }
}
