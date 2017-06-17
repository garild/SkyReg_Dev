namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentsSetting")]
    public partial class PaymentsSetting
    {
        public PaymentsSetting()
        {
            Payment = new HashSet<Payment>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short Type { get; set; }

        public decimal? Value { get; set; }

        public decimal? Count { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
