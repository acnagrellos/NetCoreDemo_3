using Microsoft.AspNetCore.Mvc;
using MyProject.Host.Models;
using System.Net;

namespace MyProject.Host.Controllers
{
    [Route("/api/{version:apiVersion}/students")]
    [ApiVersion("1.0")]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{productId:int}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int productId) 
        {
            if (productId <= 0) 
            {
                return NotFound();
            }

            return Ok(new Product(productId, "Prueba", 12));
        }
    }
}