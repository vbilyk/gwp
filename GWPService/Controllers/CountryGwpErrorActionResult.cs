using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWPService.Controllers
{
    internal class CountryGwpErrorActionResult : IActionResult
    {
        private string _message;

        public CountryGwpErrorActionResult(string message)
        {
            this._message = message;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this._message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}