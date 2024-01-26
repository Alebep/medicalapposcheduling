using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    static class Perguntar
    {
        public static bool Fperguntar(string pergunta, string titulo)
        {
            if (MessageBox.Show(pergunta, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                return true;
            else
                return false;

        }
    }
}
