namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefinedUserType")]
    public partial class DefinedUserType
    {
        public DefinedUserType()
        {
            User = new HashSet<User>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Value { get; set; }

        public bool IsCam { get; set; }

        public virtual ICollection<User> User { get; set; }

    }
}
