
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;


namespace Capa_Datos
{
    public class ProductosMetodos : Conexion
    {
        public Boolean NuevoProducto(Producto producto)
        {

            DateTime fecha = DateTime.Now;
            String anio = DateTime.Now.Year.ToString();
            try
            {
                var sel = "set dateformat dmy insert into Productos(prod_CodDeProd, prod_Descripción, prod_Talle, prod_Tipo, prod_UbicEnDepo, prod_Cantidad, prod_StockMin, prod_StockMax, prod_Estado, prod_Temporada, prod_Fecha, prod_Anio)" +
                   " values('" + producto.prod_CodDeProd + "', '" + producto.prod_Descripción + "','" + producto.prod_Talle + "','" + producto.prod_Tipo + "','" + producto.prod_UbicEnDepo + "','" + producto.prod_Cantidad + "','" + producto.prod_StockMin + "','" + producto.prod_StockMax + "','" + producto.prod_Estado + "','" + producto.prod_Temporada + "','" + fecha + "','" + anio + "')";
                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                return false;
            }
        }

        public DataTable ConsultarProductoTipo(Producto prod_Tipo)
        {
            throw new NotImplementedException();
        }

        public DataTable ConsultarProdXTipo(Producto prod_Tipo)
        {
            var sqlStr = "select prod_CodDeProd as Codigo,prod_Tipo as tipo,prod_subtipo as Subtipo from Productos where prod_Tipo ='" + prod_Tipo + "';";
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        }

    }
}

