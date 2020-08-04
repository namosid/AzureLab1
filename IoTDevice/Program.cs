using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IoTDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            //string deviceId = "SidIoTDevice".ToLower();
            //string deviceKey = "gFLTKzrVTXhq6THIqoedswFr+KiUFrb9q27qafmWXks=";
            //string hostname = $"SidTestIoT.azure-devices.net";
            //string endpoint = $"{hostname}/devices/{deviceId}";
            //var token = GenerateSasToken(endpoint, deviceKey);
            //var conn = $"HostName={hostname};CredentialType=SharedAccessSignature;DeviceId={deviceId};SharedAccessSignature={token}";
            var conn = "HostName=SidTestIoT.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=VKOYPRPIAnmcAptRG2F/012KPvuE4LgddUS9kHT/2D8=;DeviceId=SidIoTDevice";
            var deviceClient = DeviceClient.CreateFromConnectionString(conn, TransportType.Amqp_WebSocket_Only);
            SendEvent(deviceClient).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static string GenerateSasToken(string resourceUri, string key, string policyName = null, int expiryInSeconds = 3600)
        {
            TimeSpan fromEpochStart = DateTime.UtcNow - new DateTime(1970, 1, 1);
            string expiry = Convert.ToString((int)fromEpochStart.TotalSeconds + expiryInSeconds);

            string stringToSign = WebUtility.UrlEncode(resourceUri) + "\n" + expiry;

            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(key));
            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));

            string token = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}", WebUtility.UrlEncode(resourceUri), WebUtility.UrlEncode(signature), expiry);

            if (!String.IsNullOrEmpty(policyName))
            {
                token += "&skn=" + policyName;
            }

            return token;
        }

        static async Task SendEvent(DeviceClient deviceClient)
        {

            var dataBuffer = JsonConvert.SerializeObject(
                new
                {
                    ProductName = "IoT Architecture Book",
                    Quantity = 1,
                    Status = "Ordered"
                });
            var eventMessage = new Message(Encoding.UTF8.GetBytes(dataBuffer));
            // Add  key value to each message for routing.
            // key use for controller name, value for function to invoke 
            eventMessage.Properties.Add("Temp", "AddAsync");

            await deviceClient.SendEventAsync(eventMessage);
        }
    }
}
