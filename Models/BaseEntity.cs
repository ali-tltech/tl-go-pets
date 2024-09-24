namespace TLCAREERSCORE.Models
{
	public class BaseEntity
    {
        public string? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? UserID { get; set; }

        public string? Flexfld1 { get; set; } = string.Empty;
        public string? Flexfld2 { get; set; } = string.Empty;
        public string? Flexfld3 { get; set; } = string.Empty;
        public string? Flexfld4 { get; set; } = string.Empty;
        public string? Flexfld5 { get; set; } = string.Empty;

        public string? TransactionType { get; set; }

        public int TotalCount { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
