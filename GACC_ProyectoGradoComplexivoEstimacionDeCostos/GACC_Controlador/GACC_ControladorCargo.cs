using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GACC_Modelo;
using System.Threading.Tasks;

namespace GACC_Controlador
{
   public class GACC_ControladorCargo
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static List<GACC_TblCargo> ObtenerCargo()
        {
            var lista = dc.GACC_TblCargo.Where(pro =>  pro.gacc_CarEstado == 'A' || pro.gacc_CarEstado == 'I');
            return lista.ToList();
        }
        public static List<GACC_TblCargo> ObtenerCargoRegistrarse()
        {
            var lista = dc.GACC_TblCargo.Where(pro => pro.gacc_CarEstado == 'A' );
            return lista.ToList();
        }
        public static GACC_TblCargo ObtenerCargoxid(int id)
        {
            var proid = dc.GACC_TblCargo.FirstOrDefault(pro => pro.gacc_CarId.Equals(id));
            return proid;
        }

        public static GACC_TblCargo ObtenerCargoxnombre(string cedula)
        {
            var pronom = dc.GACC_TblCargo.FirstOrDefault(pro => pro.gacc_CarNombre.Equals(cedula) && pro.gacc_CarEstado == 'A');
            return pronom;
        }
      
        public static bool AutentificarCargoxnombres(string ced)
        {
            var auto = dc.GACC_TblCargo.Any(pro => pro.gacc_CarNombre.Equals(ced));
            return auto;
        }

        public static GACC_TblCargo AutentificarCargoxnombre(string ced)
        {
            //aqui devuelves objeto no bool
            //single te devulve nulo si no hay registro con ese dato
            var auto = dc.GACC_TblCargo.SingleOrDefault(pro => pro.gacc_CarNombre.Equals(ced));
            return auto;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblCargo pro)
        {
            try
            {
                pro.gacc_CarEstado = 'A';
                dc.GACC_TblCargo.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblCargo pro)
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

        public static void delete(GACC_TblCargo pro)
        {
            try
            {
                dc.GACC_TblCargo.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
