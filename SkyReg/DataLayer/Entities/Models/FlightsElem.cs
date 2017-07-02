namespace DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("DefinedUserType")]
        public int? UsersTypeId { get; set; }

        [ForeignKey("Supervisors")]
        public int? Supervisor_Id { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual User User { get; set; }

        public virtual DefinedUserType DefinedUserType { get; set; }

        public virtual Supervisors Supervisors { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }

        public virtual ICollection<Parachute> Parachute { get; set; }
    }
}
