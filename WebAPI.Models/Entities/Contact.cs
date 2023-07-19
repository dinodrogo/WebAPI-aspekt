using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int? CompanyId { get; set; } // foreign key property
        public int? CountryId { get; set; } // foreign key property
    }
}
