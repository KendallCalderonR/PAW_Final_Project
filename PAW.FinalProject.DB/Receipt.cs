//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAW.FinalProject.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        public int ID_receipt { get; set; }
        public Nullable<int> Id_User { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
