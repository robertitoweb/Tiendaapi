using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Tiendaapi.Datos;
using Tiendaapi.Modelo;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/tipobandeja")]

    public class TipobandejaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mtipobandeja>>> Get()
        {
            var funcion = new Dtipobandeja();
            var list = await funcion.Mostrarbandejas();
            return list;
        }

        [HttpPost]
        public async Task Post([FromBody] Mtipobandeja param)
        {
            var funcion = new Dtipobandeja();
            await funcion.InsertTipobandeja(param);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] Mtipobandeja param)
        {
            param.id = id;
            var funcion = new Dtipobandeja();
            await funcion.EditTipobandeja(param);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var param = new Mtipobandeja();
            param.id = id;
            var funcion = new Dtipobandeja();
            await funcion.DeleteTipobandeja(param);
            return NoContent();
        }
    }
}
