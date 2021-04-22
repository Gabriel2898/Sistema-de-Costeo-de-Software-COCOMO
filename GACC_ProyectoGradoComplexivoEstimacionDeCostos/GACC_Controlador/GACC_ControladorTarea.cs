using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GACC_Modelo;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorTarea
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();
        public static List<GACC_ViewFaseActividadTarea> ObtenerTareaxvista(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividadTarea.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
       
        public static GACC_ViewActividadTareaUsuario4 ObtenerTareaxvistatodobuscar(string nombre)
        {
            var lista = dc.GACC_ViewActividadTareaUsuario4.FirstOrDefault(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista;
        }
        public static List<GACC_ViewActividadTareaUsuario4> ObtenerTareaxvistatodo(string nombre)
        {
            var lista = dc.GACC_ViewActividadTareaUsuario4.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static List<GACC_ViewActividadTareaUsuario> ObtenerTarea (string nombre)
        {
            var lista = dc.GACC_ViewActividadTareaUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static List<GACC_ViewActividadTarea> ObtenerTareaxvista()
        {
            var lista = dc.GACC_ViewActividadTarea.Where(pro => pro.gacc_TarEstado == 'E'|| pro.gacc_TarEstado=='F');
            return lista.ToList();
        }
        public static GACC_ViewFaseActividadTarea ObtenerTareavista(string id)
        {
            var proid = dc.GACC_ViewFaseActividadTarea.FirstOrDefault(pro => pro.gacc_TarNombre.Equals(id));
            return proid;
        }
        public static List<GACC_ViewActividadTareaUsuario3> ObtenerTareaxvistass(string nombre)
        {
            var lista = dc.GACC_ViewActividadTareaUsuario3.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre) && pro.gacc_TarEstado=='E');
            return lista.ToList();
        }
        public static GACC_ViewActividadTareaUsuario3 ObtenerTareavistabuscar(string id)
        {
            var proid = dc.GACC_ViewActividadTareaUsuario3.FirstOrDefault(pro => pro.gacc_TarNombre.Equals(id));
            return proid;
        }
        public static GACC_ViewActividadTarea2 ObtenerTareaxidvista(int id)
        {
            var proid = dc.GACC_ViewActividadTarea2.FirstOrDefault(pro => pro.gacc_TarId.Equals(id));
            return proid;
        }
        public static GACC_TblTarea ObtenerTareaxtabla(int id)
        {
            var proid = dc.GACC_TblTarea.FirstOrDefault(pro => pro.gacc_TarId.Equals(id));
            return proid;
        }
        public static GACC_TblTarea ObtenerTareaxid(int id)
        {
            var proid = dc.GACC_TblTarea.FirstOrDefault(pro => pro.gacc_TarId.Equals(id));
            return proid;
        }

        public static GACC_ViewActividadTarea ObtenerTareaxnombre(string cedula)
        {
            var pronom = dc.GACC_ViewActividadTarea.FirstOrDefault(pro => pro.gacc_TarNombre.Equals(cedula));
            return pronom;
        }

        public static GACC_TblTarea ObtenerTareaxnombress(string cedula, int cod)
        {
            var pronom = dc.GACC_TblTarea.FirstOrDefault(pro => pro.gacc_TarNombre.Equals(cedula) &&  pro.gacc_CodActId.Equals(cod));
            return pronom;
        }
        public static GACC_ViewActividadTareaUsuario ObtenerTareaxnombreusuario(string cedula)
        {
            var pronom = dc.GACC_ViewActividadTareaUsuario.FirstOrDefault(pro => pro.gacc_TarNombre.Equals(cedula));
            return pronom;
        }
        public static GACC_TblTarea AutentificarTareaxacividad(int ced, string nombre)
        {

            var auto = dc.GACC_TblTarea.SingleOrDefault(pro => pro.gacc_CodActId.Equals(ced) && pro.gacc_TarNombre.Equals(nombre));
            return auto;
        }


        public static bool AutentificarTareaxnombress(string ced, int cod)
        {
            var auto = dc.GACC_TblTarea.Any(pro => pro.gacc_TarNombre.Equals(ced) && pro.gacc_CodActId.Equals(cod));
            return auto;
        }
        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblTarea pro)
        {
            try
            {
                pro.gacc_TarEstado = 'E';
                dc.GACC_TblTarea.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblTarea pro)
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

        public static void delete(GACC_TblTarea pro)
        {
            try
            {
                dc.GACC_TblTarea.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
