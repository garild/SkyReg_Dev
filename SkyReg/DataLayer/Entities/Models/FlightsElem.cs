namespace DataLayer
{ 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlightsElem")]
    public partial class FlightsElem
    {
        public FlightsElem()
        {
            Payment = new HashSet<Payment>();
            Parachute = new HashSet<Parachute>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? AssemblySelf { get; set; }

        public int? Lp { get; set; }

        [StringLength(500)]
        public string TeamName { get; set; }

        [StringLength(500)]
        public string Color { get; set; }

        public int? Flight_Id { get; set; }

        public int? User_Id { get; set; }

        public int? UsersTypeId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }

        public virtual ICollection<Parachute> Parachute { get; set; }
    }
}
