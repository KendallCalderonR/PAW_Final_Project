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

        public DB.SubCategory AgregarSubCategoria(string SubCategoria)
        {
            var Repository = new Logic.Repository.Metodos_De_Repositorio();
            var Result = Repository.AgregarSubCategoria(SubCategoria);
            return Result;
        }
    }
}