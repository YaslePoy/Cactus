//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cactus.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Collection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Collection()
        {
            this.Comment = new HashSet<Comment>();
            this.Prize = new HashSet<Prize>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CactusId { get; set; }
        public Nullable<int> ExhibitionId { get; set; }
    
        public virtual Cactus Cactus { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prize> Prize { get; set; }
    }
}
