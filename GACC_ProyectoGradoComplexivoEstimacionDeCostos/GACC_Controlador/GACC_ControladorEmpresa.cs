using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorEmpresa
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static List<GACC_TblEmpresa> ObtenerEmpresa()
        {
            var lista = dc.GACC_TblEmpresa.Where(pro => pro.gacc_EmpEstado == 'A' || pro.gacc_EmpEstado == 'I');
            return lista.ToList();
        }
        public static List<GACC_TblEmpresa> ObtenerEmpresaddls()
        {
            var lista = dc.GACC_TblEmpresa.Where(pro => pro.gacc_EmpEstado == 'A' );
            return lista.ToList();
        }

        public static List<GACC_ViewEmpresaNombreUsuario> ObtenerEmpresaxvisatanombreusuario(string nombre)
        {
            var lista = dc.GACC_ViewEmpresaNombreUsuario.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }


        public static GACC_TblEmpresa ObtenerEmpresaxid(int id)
        {
            var proid = dc.GACC_TblEmpresa.FirstOrDefault(pro => pro.gacc_EmpId.Equals(id) );
            return proid;
        }

        public static GACC_TblEmpresa ObtenerEmpresaxruc(string cedula)
        {
            var pronom = dc.GACC_TblEmpresa.FirstOrDefault(pro => pro.gacc_EmpRuc.Equals(cedula) );
            return pronom;
        }
        public static GACC_TblEmpresa ObtenerEmpresaxnombres(string nombre1)
        {
            var pronom = dc.GACC_TblEmpresa.FirstOrDefault(pro => pro.gacc_EmpNombre.Equals(nombre1) );
            return pronom;
        }
     

        public static bool AutentificarEmpresaxnombre(string ced)
        {
            var auto = dc.GACC_TblEmpresa.Any(pro => pro.gacc_EmpNombre.Equals(ced));
            return auto;
        }
        public static bool AutentificarEmpresaxruc(string ced)
        {
            var auto = dc.GACC_TblEmpresa.Any(pro => pro.gacc_EmpRuc.Equals(ced));
            return auto;
        }
      

        public static GACC_TblEmpresa AutentificarEmpresaxnombres(string ced)
        {
            var auto = dc.GACC_TblEmpresa.SingleOrDefault(pro => pro.gacc_EmpNombre.Equals(ced));
            return auto;
        }
        public static GACC_TblEmpresa AutentificarEmpresaxrucs(string ced)
        {
            var auto = dc.GACC_TblEmpresa.SingleOrDefault(pro => pro.gacc_EmpRuc.Equals(ced));
            return auto;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblEmpresa pro)
        {
            try
            {
                pro.gacc_EmpEstado = 'A';
                dc.GACC_TblEmpresa.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblEmpresa pro)
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

        public static void delete(GACC_TblEmpresa pro)
        {
            try
            {
                dc.GACC_TblEmpresa.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
