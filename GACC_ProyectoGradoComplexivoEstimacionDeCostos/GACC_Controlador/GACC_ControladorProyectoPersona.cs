using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
    public class GACC_ControladorProyectoPersona
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static List<GACC_TblProyectoTblPersona> ObtenerProyecto()
        {
            var lista = dc.GACC_TblProyectoTblPersona;

            return lista.ToList();
        }

        public static GACC_TblProyectoTblPersona ObtenerProyectoxid(int id)
        {
            var proid = dc.GACC_TblProyectoTblPersona.FirstOrDefault(pro => pro.gacc_ProPerId.Equals(id) );
            return proid;
        }
        public static GACC_ViewPersonaProyecto ObtenerProyectoxidddls(int id)
        {
            var proid = dc.GACC_ViewPersonaProyecto.FirstOrDefault(pro => pro.gacc_ProPerId.Equals(id));
            return proid;
        }

        public static List<GACC_ViewPersonaProyecto> ObtenerProyectoslistar()
        {
            var lista = dc.GACC_ViewPersonaProyecto;
            return lista.ToList();
        }
        public static List<GACC_ViewPersonaProyecto> ObtenerProyectoxnombreslistar(string cedula)
        {
            var pronom = dc.GACC_ViewPersonaProyecto.Where(pro => pro.gacc_NompNombre.Equals(cedula));
            return pronom.ToList();
        }

        public static GACC_TblProyectoTblPersona Autentificopersonaproyecto(int cedula, int emp)
        {
            var auto = dc.GACC_TblProyectoTblPersona.SingleOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_CodPerId.Equals(emp));
            return auto;
        }
        public static GACC_TblProyectoTblPersona AutentificarPersonaProyect(int ced, int nombre)
        {
            var auto = dc.GACC_TblProyectoTblPersona.SingleOrDefault(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_CodPerId.Equals(nombre));
            return auto;
        }
        public static bool AutentificarPersonaProyecto(int ced, int nombre)
        {
            var auto = dc.GACC_TblProyectoTblPersona.Any(pro => pro.gacc_CodNompId.Equals(ced) && pro.gacc_CodPerId.Equals(nombre));
            return auto;
        }
        public static GACC_TblProyectoTblPersona ObtenerPersonaProyecto(int cedula, int nombre)
        {
            var pronom = dc.GACC_TblProyectoTblPersona.FirstOrDefault(pro => pro.gacc_CodNompId.Equals(cedula) && pro.gacc_ProPerId.Equals(nombre));
            return pronom;
        }


        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblProyectoTblPersona pro)
        {
            try
            {
                dc.GACC_TblProyectoTblPersona.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblProyectoTblPersona pro)
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

        public static void delete(GACC_TblProyectoTblPersona pro)
        {
            try
            {
                dc.GACC_TblProyectoTblPersona.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
