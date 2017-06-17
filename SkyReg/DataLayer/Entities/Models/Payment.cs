namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public decimal? Count { get; set; }

        public bool? IsBooked { get; set; }

        public DateTime? Date { get; set; }

        public int PaymentsSetting_Id { get; set; }

        public int User_Id { get; set; }

        public int? FlightsElem_Id { get; set; }

        public virtual FlightsElem FlightsElem { get; set; }

        public virtual PaymentsSetting PaymentsSetting { get; set; }

        public virtual User User { get; set; }
    }
}
