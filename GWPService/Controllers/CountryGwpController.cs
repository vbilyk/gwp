using GWPService.Interfaces;
using GWPService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GWPService.Controllers
{
    [Route("server/api/gwp")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly IDataRepository<GwpItem> _repository;

        public CountryGwpController(IDataRepository<GwpItem> repository)
        {
            this._repository = repository;
        }

        [HttpPost("avg")]
        public async Task<IActionResult> CalculateAverage([FromBody] GwpRequest request)
        {
            var actionResult = this.ValidateArguments(request);
            if (actionResult != null)
                return actionResult;
            Dictionary<string, decimal> result = null;
            try
            {
                var records = await this._repository.GetAllWhere(request.Country, request.LoB);
                result = records.ToDictionary(r => r.LineOfBusiness, v => v.Average());
            }
            catch(Exception ex)
            {
                return new CountryGwpErrorActionResult(ex.Message);
            }

            return Ok(result);
        }

        private IActionResult ValidateArguments(GwpRequest request)
        {
            if (request == null)
            {
                return new CountryGwpErrorActionResult("request param cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(request.Country) || request.Country.Length != 2)
            {
                return new CountryGwpErrorActionResult("country param cannot be empty and must 2 characters long");
            }
            if(request.LoB.Length < 1)
            {
                return new CountryGwpErrorActionResult("please provide at least one line of business in params");
            }
            return null;
        }
    }
}
