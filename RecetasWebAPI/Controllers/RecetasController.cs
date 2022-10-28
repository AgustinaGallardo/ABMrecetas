using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetaBack.dominio;
using RecetaBack.Negocio.Implementacion;
using RecetaBack.Negocio.Interfaz;

namespace RecetasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private IAplicacion app;

        public RecetasController()
        {
            app = new Aplicacion();
        }
        [HttpGet("Ingredientes")]
        public IActionResult GetIngredientes()
        {
            return Ok(app.ObtenerIngredientes());
        }
        [HttpPost]
        public IActionResult PostReceta(Receta oReceta)
        {
            if(oReceta == null)
            {
                return BadRequest();
            }
            if (app.Save(oReceta))
                return Ok("La receta se registro exitosamente");
            else
                return Ok("La receta no se registro exitosamente");
        }






    }
}
