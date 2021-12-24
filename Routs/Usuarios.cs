using appapi.Models;
using appapi.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Routs
{
    public class Usuarios : Conexion
    {
        public List<User> GetUsers()
        {
            List<User> usuarios = new List<User>();
            SqlCommand command = new SqlCommand("EXECUTE SelectAllUt0000", OpenServer());

            SqlDataReader registros = command.ExecuteReader();

            while (registros.Read())
            {
                User item = new User
                {
                    Clave = registros["ut0001"].ToString(),
                    Nombre = registros["ut0002"].ToString(),
                    ApellidoP = registros["ut0003"].ToString(),
                    ApellidoM = registros["ut0004"].ToString(),
                    Perfil = registros["rt0011"].ToString(),
                    Estatus = registros["ut0006"].ToString(),
                };

                usuarios.Add(item);
            }
            CloseServer().Close();
            return usuarios;
        }

        public User GetUser(string key)
        {
            SqlCommand command = new SqlCommand("EXECUTE SelectOneUt0000 @ut0001 = @key", OpenServer());

            command.Parameters.Add("@key", SqlDbType.VarChar);
            command.Parameters["@key"].Value = key;
            SqlDataReader registro = command.ExecuteReader();

            User user = new User();

            if (registro.Read())
            {
                user.Clave = registro["ut0001"].ToString();
                user.Nombre = registro["ut0002"].ToString();
                user.ApellidoP = registro["ut0003"].ToString();
                user.ApellidoM = registro["ut0004"].ToString();
                user.Perfil = registro["rt0011"].ToString();
                user.Estatus = registro["ut0006"].ToString();
            }

            CloseServer().Close();

            return user;
        }
        
        public int UpdateUser(User user)
        {

            SqlCommand command = new SqlCommand("UPDATE dbo.ut0000 SET ut0006 = @status, rt0011 = @perfil, ut0004 = @apellidom, ut0003 = @apellidop, " +
                "ut0002 = @nombre WHERE ut0001 = @clave", OpenServer());

            command.Parameters.Add("@nombre", SqlDbType.VarChar);
            command.Parameters.Add("@apellidop", SqlDbType.VarChar);
            command.Parameters.Add("@apellidom", SqlDbType.VarChar);
            command.Parameters.Add("@perfil", SqlDbType.VarChar);
            command.Parameters.Add("@status", SqlDbType.VarChar);
            command.Parameters.Add("@clave", SqlDbType.VarChar);

            command.Parameters["@nombre"].Value = user.Nombre;
            command.Parameters["@apellidop"].Value = user.ApellidoP;
            command.Parameters["@apellidom"].Value = user.ApellidoM;
            command.Parameters["@perfil"].Value = user.Perfil;
            command.Parameters["@status"].Value = user.Estatus;
            command.Parameters["@clave"].Value = user.Clave;

            int resp = command.ExecuteNonQuery();

            CloseServer().Close();

            return resp;
        }
        public int AddUser(User user)
        {

            SqlCommand command = new SqlCommand("INSERT INTO dbo.ut0000([ut0001], [ut0002], [ut0003], [ut0004], [rt0011], [ut0006]) " +
                " VALUES (@clave, @nombre, @apellidop, @apellidom, @perfil, @status)", OpenServer());

            command.Parameters.Add("@nombre", SqlDbType.VarChar);
            command.Parameters.Add("@apellidop", SqlDbType.VarChar);
            command.Parameters.Add("@apellidom", SqlDbType.VarChar);
            command.Parameters.Add("@perfil", SqlDbType.VarChar);
            command.Parameters.Add("@status", SqlDbType.VarChar);
            command.Parameters.Add("@clave", SqlDbType.VarChar);

            command.Parameters["@clave"].Value = user.Clave;
            command.Parameters["@nombre"].Value = user.Nombre;
            command.Parameters["@apellidop"].Value = user.ApellidoP;
            command.Parameters["@apellidom"].Value = user.ApellidoM;
            command.Parameters["@perfil"].Value = user.Perfil;
            command.Parameters["@status"].Value = user.Estatus;

            int resp = command.ExecuteNonQuery();

            CloseServer().Close();

            return resp;
        }
    }
}
