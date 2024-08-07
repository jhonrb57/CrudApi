using Dapper;
using Models;
using BaseDatos;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly ConexionBd conexion = new();

        // GET: api/<InventarioController>
        [HttpGet]
        public List<Inventario> Get()
        {
            using(var connection = new SqlConnection(conexion.Conexion()))
            {
                List<Inventario> list = connection.Query<Inventario>("pp_listar", commandType: CommandType.StoredProcedure).ToList();

                return list;
            }
        }

        // GET api/<InventarioController>/5
        [HttpGet("{id}")]
        public Inventario Get(string id)
        {
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("idProducto", id);
                Inventario inventario = connection.QueryFirstOrDefault<Inventario>("pp_obtener", parameters, commandType: CommandType.StoredProcedure);

                return inventario;
            }
        }

        // POST api/<InventarioController>
        [HttpPost]
        public IActionResult Post(Inventario inventario)
        {
            int result = 0;
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idProducto",inventario.IdProducto);
                parameters.Add("@nombreProducto", inventario.NombreProducto);
                parameters.Add("@cantidad", inventario.Cantidad);
                parameters.Add("@categoria", inventario.Categoria);
                parameters.Add("@descuento", inventario.Descuento);
                result = connection.Execute("pp_registrar", parameters, commandType: CommandType.StoredProcedure);

                return Ok(result);
            }
        }

        // PUT api/<InventarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Inventario inventario)
        {
            int result = 0;
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idProducto", inventario.IdProducto);
                parameters.Add("@nombreProducto", inventario.NombreProducto);
                parameters.Add("@cantidad", inventario.Cantidad);
                parameters.Add("@categoria", inventario.Categoria);
                parameters.Add("@descuento", inventario.Descuento);
                result = connection.Execute("pp_modificar", parameters, commandType:CommandType.StoredProcedure);

                return Ok(result);
            }
        }

        // DELETE api/<InventarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            int result = 0;
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("idProducto", id);
                result = connection.Execute("pp_eliminar", parameters, commandType:CommandType.StoredProcedure);

                return Ok(result);
            }
        }
    }
}
