using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAW.FinalProject.DB;

namespace PAW.FinalProject.WCF.Logic.Repository
{
    public class Metodos_De_Repositorio
    {

        PAW_FinalProyectEntities _contexto = new PAW_FinalProyectEntities();

        public Metodos_De_Repositorio()
        {
            _contexto.Configuration.ProxyCreationEnabled = false;
            _contexto.Configuration.LazyLoadingEnabled = true;
        }

        internal DB.Category AgregarCategoria (string Categoria)
        {
            DB.Category result = new DB.Category { NameCategory = Categoria };
            return result;
        }

        internal DB.SubCategory AgregarSubCategoria(string SubCategoria)
        {
            DB.SubCategory result = new DB.SubCategory { NameSubCategory = SubCategoria };
            return result;
        }

    }
}