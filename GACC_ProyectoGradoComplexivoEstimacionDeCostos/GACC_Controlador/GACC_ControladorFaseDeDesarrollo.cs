using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GACC_Modelo;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorFaseDeDesarrollo
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();
        public static List<GACC_ViewMetodologiaFaseUsuario2> ObtenerFasexvistaxusuario(string nombre)
        {
            var lista = dc.GACC_ViewMetodologiaFaseUsuario2.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre) && pro.gacc_FasEstado == 'E' );
            return lista.ToList();
        }
        public static GACC_ViewMetodologiaFaseUsuario2 ObtenerFasexvusuario(string nombre)
        {
            var lista = dc.GACC_ViewMetodologiaFaseUsuario2.FirstOrDefault(pro => pro.gacc_FasNombre.Equals(nombre));
            return lista;
        }

        public static List<GACC_ViewMetodologiaFase> ObtenerFasexvista()
        {
            var lista = dc.GACC_ViewMetodologiaFase.Where(pro => pro.gacc_FasEstado == 'E'||pro.gacc_FasEstado=='F');
            return lista.ToList();
        }
        
        public static List<GACC_ViewMetodologiaFaseUsuario> ObtenerFase(string nombre)
        {
            var lista = dc.GACC_ViewMetodologiaFaseUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static GACC_ViewMetodologiaFase2 ObtenerFasexidvista(int id)
        {
            var proid = dc.GACC_ViewMetodologiaFase2.FirstOrDefault(pro => pro.gacc_FasId.Equals(id));
            return proid;
        }

        public static GACC_TblFaseDeDesarrollo ObtenerFasexid(int id)
        {
            var proid = dc.GACC_TblFaseDeDesarrollo.FirstOrDefault(pro => pro.gacc_FasId.Equals(id) );
            return proid;
        }
        public static List<GACC_TblFaseDeDesarrollo> Obtenerfasedls()
        {
            var lista = dc.GACC_TblFaseDeDesarrollo;
            return lista.ToList();
        }
        public static GACC_ViewMetodologiaFaseUsuario ObtenerFasexnombre(string cedula)
        {
            var pronom = dc.GACC_ViewMetodologiaFaseUsuario.FirstOrDefault(pro => pro.gacc_FasNombre.Equals(cedula) );
            return pronom;
        }
        public static GACC_TblFaseDeDesarrollo ObtenerFasexnombress(string cedula, int cod)
        {
            var pronom = dc.GACC_TblFaseDeDesarrollo.FirstOrDefault(pro => pro.gacc_FasNombre.Equals(cedula) && pro.gacc_CodMetId.Equals(cod) );
            return pronom;
        }
        public static GACC_ViewMetodologiaFase ObtenerFasexnombrexvista(string cedula)
        {
            var pronom = dc.GACC_ViewMetodologiaFase.FirstOrDefault(pro => pro.gacc_FasNombre.Equals(cedula) );
            return pronom;
        }
        public static GACC_ViewMetodologiaFase ObtenerFasexnombreproyectoxvista(string cedula)
        {
            var pronom = dc.GACC_ViewMetodologiaFase.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula) );
            return pronom;
        }
        public static bool AutentificarFasexnombre(string ced)
        {
            var auto = dc.GACC_TblFaseDeDesarrollo.Any(pro => pro.gacc_FasNombre.Equals(ced));
            return auto;
        }
        public static bool AutentificarFasexnombress(string ced, int cedula)
        {
            var auto = dc.GACC_TblFaseDeDesarrollo.Any(pro => pro.gacc_FasNombre.Equals(ced) && pro.gacc_CodMetId.Equals(cedula));
            return auto;
        }

        public static GACC_TblFaseDeDesarrollo Autentificarfasexmetodologia(int ced, string nombre)
        {

            var auto = dc.GACC_TblFaseDeDesarrollo.SingleOrDefault(pro => pro.gacc_CodMetId.Equals(ced) && pro.gacc_FasNombre.Equals(nombre));
            return auto;
        }


        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblFaseDeDesarrollo pro)
        {
            try
            {
                pro.gacc_FasEstado = 'E';
                dc.GACC_TblFaseDeDesarrollo.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblFaseDeDesarrollo pro)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido modificados </br>" + ex.Message);
            }
        }

        public static void delete(GACC_TblFaseDeDesarrollo pro)
        {
            try
            {
                dc.GACC_TblFaseDeDesarrollo.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
