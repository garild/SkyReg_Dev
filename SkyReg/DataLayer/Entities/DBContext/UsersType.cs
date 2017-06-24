using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.DBContext
{
    [Table("UsersTypes")]
    public partial class UsersTypes
    {
        public UsersTypes()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? DefinedUserType_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? User_Id { get; set; }

    }
}