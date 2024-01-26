using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Model
{
    public class UserDAO : connectionSQL
    {
        public int? idemployee, id_nivel,iduser;
        bool existe;
        public string erro = string.Empty;
        public bool login(string user, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Clinica.dbo.[user] where Usser=@user and Password=@password";
                    command.Parameters.AddWithValue("@user", user);//coloca valor da variavel c# na variavel que vai no comando sql
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;// especifica que tipo de comando esta em uso
                    SqlDataReader reader = command.ExecuteReader();//excuta o comando
                    if (reader.HasRows)// tem linhas
                    {
                        existe = true;
                        while (reader.Read())
                        {
                            try
                            {
                                idemployee = reader.GetInt32(4);
                            }
                            catch (Exception)
                            {
                                idemployee = 0;
                            }
                            id_nivel = reader.GetInt32(3);
                            iduser = reader.GetInt32(0);
                        }
                        return true;
                    }
                    else
                    {
                        existe = false;
                        return false;
                    }
                }
            }

        }

        public UsuarioDados UsuarioDados()
        {
            UsuarioDados usuario = new UsuarioDados();
            if (existe)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var commandEmployee = new SqlCommand())
                    {
                        if (idemployee != 0)
                        {
                            commandEmployee.Connection = connection;
                            commandEmployee.CommandText = "SELECT Name,Last_Name FROM [Clinica].[dbo].[employee] where Id_employee=@id_empl";
                            commandEmployee.Parameters.AddWithValue("@id_empl", idemployee);
                            SqlDataReader employye = commandEmployee.ExecuteReader();
                            while (employye.Read())
                            {
                                usuario.Nome = employye.GetString(0);
                                usuario.Sobrenome = employye.GetString(1);
                            }
                        }
                        else
                        {
                            usuario.Nome = "admin";
                            usuario.Sobrenome = "";
                        }
                    }
                }
                using (var conex2 = GetConnection())
                {
                    conex2.Open();
                    using (var commandnivel = new SqlCommand())
                    {
                        commandnivel.Connection = conex2;
                        commandnivel.CommandText = "SELECT * FROM [Clinica].[dbo].[level_acess] where id_level=@id_nivel";
                        commandnivel.Parameters.AddWithValue("@id_nivel", id_nivel);
                        SqlDataReader nivell = commandnivel.ExecuteReader();
                        while (nivell.Read())
                        {
                            usuario.nivel = nivell.GetString(1);
                            usuario.id_nivel = nivell.GetInt32(0);
                        }
                    }
                }
                usuario.id_usuario = (int)iduser;
            }
            
            return usuario; 
        }

        public bool Insert(string user,string passwd,int idlevel,int idemployee)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "INSERT INTO [dbo].[user] ([Usser],[Password],[fk_levell],[fk_employee]) VALUES(@Usser,@Password,@fk_levell,@fk_employee)";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Usser",user);
                    command.Parameters.AddWithValue("@Password",passwd);
                    command.Parameters.AddWithValue("@fk_levell",idlevel);
                    command.Parameters.AddWithValue("@fk_employee",idemployee);
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }catch(Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public bool Alter(int id,string user, string passwd, int idlevel, int idemployee)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "UPDATE [dbo].[user] SET [Usser] = @Usser,[Password] = @Password,[fk_levell] = @fk_levell,[fk_employee] = @fk_employee WHERE id_user=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@Usser", user);
                    command.Parameters.AddWithValue("@Password", passwd);
                    command.Parameters.AddWithValue("@fk_levell", idlevel);
                    command.Parameters.AddWithValue("@fk_employee", idemployee);
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "DELETE FROM [dbo].[user] WHERE id_user=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public DataTable Table()
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "SELECT [id_user],[Usser],[Password],[fk_levell],[fk_employee],concat(e.Last_Name,' ',e.Name,' ',e.Patronymic) as ФИО FROM [Clinica].[dbo].[user] as us left outer join employee as e on us.fk_employee=e.Id_employee";
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

    }//fim claa
}
