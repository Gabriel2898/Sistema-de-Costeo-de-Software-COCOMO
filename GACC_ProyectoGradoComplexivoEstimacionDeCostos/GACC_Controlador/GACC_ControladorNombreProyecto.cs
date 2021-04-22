using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GACC_Modelo;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public  class GACC_ControladorNombreProyecto
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

      

        public static List<GACC_ViewNombreProyectoEmpresaUsuario> ObtenerProyectoxusuario(string nombre)
        {
            var lista = dc.GACC_ViewNombreProyectoEmpresaUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }

        public static List<GACC_ViewNombreProyectoListar> ObtenerProyectoslistar()
        {
            var lista = dc.GACC_ViewNombreProyectoListar.Where(pro => pro.gacc_NompEstado == 'F'|| pro.gacc_NompEstado == 'E' );
            return lista.ToList();
        }

        public static GACC_ViewNombreProyectoListar ObtenerProyectoxnombreslistar(string cedula)
        {
            var pronom = dc.GACC_ViewNombreProyectoListar.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula));
            return pronom;
        }
        public static List<GACC_TblNombreProyecto> ObtenerProyectodls()
        {
            var lista = dc.GACC_TblNombreProyecto;
            return lista.ToList();
        }
        public static GACC_ViewNombreProyectoListar ObtenerProyectoxidvista(int id)
        {
            var proid = dc.GACC_ViewNombreProyectoListar.FirstOrDefault(pro => pro.gacc_NompId.Equals(id));
            return proid;
        }
        public static GACC_TblNombreProyecto ObtenerProyectoxid(int id)
        {
            var proid = dc.GACC_TblNombreProyecto.FirstOrDefault(pro => pro.gacc_NompId.Equals(id));
            return proid;
        }

        public static GACC_ViewNombreProyectoEmpresa ObtenerProyectoxempresa(string cedula)
        {
            var pronom = dc.GACC_ViewNombreProyectoEmpresa.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula) );
            return pronom;
        }

        public static GACC_TblNombreProyecto ObtenerProyectoxempresasynombre(string cedula, int emp)
        {
            var pronom = dc.GACC_TblNombreProyecto.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula) && pro.gacc_CodEmpId.Equals(emp));
            return pronom;
        }
        public static GACC_TblNombreProyecto Autentificoproyectoxempresa(string cedula, int emp)
        {
            var auto = dc.GACC_TblNombreProyecto.SingleOrDefault(pro => pro.gacc_NompNombre.Equals(cedula) && pro.gacc_CodEmpId.Equals(emp));
            return auto;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblNombreProyecto pro)
        {
            try
            {
                pro.gacc_NompEstado = 'E';
                dc.GACC_TblNombreProyecto.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblNombreProyecto pro)
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

        public static void delete(GACC_TblNombreProyecto pro)
        {
            try
            {
                dc.GACC_TblNombreProyecto.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
