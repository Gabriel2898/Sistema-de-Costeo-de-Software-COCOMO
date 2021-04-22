using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GACC_Modelo;

namespace GACC_Controlador
{
   public  class GACC_ControladorProyectoCostoIndirecto
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();
        public static GACC_TblProyectoTblCostoIndirecto ObtenerCostoProyecto(int cedula, int nombre)
        {
            var pronom = dc.GACC_TblProyectoTblCostoIndirecto.FirstOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_CodCostId.Equals(nombre));
            return pronom;
        }

        public static bool AutentificarCostoProyecto(int ced, int nombre)
        {
            var auto = dc.GACC_TblProyectoTblCostoIndirecto.Any(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_CodCostId.Equals(nombre));
            return auto;
        }
        public static List<GACC_ViewProyectoCosto> ObtenerProyecto()
        {
            var lista = dc.GACC_ViewProyectoCosto;
            return lista.ToList();
        }
        public static GACC_TblProyectoTblCostoIndirecto ObtenerCostoIxnombreyproyecto(int cedula, int empresa)
        {
            var pronom = dc.GACC_TblProyectoTblCostoIndirecto.FirstOrDefault(pro => pro.gacc_CodCostId.Equals(cedula) && pro.gacc_CodNompId.Equals(empresa));
            return pronom;
        }

        public static GACC_TblProyectoTblCostoIndirecto Autentificostoxproyecto(int cedula, int emp)
        {
            var auto = dc.GACC_TblProyectoTblCostoIndirecto.SingleOrDefault(pro => pro.gacc_CodCostId.Equals(cedula) && pro.gacc_CodNompId.Equals(emp));
            return auto;
        }
        public static GACC_TblProyectoTblCostoIndirecto ObtenerProyectoxid(int id)
        {
            var proid = dc.GACC_TblProyectoTblCostoIndirecto.FirstOrDefault(pro => pro.gacc_ProCostId.Equals(id));
            return proid;
        }
        public static GACC_ViewProyectoCosto ObtenerCostoIxidvista(int id)
        {
            var proid = dc.GACC_ViewProyectoCosto.FirstOrDefault(pro => pro.gacc_CostId.Equals(id));
            return proid;
        }

        public static GACC_ViewProyectoCosto ObtenerCostoIxnombre(string cedula)
        {
            var pronom = dc.GACC_ViewProyectoCosto.FirstOrDefault(pro => pro.gacc_NompNombre.Equals(cedula));
            return pronom;
        }





        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblProyectoTblCostoIndirecto pro)
        {
            try
            {;
                dc.GACC_TblProyectoTblCostoIndirecto.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblProyectoTblCostoIndirecto pro)
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

        public static void delete(GACC_TblProyectoTblCostoIndirecto pro)
        {
            try
            {
                dc.GACC_TblProyectoTblCostoIndirecto.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
