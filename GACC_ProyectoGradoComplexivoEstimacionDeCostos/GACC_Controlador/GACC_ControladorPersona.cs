using System;
using System.Collections.Generic;
using System.Linq;
using GACC_Modelo;
using System.Text;
using System.Threading.Tasks;

namespace GACC_Controlador
{
    public class GACC_ControladorPersona
    {
        public static DataClasses1DataContext dc = new DataClasses1DataContext();

        public static List<GACC_TblPersona> ObtenerPersonas(int emp)
        {
            var lista = dc.GACC_TblPersona.Where(pro => pro.gacc_CodEmpId.Equals(emp));
            return lista.ToList();
        }
        public static List<GACC_ViewPersonaCargoEmpresa> ObtenerEmpleadoxvista()
        {
            var lista = dc.GACC_ViewPersonaCargoEmpresa.Where(pro => pro.gacc_PerEstado == 'O'|| pro.gacc_PerEstado=='D');
            return lista.ToList();
        }
        public static List<GACC_ViewPersonaCargoEmpresa> ObtenerEmpleadoxnombreusuario(string nombre)
        {
            var lista = dc.GACC_ViewPersonaCargoEmpresa.Where(pro => pro.gacc_PerUsuarioNombre.Equals(nombre));
            return lista.ToList();
        }
        public static List<GACC_ViewPersona> ObtenerPersonadls()
        {
            var lista = dc.GACC_ViewPersona;
            return lista.ToList();
        }
        public static GACC_TblPersona ObtenerEmpleadoxid(int id)
        {
            var proid = dc.GACC_TblPersona.FirstOrDefault(pro => pro.gacc_PerId.Equals(id));
            return proid;
        }
        public static GACC_TblPersona ObtenerEmpleadoxnombres(string nombre1, string nombre2, string apellido1, string apellido2)
        {
            var proid = dc.GACC_TblPersona.FirstOrDefault(pro => pro.gacc_PerPrimerNombre.Equals(nombre1) && pro.gacc_PerSegundoNombre.Equals(nombre2) && pro.gacc_PerPrimerApellido.Equals(apellido1) && pro.gacc_PerSegundoApellido.Equals(apellido2));
            return proid;
        }
        public static GACC_TblPersona ObtenerEmpleadoxcedula(string cedula)
        {
            var pronom = dc.GACC_TblPersona.FirstOrDefault(pro => pro.gacc_PerDni.Equals(cedula));
            return pronom;
        }
        public static GACC_TblPersona ObtenerEmpleadoxNombreUsusario(string cedula)
        {
            var pronom = dc.GACC_TblPersona.FirstOrDefault(pro => pro.gacc_PerUsuarioNombre.Equals(cedula));
            return pronom;
        }
        public static GACC_ViewPersonaCargoEmpresa ObtenerEmpleadoxcedulaxvista(string cedula)
        {
            var pronom = dc.GACC_ViewPersonaCargoEmpresa.FirstOrDefault(pro => pro.gacc_PerDni.Equals(cedula) );
            return pronom;
        }

        public static GACC_TblPersona AutentificarPersonaxcedulas(string ced)
        {
            var auto = dc.GACC_TblPersona.SingleOrDefault(pro => pro.gacc_PerDni.Equals(ced));
            return auto;
        }
        public static GACC_TblPersona AutentificarEmpleado(string nombre1, string nombre2, string apellido1, string apellido2)
        {
            var auto = dc.GACC_TblPersona.SingleOrDefault(pro => pro.gacc_PerPrimerNombre.Equals(nombre1) && pro.gacc_PerSegundoNombre.Equals(nombre2) && pro.gacc_PerPrimerApellido.Equals(apellido1) && pro.gacc_PerSegundoApellido.Equals(apellido2));
            return auto;
        }
        public static bool AutentificarEmpleadoxcedula(string ced)
        {
            var auto = dc.GACC_TblPersona.Any(pro => pro.gacc_PerDni.Equals(ced) );
            return auto;
        }
        public static bool AutentificarUsuario(string ced)
        {
            var auto = dc.GACC_TblPersona.Any(pro => pro.gacc_PerUsuarioNombre.Equals(ced));
            return auto;
        }
        public static bool AutentificarEmpleadoxnombre(string nombre1,string nombre2, string apellido1, string apellido2)
        {
            var auto = dc.GACC_TblPersona.Any(pro => pro.gacc_PerPrimerNombre.Equals(nombre1) && pro.gacc_PerSegundoNombre.Equals(nombre2) && pro.gacc_PerPrimerApellido.Equals(apellido1) && pro.gacc_PerSegundoApellido.Equals(apellido2) );
            return auto;
        }
        public static GACC_ViewPersona AutentificarEmpleadoxnombressss(string nombre1)
        {
            var auto = dc.GACC_ViewPersona.Single(pro => pro.Nombres_Completos.Equals(nombre1) );
            return auto;
        }

        // crear metodo para modificar, crear y eliminar
        public static void save(GACC_TblPersona pro)
        {
            try
            {
                pro.gacc_PerEstado = 'D';
                dc.GACC_TblPersona.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados </br>" + ex.Message);
            }
        }

        public static void modify(GACC_TblPersona pro)
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

        public static void delete(GACC_TblPersona pro)
        {
            try
            {
                dc.GACC_TblPersona.DeleteOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido eliminados </br>" + ex.Message);
            }
        }
    }
}
