using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorMetodologia
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();
        public static List<GACC_ViewMetodologiaPersonaNombreProy> ObtenerMetodologiaxvista()
        {
            var lista = dc.GACC_ViewMetodologiaPersonaNombreProy.Where(pro => pro.gacc_MetEstado == 'E'||pro.gacc_MetEstado=='F');
            return lista.ToList();
        }

        public static List<GACC_ViewMetodologiaPersonaUsuario> ObtenerMetodologiausuario(string nombre)
        {
            var lista = dc.GACC_ViewMetodologiaPersonaUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }

        public static GACC_ViewMetodologiaPersonaNombreProy2 ObtenerMetodologiaxidyvista(int id)
        {
            var proid = dc.GACC_ViewMetodologiaPersonaNombreProy2.FirstOrDefault(pro => pro.gacc_MetId.Equals(id));
            return proid;
        }
        public static List<GACC_TblMetodologia> ObtenerMetodologiadls()
        {
            var lista = dc.GACC_TblMetodologia;
            return lista.ToList();
        }
        public static List<GACC_TblMetodologia> ObtenerMetodologiadlss(int nombre)
        {
            var lista = dc.GACC_TblMetodologia.Where(pro=> pro.gacc_CodNompId.Equals(nombre));
            return lista.ToList();
        }
        public static GACC_TblMetodologia ObtenerMetodologiaxid(int id)
        {
            var proid = dc.GACC_TblMetodologia.FirstOrDefault(pro => pro.gacc_MetId.Equals(id));
            return proid;
        }
        public static GACC_TblMetodologia ObtenerMetodologiaxiddd(int id)
        {
            var proid = dc.GACC_TblMetodologia.FirstOrDefault(pro => pro.gacc_MetId.Equals(id));
            return proid;
        }

        public static GACC_ViewMetodologiaPersonaUsuario ObtenerMetodologiausuariobuscar(string nombre)
        {
            var lista = dc.GACC_ViewMetodologiaPersonaUsuario.FirstOrDefault(pro => pro.gacc_MetNombre.Equals(nombre));
            return lista;
        }


        public static GACC_ViewMetodologiaPersonaNombreProy ObtenerMetodologiaxnombrexvista(string cedula)
        {
            var pronom = dc.GACC_ViewMetodologiaPersonaNombreProy.FirstOrDefault(pro => pro.gacc_MetNombre.Equals(cedula));
            return pronom;
        }
        
        public static GACC_TblMetodologia ObtenerMetodologiaxnombreynombreproyectoproyecto(int cedula, string nombre)
        {
            var pronom = dc.GACC_TblMetodologia.FirstOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_MetNombre.Equals(nombre));
            return pronom;
        }
        public static bool AutentificarMetodologiaxnombreproyecto(int ced, string nombre)
        {
            var auto = dc.GACC_TblMetodologia.Any(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_MetNombre.Equals(nombre));
            return auto;
        }
        public static GACC_TblMetodologia AutentificarMetodologiaxnombreproyectoss(int ced, string nombre)
        {

            var auto = dc.GACC_TblMetodologia.SingleOrDefault(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_MetNombre.Equals(nombre));
            return auto;
        }


        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblMetodologia pro)
        {
            try
            {
                pro.gacc_MetEstado = 'E';
                dc.GACC_TblMetodologia.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblMetodologia pro)
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

        public static void delete(GACC_TblMetodologia pro)
        {
            try
            {
                dc.GACC_TblMetodologia.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
