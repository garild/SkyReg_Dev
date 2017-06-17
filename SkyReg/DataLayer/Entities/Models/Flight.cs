namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flight")]
    public partial class Flight
    {
        public Flight()
        {
            FlightsElem = new HashSet<FlightsElem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FlyDateTime { get; set; }

        [Required]
        [StringLength(500)]
        public string FlyNr { get; set; }

        public short FlyStatus { get; set; }

        public int Altitude { get; set; }

        public int? Airplane_Id { get; set; }

        public virtual Airplane Airplane { get; set; }

        public virtual ICollection<FlightsElem> FlightsElem { get; set; }
    }
}
