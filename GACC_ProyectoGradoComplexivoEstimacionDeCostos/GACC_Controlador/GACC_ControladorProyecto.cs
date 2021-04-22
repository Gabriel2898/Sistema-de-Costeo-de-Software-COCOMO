using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
     public class GACC_ControladorProyecto
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static GACC_TblProyecto BuscarProyecto(int id)
        {
            var resultado = dc.GACC_TblProyecto.SingleOrDefault(x => x.gacc_CodNompId == id);
            return resultado;
        }
        public static List<GACC_ViewTablaProyecto> ObtenerProyecto()
        {
            var lista = dc.GACC_ViewTablaProyecto.Where(pro => pro.gacc_ProEstado == 'A'|| pro.gacc_ProEstado=='I');
            return lista.ToList();
        }
        public static List<GACC_ViewTablaProyecto3> ObtenerProyectolider(string nombre)
        {
            var lista = dc.GACC_ViewTablaProyecto3.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static GACC_ViewTablaProyecto2 ObtenerProyectoxidvista(int id)
        {
            var proid = dc.GACC_ViewTablaProyecto2.FirstOrDefault(pro => pro.gacc_ProId.Equals(id) );
            return proid;
        }

        public static GACC_TblProyecto ObtenerProyectoxid(int id)
        {
            var proid = dc.GACC_TblProyecto.FirstOrDefault(pro => pro.gacc_ProId.Equals(id) );
            return proid;
        }

        public static GACC_ViewTablaProyecto ObtenerProyectoxnombre(string cedula)
        {
            var pronom = dc.GACC_ViewTablaProyecto.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula) );
            return pronom;
        }
        public static GACC_ViewTablaProyecto3 ObtenerProyectoxnombrelider(string cedula, string nombre)
        {
            var pronom = dc.GACC_ViewTablaProyecto3.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula)&&pro.gacc_PerUsuarioNombre.Equals(nombre));
            return pronom;
        }
        public static GACC_TblProyecto Obtengolineascodigo(int cedula, int nombre)
        {
            var pronom = dc.GACC_TblProyecto.FirstOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_ProLineasCodigo.Equals(nombre));
            return pronom;
        }
        public static GACC_TblProyecto ObtenerProyectoxnombreyempresa(int cedula, int empresa)
        {
            var pronom = dc.GACC_TblProyecto.FirstOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_CodEmpId.Equals(empresa));
            return pronom;
        }


        public static bool AutentificarProyectoxnombre(string ced)
        {
            var auto = dc.GACC_TblProyecto.Any(pro => pro.gacc_CodNompId.Equals(ced));
            return auto;
        }

        public static bool AutentificarProyectoxnombreyempresa(int ced,int empresa)
        {
            var auto = dc.GACC_ViewTablaProyecto2.Any(pro => pro.gacc_NompId.Equals(ced) && pro.gacc_EmpId.Equals(empresa));
            return auto;
        }
        public static GACC_TblProyecto Autentificarproyectoempresa(int ced, int nombre)
        {

            var auto = dc.GACC_TblProyecto.SingleOrDefault(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_CodEmpId.Equals(nombre));
            return auto;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblProyecto pro)
        {
            try
            {
                pro.gacc_ProEstado = 'A';
                dc.GACC_TblProyecto.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblProyecto pro)
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

        public static void delete(GACC_TblProyecto pro)
        {
            try
            {
                dc.GACC_TblProyecto.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
