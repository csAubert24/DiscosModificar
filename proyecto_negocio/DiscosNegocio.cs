using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using proyecto_dominio;

namespace proyecto_negocio
{
     public class DiscosNegocio
    {
        public List<Discos> listar()
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security = true" ;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo,CantidadCanciones,UrlImagenTapa, E.Descripcion estilo, T.Descripcion formato, D.IdEstilo, D.IdTipoEdicion,D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = (int)lector["Id"];
                    aux.titulo = (string)lector["Titulo"];
                    aux.canciones = (int)lector["CantidadCanciones"];

                    if (!(lector["UrlImagenTapa"]is DBNull))
                        aux.url = (string)lector["UrlImagenTapa"];


                    aux.Estilo = new elemento();
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)lector["estilo"];
                    aux.formato = new elemento();
                    aux.formato.Id = (int)lector["IdTipoEdicion"];
                    aux.formato.Descripcion = (string)lector["formato"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch ( Exception ex)
            {

                throw ex;
            }
           
        }

        public void agregar(Discos nuevo)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo,CantidadCanciones,UrlImagenTapa,IdEstilo,IdTipoEdicion)values('" + nuevo.titulo + "',"+nuevo.canciones+",'" + nuevo.url + "',@IdEstilo,@IdTipoEdicion)");
                datos.setearParametro("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.formato.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Discos dis)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @Tit,CantidadCanciones = @can, UrlImagenTapa = @img,IdEstilo = @Ide,IdTipoEdicion= @Idf where Id = @Id");
                datos.setearParametro("@Tit",dis.titulo );
                datos.setearParametro("@can",dis.canciones);
                datos.setearParametro("@img", dis.url);
                datos.setearParametro("@Ide", dis.Estilo.Id);
                datos.setearParametro("@Idf",dis.formato.Id );
                datos.setearParametro("@Id", dis.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
