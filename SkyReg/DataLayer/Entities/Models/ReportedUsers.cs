using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer.Models
{
    [Table("ReportedUsers")]
    public class ReportedUsers
    {
        public ReportedUsers()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string ReportByUser { get; set; }

        [ForeignKey("User")]
        public int? User_Id { get; set; }
        
        public User User { get; set; }

    }
       
       
}
