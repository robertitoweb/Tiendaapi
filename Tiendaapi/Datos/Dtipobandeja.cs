using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Tiendaapi.Conexion;
using Tiendaapi.Modelo;

namespace Tiendaapi.Datos
{
    public class Dtipobandeja
    {
        Conexionbd cn = new Conexionbd();
        public async Task <List<Mtipobandeja>> Mostrarbandejas()
        {
            var list = new List<Mtipobandeja>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd= new SqlCommand("mostrartipobandeja",sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                           var mtipobandejas = new Mtipobandeja();
                            mtipobandejas.id = (int)item["id"];
                            mtipobandejas.descripcion = (string)item["descripcion"];
                            mtipobandejas.kg = (decimal)item["kg"];
                            mtipobandejas.estado = (int)item["estado"];
                            list.Add(mtipobandejas);
                        }

                    }
                }
            }
            return list;
        }
        public async Task InsertTipobandeja(Mtipobandeja param)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd= new SqlCommand("InsertTipobandeja",sql))
                {
                    cmd.CommandType= System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion",param.descripcion);
                    cmd.Parameters.AddWithValue("@kg",param.kg);
                    cmd.Parameters.AddWithValue("@estado", param.estado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }
        public async Task EditTipobandeja(Mtipobandeja param)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("EditTipobandeja", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", param.id);
                    cmd.Parameters.AddWithValue("@descripcion", param.descripcion);
                    cmd.Parameters.AddWithValue("@kg", param.kg);
                    cmd.Parameters.AddWithValue("@estado", param.estado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }
        public async Task DeleteTipobandeja(Mtipobandeja param)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("DeleteTipobandeja", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", param.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }

    }
}
