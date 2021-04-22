using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorCedulayRuc
    {
        public static bool CedulaCorrecta(string txtCedula)
        {
            int esNumero;
            var Total = 0;
            const int longitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            if (int.TryParse(txtCedula, out esNumero) && txtCedula.Length == longitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(txtCedula[0], txtCedula[1], string.Empty));
                var digitoTres = Convert.ToInt32(txtCedula[2] + string.Empty);
                if (provincia > 0 && provincia <= 24)
                {
                    var digitoVerificador = Convert.ToInt32(txtCedula[9] + string.Empty);
                    for (var i = 0; i < coeficientes.Length; i++)
                    {
                        var valor = Convert.ToInt32(coeficientes[i] + string.Empty) * Convert.ToInt32(txtCedula[i] + string.Empty);
                        Total = valor >= 10 ? Total + (valor - 9) : Total + valor;
                    }
                    var digitoVerificadorObtenido = Total >= 10 ? (Total % 10) != 0 ? 10 - (Total % 10) : (Total % 10) : Total;
                    return digitoVerificadorObtenido == digitoVerificador;
                }
            }
            return false;
        }

        
        public static bool RucPersonaNatural(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const string establecimineto = "001";
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var personaNatural = Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24) && (personaNatural >= 0 && personaNatural < 6))
                {
                    return ruc.Substring(10, 3) == establecimineto && CedulaCorrecta(ruc.Substring(0, 10));
                }
                return false;
            }
            return false;
        }
    }
}
