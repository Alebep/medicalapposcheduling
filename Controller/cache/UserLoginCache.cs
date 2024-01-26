using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.cache
{
    public static class UserLoginCache
    {
        public static int IdUser { get; private set; }
        public static string Nome { get; private set; }
        public static string Sobrenome { get; private set; }
        public static int Nivel { get; private set; }
        public static string Cargo { get; private set; }
        public static int IdDoctor { get; private set; }// caso o usuario logado seja um doutor
        public static void AdcionarDados(int id,string nome,string sobrenome,int id_nivel,string nivel)
        {
            IdUser = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Nivel = id_nivel;
            Cargo = nivel;
        }
        public static void AdiconarIdDoctor(int d)
        {
            IdDoctor = d;
        }
    }
}
