namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            FlightsElem = new HashSet<FlightsElem>();
            Operator = new HashSet<Operator>();
            Order = new HashSet<Order>();
            Parachute = new HashSet<Parachute>();
            Payment = new HashSet<Payment>();
            DefinedUserType = new HashSet<DefinedUserType>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Login { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public string Certificate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? CertDate { get; set; }

        [StringLength(500)]
        public string SurveyNr { get; set; }

        [Column(TypeName ="Date")]
        public DateTime? SurveyExpirateDate { get; set; }

        [StringLength(500)]
        public string City { get; set; }

        [StringLength(500)]
        public string ZipCode { get; set; }

        [StringLength(500)]
        public string Street { get; set; }

        [StringLength(500)]
        public string StreetNr { get; set; }

        [StringLength(500)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string FaceBook { get; set; }

        [StringLength(500)]
        public string InsuranceNr { get; set; }

        [Column(TypeName ="Date")]
        public DateTime InsuranceExpire { get; set; }


        public int? Group_Id { get; set; }

        public virtual ICollection<FlightsElem> FlightsElem { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Operator> Operator { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual ICollection<Parachute> Parachute { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }

        public virtual ICollection<DefinedUserType> DefinedUserType { get; set; }
    }
}
