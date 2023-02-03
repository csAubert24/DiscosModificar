using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using proyecto_dominio;

namespace proyecto_negocio
{
    public class ElementoNegocio
    {
        public List<elemento> listar()
        {
            List<elemento> lista = new List<elemento>();
            accesoDatos Datos = new accesoDatos();
            try
            {
                Datos.setearConsulta("select Id, Descripcion from ESTILOS");
                Datos.ejecutarLectura();
                while (Datos.Lector.Read())
                {
                    elemento aux = new elemento();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {
                Datos.cerrarConexion();

            }
        }
        public List<elemento> listar2()
        {
            List<elemento> lista = new List<elemento>();
            accesoDatos Datos = new accesoDatos();
            try
            {
                Datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                Datos.ejecutarLectura();
                while (Datos.Lector.Read())
                {
                    elemento aux = new elemento();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();

            }
        }
    }
}
