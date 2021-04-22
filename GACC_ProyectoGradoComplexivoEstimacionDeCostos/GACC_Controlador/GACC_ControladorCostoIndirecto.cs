using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public  class GACC_ControladorCostoIndirecto
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static int RetornarId()
        {
            var id = dc.GACC_TblCostoIndirecto.Max(x => x.gacc_CostId as int?) ?? 0;
            return id + 1;

        }

        public static bool AutentificarId(int ced)
        {
            var auto = dc.GACC_TblCostoIndirecto.Any(pro => pro.gacc_CostId.Equals(ced));
            return auto;
        }
        public static List<GACC_ViewCosto> ObtenerCostoIndirecto()
        {
            var lista = dc.GACC_ViewCosto.Where(pro => pro.gacc_CostEstado == 'A'|| pro.gacc_CostEstado == 'I');
            return lista.ToList();
        }
        
        public static List<GACC_TblCostoIndirecto> ObtenerProyectodls()
        {
            var lista = dc.GACC_TblCostoIndirecto;
            return lista.ToList();
        }
        public static GACC_TblCostoIndirecto ObtenerCostoIxid(int id)
        {
            var proid = dc.GACC_TblCostoIndirecto.FirstOrDefault(pro => pro.gacc_CostId.Equals(id) );
            return proid;
        }
        public static GACC_ViewCosto ObtenerCostoIxidvista(int id)
        {
            var proid = dc.GACC_ViewCosto.FirstOrDefault(pro => pro.gacc_CostId.Equals(id));
            return proid;
        }

        public static GACC_TblCostoIndirecto Autentificostoxproyecto(string cedula, int emp)
        {
            var auto = dc.GACC_TblCostoIndirecto.Single(pro => pro.gacc_CostNombre.Equals(cedula) && pro.gacc_CostNombreProyectoID.Equals(emp));
            return auto;
        }
        public static GACC_TblCostoIndirecto ObtenerCostoIxnombre(string cedula)
        {
            var pronom = dc.GACC_TblCostoIndirecto.FirstOrDefault(pro => pro.gacc_CostNombre.Equals(cedula) );
            return pronom;
        }

        public static GACC_TblCostoIndirecto ObtenerCostoIxnombreyproyecto(string cedula, int empresa)
        {
            var pronom = dc.GACC_TblCostoIndirecto.FirstOrDefault(pro =>  pro.gacc_CostNombre.Equals(cedula) && pro.gacc_CostNombreProyectoID.Equals(empresa));
            return pronom;
        }


        public static bool AutentificarCostoIxnombre(string ced)
        {
            var auto = dc.GACC_TblCostoIndirecto.Any(pro => pro.gacc_CostNombre.Equals(ced));
            return auto;
        }
        public static bool AutentificarCostoproyectocosto(int ced, string nombre)
        {
            var auto = dc.GACC_TblCostoIndirecto.Any(pro => pro.gacc_CostNombreProyectoID.Equals(ced)&&pro.gacc_CostNombre.Equals(nombre));
            return auto;
        }
        public static GACC_TblCostoIndirecto ObtenerCostoproyectonombre(int cedula, string nombre)
        {
            var pronom = dc.GACC_TblCostoIndirecto.FirstOrDefault(pro => pro.gacc_CostNombreProyectoID.Equals(cedula) && pro.gacc_CostNombre.Equals(nombre));
            return pronom;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblCostoIndirecto pro)
        {
            try
            {
                pro.gacc_CostEstado = 'A';
                dc.GACC_TblCostoIndirecto.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblCostoIndirecto pro)
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

        public static void delete(GACC_TblCostoIndirecto pro)
        {
            try
            {
                /*pro.pro_estado = 'I';
                dc.tbl_productos.InsertOnSubmit(pro);
                dc.SubmitChanges();*/
                dc.GACC_TblCostoIndirecto.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
               
            }
        }

    }
}
