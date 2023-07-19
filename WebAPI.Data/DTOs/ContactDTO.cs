namespace WebAPI.Data.DTOs
{
    public class ContactDTO
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; } // Required foreign key property
        public int CountryId { get; set; } // Required foreign key property
    }
}
