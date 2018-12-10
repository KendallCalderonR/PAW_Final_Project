using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAW.FinalProject.WCF.Logic.Action
{
    public class Metodos_De_Accion
    {

        public DB.Category AgregarCategoria(string Categoria)
        {
            var Repository = new Logic.Repository.Metodos_De_Repositorio();
            var Result = Repository.AgregarCategoria(Categoria);
            return Result;
        }

        public DB.SubCategory AgregarSubCategoria(string SubCategoria, int IdCategoria)
        {
            var Repository = new Logic.Repository.Metodos_De_Repositorio();
            var Result = Repository.AgregarSubCategoria(SubCategoria, IdCategoria);
            return Result;
        }

        public IList<DB.Category> CargarCategoria()
        {
            var Repository = new Logic.Repository.Metodos_De_Repositorio();
            var Result = Repository.CargarCategoria();
            return Result;
        }

        public IList<DB.SubCategory> CargarSubCategoria()
        {
            var Repository = new Logic.Repository.Metodos_De_Repositorio();
            var Result = Repository.CargarSubCategoria();
            return Result;
        }
    }
}