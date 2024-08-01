using Dapper;
using Models;
using BaseDatos;
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
                var sql = "Select * from Inventario";
                List<Inventario> list = connection.Query<Inventario>(sql).ToList();

                return list;
            }
        }

        // GET api/<InventarioController>/5
        [HttpGet("{id}")]
        public List<Inventario> Get(string id)
        {
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                var sql = "Select * from Inventario where IdProducto = " + id;
                List<Inventario> list = connection.Query<Inventario>(sql).ToList();

                return list;
            }
        }

        // POST api/<InventarioController>
        [HttpPost]
        public IActionResult Post(Inventario model)
        {
            int result = 0;
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                var sql = "Insert into Inventario Values(@IdProducto,@NombreProducto,@Cantidad,@Categoria,@Descuento)";
                result = connection.Execute(sql, model);

                return Ok(result);
            }
        }

        // PUT api/<InventarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Inventario model)
        {
            int result = 0;
            using (var connection = new SqlConnection(conexion.Conexion()))
            {
                var sql = "Update Inventario set IdProducto=@IdProducto,NombreProducto=@NombreProducto,Cantidad=@Cantidad,Categoria=@Categoria,Descuento=@Descuento" +
                    " where IdProducto = " + id;
                result = connection.Execute(sql, model);

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
                var sql = "Delete from Inventario where IdProducto = " + id;
                result = connection.Execute(sql);

                return Ok(result);
            }
        }
    }
}
