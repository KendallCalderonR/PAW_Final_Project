using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAW.FinalProject.DB;
using System.Data;

namespace PAW.FinalProject.WCF.Logic.Repository
{
    public class Metodos_De_Repositorio
    {

        PAW_FinalProyectEntities1 _contexto = new PAW_FinalProyectEntities1();

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

        internal DB.SubCategory AgregarSubCategoria(string SubCategoria, int IdCategoria)
        {
            DB.SubCategory result = new DB.SubCategory { NameSubCategory = SubCategoria, Id_Category = IdCategoria};
            return result;
        }

        internal IList<Category> CargarCategoria()
        {
            //IList<Category> result = _contexto.Select<Category>.ToList();
            var result = _contexto.Category.ToList();
            return result;
        }

        internal IList<SubCategory> CargarSubCategoria()
        {
            IList<SubCategory> result = _contexto.SubCategory.ToList();
            return result;
        }



    }
}