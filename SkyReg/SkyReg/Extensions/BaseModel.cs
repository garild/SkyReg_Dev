using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SkyReg.Extensions
{
    [XmlRoot("BaseModel")]
    [XmlInclude(typeof(UsersRole))]
    public class BaseModel
    {
        public string Login { get; set; }
        public int UserId { get; set; }
        [XmlArray("Roles")]
        [XmlArrayItem("Roles")]
        public List<UsersRole> Roles { get; set; }
    }

    public class UsersRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Value { get; set; }
        public bool Camera { get; set; }
        public bool TandemPilot { get; set; }
        public bool TandemPassenger { get; set; }
        public int SpecialType { get; set; }
    }
}
