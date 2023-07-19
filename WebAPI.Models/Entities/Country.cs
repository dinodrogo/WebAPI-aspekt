using System.ComponentModel.DataAnnotations;


namespace WebAPI.Models.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<Contact> Contact { get; set; } = new List<Contact>(); // Collection navigation containing dependents
    }
}
