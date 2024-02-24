using Org.BouncyCastle.Asn1.Crmf;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System;
using RestSharp;
using BaseApi.WebApi.Features.ServiceLayer.DTO;
using System.Linq;

namespace BaseApi.WebApi.Features.ServiceLayer.Services
{
    public class AuthSapServices
    {
        public static bool LoginActivo = false;
        public string SLSessionID;

        //Genera el certificado 
        private static bool ValidarCertificado(object sender, X509Certificate cert, X509Chain chain,
            SslPolicyErrors ssl)
        {
            return true;
        }

        public bool Login()
        {
            try
            {
                var client = new RestClient($"{Global.sURL}Login");
                var request = new RestRequest(Method.POST);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.DefaultConnectionLimit = 9999;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls13;
                ServicePointManager.ServerCertificateValidationCallback = ValidarCertificado;
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");

                var requestBody = new
                {
                    CompanyDB = Global.sCompany,
                    Password = Global.sPassword,
                    UserName = Global.sUser
                };

                request.AddJsonBody(requestBody);

                IRestResponse response = client.Execute(request);
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;

                if (numericStatusCode == 200)
                {
                    var session = response.Cookies.SingleOrDefault(x => x.Name == "B1SESSION");
                    if (session != null)
                    {
                        SLSessionID = session.Value;
                    }

                    LoginActivo = true;
                }
                else
                {
                    throw new Exception($"Error en la conexión con el servicio Service Layer. Motivo: {response.StatusDescription}-{response.ErrorMessage}");
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}

