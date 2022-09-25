
using Prototype_SGPT.Models;
//se descarga una libreria sqlClient para el uso de las siguientes librerias
using System.Data.SqlClient;
using System.Data;

namespace Prototype_SGPT.Logic{
    public class LogicDbApplication
    {

        //metodo que verificara que el nombre de usuario y el id coincida con los datos de la base de datos
        public User EncontrarUsuario(string userName, string id)
        {
            User objeto = null;

            using(SqlConnection conexion = new SqlConnection("Data source=(local) ; Initial Catalog=SGPT_Prototype; Integrated Security=true"))
            {
                //creamos un query que buscara a un usuario
                string query = "select pk_id,nombre,apellido,telefono,email,contrasena,userName from usuarios where userName=@puserName and pk_id=@pid";
                
                //creamos un sqlCommand que se encargara de todo el trabajo de ejecucion para sql
                //en este caso ejecutara el query creado
                SqlCommand cmd = new SqlCommand(query, conexion);

                //mandamos los parametros correspondietes al query que recibimos por el metodo
                cmd.Parameters.AddWithValue("puserName", userName);
                cmd.Parameters.AddWithValue("pid", id);

                //le decimos al comando que se ejecute (de modo de texto)
                cmd.CommandType = CommandType.Text;

                //abrimos la conexion para que se ejecute el comando
                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        objeto = new User()
                        {
                            //la variable Nombre va a ser igual a la columna Nombres que lea el dataReader y lo convertimos en un string
                            name = dr["nombre"].ToString(),
                            lastName = dr["apellido"].ToString(),
                            phoneNumber = dr["telefono"].ToString(),
                            email = dr["email"].ToString(),
                            id = dr["pk_id"].ToString(),
                            password = dr["contrasena"].ToString(),
                            userName = dr["userName"].ToString()
                        };
                    }
                }

            }

            return objeto;

        }//encontrarUusuario

    } //class

} //final
