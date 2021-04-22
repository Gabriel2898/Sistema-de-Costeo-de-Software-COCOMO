using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
  public class GACC_ControladorLogin
    {

        public static DataClasses1DataContext gacc_dc = new DataClasses1DataContext();


        
        
         public static bool AutenticarCredencialPersona(string nombre, string pass)
         {
            var gacc_autenticar = gacc_dc.GACC_TblPersona.Any(usu => usu.gacc_PerUsuarioNombre.Equals(nombre) & usu.gacc_PerPassword.Equals(pass));
             return gacc_autenticar;
        }
        
        	
         public static GACC_TblPersona AutenticarLogin(string nombre, string pass)
         {
             var nlogin = gacc_dc.GACC_TblPersona.Single(usu => usu.gacc_PerUsuarioNombre.Equals(nombre) & usu.gacc_PerPassword.Equals(pass));
             return nlogin;
         }


         public static Boolean AutentificarPersona(string nombre)
         {
             var auto = gacc_dc.GACC_TblPersona.Any(usu =>  usu.gacc_PerUsuarioNombre.Equals(nombre));
             return auto;
         }
         
      
    }
}
