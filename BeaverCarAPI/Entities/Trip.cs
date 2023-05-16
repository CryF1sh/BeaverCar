//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeaverCarAPI.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            this.ListPassengers = new HashSet<ListPassenger>();
        }
    
        public int id { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> DriverID { get; set; }
        public Nullable<int> CountPlace { get; set; }
        public int StatusID { get; set; }
        public int CreaterID { get; set; }
        public string StartPointLongitude { get; set; }
        public string StartPointLatitude { get; set; }
        public string EndPointLongitude { get; set; }
        public string EndPointLatitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListPassenger> ListPassengers { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
