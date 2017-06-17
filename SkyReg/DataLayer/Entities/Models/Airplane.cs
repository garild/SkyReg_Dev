namespace DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Airplane")]
    public partial class Airplane
    {
        public Airplane()
        {
            Flight = new HashSet<Flight>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string RegNr { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int Seats { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }
    }
}
