using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
    public class GACC_ControladorActividad
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();
        
        public static List<GACC_ViewFaseActividad3> ObtenerActividadxvvistass(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividad3.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre) && pro.gacc_ActEstado=='E');
            return lista.ToList();
        }
        public static GACC_ViewFaseActividad3 ObtenerActividadxvvistassbuscar(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividad3.FirstOrDefault(pro => pro.gacc_ActNombre.Equals(nombre));
            return lista;
        }
        public static List<GACC_ViewFaseActividadUsuarioUsuario2> ObtenerActividadxvvista(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividadUsuarioUsuario2.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static GACC_ViewFaseActividadUsuarioUsuario2 ObtenerActividadxvvistabuscar(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividadUsuarioUsuario2.FirstOrDefault(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista;
        }
        public static List<GACC_ViewFaseActividadUsuarioUsuario> ObtenerActividadxusuario(string nombre)
        {
            var lista = dc.GACC_ViewFaseActividadUsuarioUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static List<GACC_ViewFaseActividad> ObtenerActividadxvista()
        {
            var lista = dc.GACC_ViewFaseActividad.Where(pro => pro.gacc_ActEstado == 'E'||pro.gacc_ActEstado=='F');
            return lista.ToList();
        }
        public static GACC_ViewFaseActividad2 ObtenerActividadxidvista(int id)
        {
            var proid = dc.GACC_ViewFaseActividad2.FirstOrDefault(pro => pro.gacc_ActId.Equals(id));
            return proid;
        }
        public static GACC_TblActividad ObtenerActividadxid(int id)
        {
            var proid = dc.GACC_TblActividad.FirstOrDefault(pro => pro.gacc_ActId.Equals(id));
            return proid;
        }
        public static List<GACC_TblActividad> ObtenerActividaddls()
        {
            var lista = dc.GACC_TblActividad;
            return lista.ToList();
        }
        public static GACC_ViewFaseActividadUsuarioUsuario ObtenerActividadxnombre(string cedula)
        {
            var pronom = dc.GACC_ViewFaseActividadUsuarioUsuario.FirstOrDefault(pro => pro.gacc_ActNombre.Equals(cedula));
            return pronom;
        }
        public static GACC_TblActividad ObtenerActividadxnombrexfase(string cedula, int cod)
        {
            var pronom = dc.GACC_TblActividad.FirstOrDefault(pro => pro.gacc_ActNombre.Equals(cedula) && pro.gacc_CodFasId.Equals(cod));
            return pronom;
        }
        public static GACC_ViewFaseActividad ObtenerActividadxnombress(string cedula)
        {
            var pronom = dc.GACC_ViewFaseActividad.FirstOrDefault(pro => pro.gacc_ActNombre.Equals(cedula) );
            return pronom;
        }
        public static bool AutentificarActividadxnombreyfase(string ced, int cod )
        {
            var auto = dc.GACC_TblActividad.Any(pro => pro.gacc_ActNombre.Equals(ced) && pro.gacc_CodFasId.Equals(cod)  );
            return auto;
        }

        public static GACC_TblActividad AutentificaActividadxfase(int ced, string nombre)
        {

            var auto = dc.GACC_TblActividad.SingleOrDefault(pro => pro.gacc_CodFasId.Equals(ced) && pro.gacc_ActNombre.Equals(nombre));
            return auto;
        }


        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblActividad pro)
        {
            try
            {
                pro.gacc_ActEstado = 'E';
                dc.GACC_TblActividad.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblActividad pro)
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

        public static void delete(GACC_TblActividad pro)
        {
            try
            {
                dc.GACC_TblActividad.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
