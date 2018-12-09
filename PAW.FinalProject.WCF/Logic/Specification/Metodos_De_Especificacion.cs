using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAW.FinalProject.WCF.Logic.Specification
{
    public class Metodos_De_Especificacion
    {

        public DB.Category AgregarCategoria(string Categoria)
        {
            var Action = new Action.Metodos_De_Accion();
            var Result = Action.AgregarCategoria(Categoria);
            return Result;
        }

        public DB.SubCategory AgregarSubCategoria(string SubCategoria, int IdCategoria)
        {
            var Action = new Action.Metodos_De_Accion();
            var Result = Action.AgregarSubCategoria(SubCategoria, IdCategoria);
            return Result;
        }

        public DB.Category CargarCategoria()
        {
            var Action = new Action.Metodos_De_Accion();
            var Result = Action.CargarCategoria();
            return Result;
        }

        public DB.SubCategory CargarSubCategoria()
        {
            var Action = new Action.Metodos_De_Accion();
            var Result = Action.CargarSubCategoria();
            return Result;
        }


    }
}