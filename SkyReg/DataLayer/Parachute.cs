//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    public partial class Parachute
    {
        public int Id { get; set; }
        public string IdNr { get; set; }
        public string Name { get; set; }
        public decimal? RentValue { get; set; }
        public decimal? AssemblyValue { get; set; }
    
        public virtual User User { get; set; }
        public virtual FlightsElem FlightsElem { get; set; }
    }
}
