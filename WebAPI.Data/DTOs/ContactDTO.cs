using System.ComponentModel;

namespace WebAPI.Data.DTOs
{
    public class ContactDTO
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }

        [DefaultValue(null)]
        public int? CompanyId { get; set; } // Required foreign key property
        [DefaultValue(null)]
        public int? CountryId { get; set; } // Required foreign key property
    }
}
