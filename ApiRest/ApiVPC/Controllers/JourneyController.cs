using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiVPC.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiVPC.Controllers
{
    public class JourneyController : BaseController
    {
        /* private readonly HttpClient _httpClient; */
        private readonly JourneyService _journeyService;
        public JourneyController(HttpClient httpClient, JourneyService journeyService)
        {
            /* _httpClient = httpClient; */
            _journeyService = journeyService;
        }

        [HttpGet("GetDataVPC")]
        public async Task<ActionResult<VPC>> GetDataVPC()
        {
            var datosJson = await _journeyService.GetDataVPC();
            Console.WriteLine($"{datosJson.GetType().Name}");
/*             if (datosJson is List<VPC> dataList)
            {
                foreach (var item in dataList)
                {
                    Console.WriteLine($"Tipo: {item.GetType()}");
                    Console.WriteLine(item.ArrivalStation);
                    Console.WriteLine(item.DepartureStation);
                }
            } */
            
            if (datosJson is string msjError) return BadRequest(msjError);
            
            return Ok(datosJson);
        }
    }
}