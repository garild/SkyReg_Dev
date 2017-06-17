namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GlobalSetting")]
    public partial class GlobalSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public TimeSpan? TimeBefore { get; set; }

        public TimeSpan? TimeAfter { get; set; }

        public string AirportsName { get; set; }

        public short? CertExpired { get; set; }

        public string CountPerHour { get; set; }

        public decimal? CamPrice { get; set; }
    }
}
