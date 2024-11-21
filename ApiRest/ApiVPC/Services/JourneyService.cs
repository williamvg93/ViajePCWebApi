using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Newtonsoft.Json;

namespace ApiVPC.Services
{
    public class JourneyService
    {
        private readonly HttpClient _httpClient;
        public JourneyService(HttpClient httpClient)
        {
            _httpClient = httpClient;        
        }

        /* public async Task<List<VPC>?> GetDataVPC()
        {
            try
            {
                string url = "https://bitecingcom.ipage.com/testapi/avanzadso.js";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                string urlContent = await response.Content.ReadAsStringAsync();
                List<VPC>? datosJson = JsonConvert.DeserializeObject<List<VPC>>(urlContent);

                if (datosJson == null)
                {
                    return null;
                }

                return datosJson;
            }
            catch (HttpRequestException error)
            {
                Console.WriteLine($"Error: {error.Message}");
                return null;
            }
        } */

        public async Task<object> GetDataVPC()
        {
            try
            {
                string url = "https://bitecingcom.ipage.com/testapi/avanzado.js";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return $"Error en la url: {response.StatusCode} - {response.ReasonPhrase}";
                }

                string urlContent = await response.Content.ReadAsStringAsync();
                List<VPC>? datosJson = JsonConvert.DeserializeObject<List<VPC>>(urlContent);

                if (datosJson == null) return "No se encontraton datos";

                return datosJson;
            }
            catch (HttpRequestException err)
            {
                Console.WriteLine($"Error: {err.Message}");
                
                return $"Error : {err.Message}";
            }
            catch (Exception ex)
            {
                /* Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.StackTrace}");
                Console.WriteLine($"{ex.GetType().Name}"); */
                return $"Error : {ex.Message}";
            }
        }

    }
}