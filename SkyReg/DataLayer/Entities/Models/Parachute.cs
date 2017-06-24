namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parachute")]
    public partial class Parachute
    {
        public Parachute()
        {
            FlightsElem = new HashSet<FlightsElem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string IdNr { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? RentValue { get; set; }

        public decimal? AssemblyValue { get; set; }

        public int? User_Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<FlightsElem> FlightsElem { get; set; }
    }
}
