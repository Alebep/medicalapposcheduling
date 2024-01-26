using Controller.cache;
using Model;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controller
{
    public class UserController
    {
        UserDAO UserModel = new UserDAO();
        public bool loginUser(string user, string password)
        {
            return UserModel.login(user,password);
        }
        public void CriarCacheUser()
        {
            UsuarioDados user = UserModel.UsuarioDados();
            UserLoginCache.AdcionarDados(user.id_usuario, user.Nome, user.Sobrenome, user.id_nivel, user.nivel);
        }
        public bool Insert(string user,string passwd,int idlevel,int employee)
        {
            return UserModel.Insert(user,passwd,idlevel,employee);
        }
        public bool Alter (int id,string user, string passwd, int idlevel, int employee)
        {
            return UserModel.Alter(id,user, passwd, idlevel, employee);
        }
        public bool Delete(int id)
        {
            return UserModel.Delete(id);
        }
        public DataTable Table()
        {
            return UserModel.Table();
        }
        public string ErroMsg()
        {
            return UserModel.erro;
        }
    } 
}
