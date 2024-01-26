using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using UtilitariosClasseFrNet;
using Verificar_se_tem_letras_em_russo_ou_lantina;


namespace ModuloDeRegistroClinica_mostrar0
{
    public class Uteis
    {
        Russo russo = new Russo();
        Ingles ingles = new Ingles();
        public string NomeDentrosPadroes(ref PictureBox picture, string campo, ref string msg, ref bool t, string msgError)
        {
            if (!ingles.contemLetrasLatinas(campo) && !Utilitarios.VerificarSeTemNumero(campo))
            {
                picture.Visible = false;
                msg = null;
                return Utilitarios.SoPrimeiraLetraMaiuscula(campo);
            }
            else
            {
                picture.Visible = true;
                if (campo != string.Empty)
                    msg = msgError;
                t = true;
                return string.Empty;
            }
        }

        public int ConverterDiaDaSemanaEmChaveDaBD(string dayOfWeek)
        {
            int idDay=0;
            switch (dayOfWeek)
            {
                case "Sunday": idDay = 1; break;
                case "Monday": idDay = 2; break;
                case "Tuesday": idDay = 3; break;
                case "Wednesday": idDay = 4; break;
                case "Thursday": idDay = 5; break;
                case "Friday": idDay = 6; break;
                case "Saturday": idDay = 7; break;
                default:
                    break;
            }
            return idDay;
        }
        /*if (!ingles.contemLetrasLatinas(metroTxbLastName.Text) && !Utilitarios.VerificarSeTemNumero(metroTxbLastName.Text))
            {
                patient.LastName = Utilitarios.SoPrimeiraLetraMaiuscula(metroTxbLastName.Text);
                pictureBoxLastName.Visible = false;
            }
            else
            {
                pictureBoxLastName.Visible = true;
                msg += "ф:Толко латинскиий буква и нельзя номер;";
            }*/
        internal void MeterErrosNaMsg(ref string msg,string[] vetor)
        {
            if (vetor[1] != null)
                vetor[0] = vetor[1];
            if (vetor[2] != null)
                vetor[0] = vetor[2];
            vetor[1] = null;
            vetor[2] = null;
            if (vetor[0] != string.Empty)
                msg = vetor[0];
            for (int i = 0; i < vetor.Length; i++)
            {
                if (vetor[i] != null && i>0)
                    msg += "\n" + vetor[i];
            }
        }
        internal bool MeterErrosApr(ref string msg, string[] vetor)
        {
            if (vetor[0] != null)
            {
                msg = vetor[0];
                return false;
            }
            else if (vetor[1] != null)
            {
                msg = vetor[1];
                return false;
            }
            else if (vetor[2] != null)
            {
                msg = vetor[2];
                return false;
            }
            else if (vetor[3] != null)
            {
                msg = vetor[3];
                return false;
            }
            else if (vetor[4] != null)
            {
                msg = vetor[4];
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
