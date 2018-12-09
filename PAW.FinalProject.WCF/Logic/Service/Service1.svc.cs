using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PAW.FinalProject.DB;

namespace PAW.FinalProject.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Category AgregarCategoria(string Categoria)
        {
            var Specification = new  Logic.Specification.Metodos_De_Especificacion();
            var result = Specification.AgregarCategoria(Categoria);
            return result;
        }

        public SubCategory AgregarSubCategoria(string SubCategoria, int IdCategoria)
        {
            var Specification = new Logic.Specification.Metodos_De_Especificacion();
            var result = Specification.AgregarSubCategoria(SubCategoria , IdCategoria);
            return result;
        }

        public IList<Category> CarcarCategorias()
        {
            var Specification = new Logic.Specification.Metodos_De_Especificacion();
            var result = Specification.CargarCategorias();
            return result;
        }

        public IList<SubCategory> CarcarSubCategorias()
        {
            var Specification = new Logic.Specification.Metodos_De_Especificacion();
            var result = Specification.CargarSubCategorias();
            return result;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
