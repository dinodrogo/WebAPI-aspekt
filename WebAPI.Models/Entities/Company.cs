using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Contact> Contact { get; set; } = new List<Contact>(); // Collection navigation containing dependents
    }
}