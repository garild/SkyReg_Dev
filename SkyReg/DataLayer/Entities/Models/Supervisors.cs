using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer
{
    [Table("Supervisors")]
    public class Supervisors
    {
        public Supervisors()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        [Index("IX_UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string CertificateNr { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime CertificateExpirateDate { get; set; }

        [Required]
        [StringLength(500)]
        public string SurveyNr { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime SurveyExpirateDate { get; set; }

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool IsUpToDate =>  CertificateExpirateDate.Date >= DateTime.Now && SurveyExpirateDate.Date >= DateTime.Now? true : false;
       
    }

}

