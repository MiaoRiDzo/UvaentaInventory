//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UvaentaInventory.Resources.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int RequestID { get; set; }
        public int RequestTypeID { get; set; }
        public string EquipmentSN { get; set; }
        public int ResponsibleID { get; set; }
        public string RequestName { get; set; }
        public string Comment { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual Responsible Responsible { get; set; }
    }
}
