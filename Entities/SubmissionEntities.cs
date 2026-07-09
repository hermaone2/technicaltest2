using Shared.Common.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Common.Entities
{
    public class SubmissionProduct
    {
        [Key]
        public Guid Id { get; set; }
    }

    [Table("DataPengajuanVA", Schema = "Submissions")]
    public class VASubmission : AuditableEntity
    {
        [Required]
        [Column("SubmissionProductId")]
        public Guid SubmissionProductId { get; set; }

        [ForeignKey("SubmissionProductId")]
        [JsonIgnore]
        public SubmissionProduct SubmissionProduct { get; set; } = null!;

        #region "Product Related"
        [Column("NorefProduct", TypeName = "nvarchar(100)")]
        public string? NorefProduct { get; set; } = string.Empty;

        [Column("ProductName", TypeName = "nvarchar(100)")]
        public string? ProductName { get; set; } = string.Empty;

        [Column("ProductCode")]
        public string? ProductCode { get; set; } = string.Empty;
        #endregion

        [MaxLength(100)]
        [Column("SubmissionTypeEx")]
        public string? SubmissionTypeEx { get; set; } = string.Empty;

        [Column("CompanyName")]
        public string? CompanyName { get; set; } = string.Empty;

        [Column("CompanyCode")]
        public string? CompanyCode { get; set; } = string.Empty;

        [Column("CorporateId")]
        public string? CorporateId { get; set; } = string.Empty;

        [Column("CompanyCustomerNumber")]
        public string? CompanyCustomerNumber { get; set; } = string.Empty;

        [Column("CustomerType")]
        public string? CustomerType { get; set; } = string.Empty;

        [Column("CooperationType")]
        public string? CooperationType { get; set; } = string.Empty;

        [Column("CompanyType")]
        public string? CompanyType { get; set; } = string.Empty;

        [Column("CompanyWeb")]
        public string? CompanyWeb { get; set; } = string.Empty;

        [Column("BranchName")]
        public string? BranchName { get; set; } = string.Empty;

        [Column("BranchCode")]
        public string? BranchCode { get; set; } = string.Empty;

        [Column("BusinessUnit")]
        public string? BusinessUnit { get; set; } = string.Empty;

        [Column("Address")]
        public string? Address { get; set; } = string.Empty;

        [Column("OtherAddress")]
        public string? OtherAddress { get; set; } = string.Empty;

        [Column("City")]
        public string? City { get; set; } = string.Empty;

        [Column("PostalCode")]
        public string? PostalCode { get; set; } = string.Empty;

        #region "Verification Related"
        [Column("SubmissionVerificationStatusOPR")]
        public string? SubmissionVerificationStatusOPR { get; set; } = string.Empty;

        [Column("SubmissionVerificationStatusSPV")]
        public string? SubmissionVerificationStatusSPV { get; set; } = string.Empty;

        [Column("OPRDescriptionSubmissionVerification")]
        public string? OPRDescriptionSubmissionVerification { get; set; } = string.Empty;

        [Column("SPVDescriptionSubmissionVerification")]
        public string? SPVDescriptionSubmissionVerification { get; set; } = string.Empty;
        #endregion

        [Column("VatCollector")]
        public string? VatCollector { get; set; } = string.Empty;

        [Column("BusinessSector")]
        public string? BusinessSector { get; set; } = string.Empty;

        [Column("FormBusinessSector")]
        public string? FormBusinessSector { get; set; } = string.Empty; 

        [Column("AvgTransaction")]
        public string? AvgTransaction { get; set; } = string.Empty;

        [Column("HighestTransaction")]
        public string? HighestTransaction { get; set; } = string.Empty;

        [Column("FeePerTransaction")]
        public string? FeePerTransaction { get; set; } = string.Empty;

        [Column("AdditionalInformation")]
        public string? AdditionalInformation { get; set; } = string.Empty;

        [Column("ReconciliationType")]
        public string? ReconciliationType { get; set; } = string.Empty;
        
        [Column("SettlementType")]
        public string? SettlementType { get; set; } = string.Empty;
        
        [Column("BatchSchedule")]
        public string? BatchSchedule { get; set; } = string.Empty;
        
        [Column("DropdownBatchSchedule")]
        public string? DropdownBatchSchedule { get; set; } = string.Empty;
        
        [Column("MultiSettlement")]
        public string? MultiSettlement { get; set; } = string.Empty;
        
        [Column("MultiBill")]
        public string? MultiBill { get; set; } = string.Empty;
        
        [Column("TransferProtection")]
        public string? TransferProtection { get; set; } = string.Empty;
        
        [Column("NotificationType")]
        public string? NotificationType { get; set; } = string.Empty;

        [Column("TransactionStartTime")]
        public string? TransactionStartTime { get; set; } = string.Empty;

        [Column("TransactionEndTime")]
        public string? TransactionEndTime { get; set; } = string.Empty;

        [Column("TransactionTime")]
        public string? TransactionTime { get; set; } = string.Empty;

        [Column("AreaProtection")]
        public string? AreaProtection { get; set; } = string.Empty;

        [Column("SwitcherId")]
        public string? SwitcherId { get; set; } = string.Empty;

        [Column("Switcher")]
        public string? Switcher { get; set; } = string.Empty;

        [Column("ReportingParty")]
        public string? ReportingParty { get; set; } = string.Empty;

        [Column("ReportingPartyType")]
        public string? ReportingPartyType { get; set; } = string.Empty;

        [Column("WsidSwitcher")]
        public string? WsidSwitcher { get; set; } = string.Empty;

        [Column("SwitcherAccount")]
        public string? SwitcherAccount { get; set; } = string.Empty;

        [Column("TaxSwitcher")]
        public string? TaxSwitcher { get; set; } = string.Empty;

        [Column("VatSwitcher")]
        public string? VatSwitcher { get; set; } = string.Empty;

        [Column("FundingSourceInformation")]
        public string? FundingSourceInformation { get; set; } = string.Empty;

        [Column("FundingRequestOption")]
        public string? FundingRequestOption { get; set; } = string.Empty;

        [Column("EconomicSectorCode")]
        public string? EconomicSectorCode { get; set; } = string.Empty;

        [Column("MinimumTransactionLimit")]
        public string? MinimumTransactionLimit { get; set; } = string.Empty;
        
        [Column("MaximumTransactionLimit")]
        public string? MaximumTransactionLimit { get; set; } = string.Empty;

        [Column("CurrencyCode")]
        public string? CurrencyCode { get; set; } = string.Empty;

        [Column("CompanyExpenseCode")]
        public string? CompanyExpenseCode { get; set; } = string.Empty;

        [Column("CompanyVAT")]
        public string? CompanyVAT { get; set; } = string.Empty;

        [Column("CoordinatorFee")]
        public string? CoordinatorFee { get; set; } = string.Empty;

        [Column("AccountHolderFee")]
        public string? AccountHolderFee { get; set; } = string.Empty;

        [Column("EffectiveDate")]
        public DateOnly? EffectiveDate { get; set; }

        [Column("DataClaim")]
        public string? DataClaim { get; set; } = "N";

        [Column("CardlessAdminFee")]
        public string? CardlessAdminFee { get; set; } = "0";

        [Column("GatewayChargeFeeType")]
        public string? GatewayChargeFeeType { get; set; } = "N"; 

        [Column("CatewayChargeFeeValue")]
        public string? CatewayChargeFeeValue { get; set; } = "0"; 

        [Column("OtherChargeFeeType")]
        public string? OtherChargeFeeType { get; set; } = "N"; 

        [Column("OtherChargeFeeValue")]
        public string? OtherChargeFeeValue { get; set; } = "0";

        [Column("BranchFee")]
        public string? BranchFee { get; set; } = "0";

        [Column("AdditionalChannelType")]
        public string? AdditionalChannelType { get; set; } = string.Empty;

        [Column("TransactionFrequency")]
        public string? TransactionFrequency { get; set; } = string.Empty;

        [Column("PurposeOfUseDescription")]
        public string? PurposeOfUseDescription { get; set; } = string.Empty;

        [Column("CompanyCreditAccount")]
        public string? CompanyCreditAccount { get; set; } = string.Empty;

        [Column("CompanyDebitAccount")]
        public string? CompanyDebitAccount { get; set; } = string.Empty;

        [Column("Email")]
        public string? Email { get; set; } = string.Empty;

        [Column("HandphoneNumber")]
        public string? HandphoneNumber { get; set; } = string.Empty;

        // USER LOG
        [Column("LogTimeStartOPR")]
        public string? LogTimeStartOPR { get; set; } = string.Empty;

        [Column("LogTimeStartSPV")]
        public string? LogTimeStartSPV { get; set; } = string.Empty;

        [Column("IsLocked")]
        public string? IsLocked { get; set; } = string.Empty;

        [Column("UserIdOPR")]
        public string? UserIdOPR { get; set; } = string.Empty;

        [Column("UserIdSPV")]
        public string? UserIdSPV { get; set; } = string.Empty;

        public List<VASubmissionSubCompany>? SubCompanies { get; set; } = [];
        public List<VASubmissionPic>? PicDatas { get; set; } = [];
        public List<VASubmissionBillType>? BillType { get; set; } = [];
        public List<VASubmissionChannelType>? ChannelType { get; set; } = [];
        public List<VASubmissionPurposeOfUse>? PurposeOfUse { get; set; } = [];
        public List<VASubmissionTypeOfUsage>? TypeOfUsage { get; set; } = [];
        public List<VASubmissionType>? SubmissionType { get; set; } = [];
    }

    [Table("DataBillTypePengajuanVA", Schema = "Submissions")]
    public class VASubmissionBillType
    {
        [Key]
        [Column("Id")]
        public Guid? Id { get; set; }
        
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }
        
        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("Key")]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [Column("Value")]
        public string Value { get; set; } = string.Empty;
    }

    [Table("DataChannelTypePengajuanVA", Schema = "Submissions")]
    public class VASubmissionChannelType
    {
        [Key]
        [Column("Id")]
        public Guid? Id { get; set; }
        
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }

        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;

        [Required]
        [Column("Key")]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [Column("Value")]
        public string Value { get; set; } = string.Empty;
    }

    [Table("DataPicPengajuanVA", Schema = "Submissions")]
    public class VASubmissionPic : AuditableEntity
    {
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }

        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("PicName")]
        public string PicName { get; set; } = string.Empty;
        
        [Required]
        [Column("PicPosition")]
        public string PicPosition { get; set; } = string.Empty;
        
        [Required]
        [Column("PicIdNumber")]
        public string PicIdNumber { get; set; } = string.Empty;
        
        [Required]
        [Column("PicHandphoneNumber")]
        public string PicHandphoneNumber { get; set; } = string.Empty;
        
        [Required]
        [Column("PicEmail")]
        public string PicEmail { get; set; } = string.Empty;
        
        [Column("Remarks")]
        public string Remarks { get; set; } = string.Empty;
        
        [Column("SortOrder")]
        public int SortOrder { get; set; }
    }

    [Table("DataPurposeOfUsePengajuanVA", Schema = "Submissions")]
    public class VASubmissionPurposeOfUse
    {
        [Key]
        [Column("Id")]
        public Guid? Id { get; set; }
        
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }
        
        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("Key")]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [Column("Value")]
        public string Value { get; set; } = string.Empty;
    }

    [Table("DataSubCompanyPengajuanVA", Schema = "Submissions")]
    public class VASubmissionSubCompany : AuditableEntity
    {
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }
        
        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("SubCompanyCode")]
        public string SubCompanyCode { get; set; } = string.Empty;
        
        [Required]
        [Column("ProductName")]
        public string SubcompProductName { get; set; } = string.Empty;
        
        [Required]
        [Column("VAAccountNumber")]
        public string VAAccountNumber { get; set; } = string.Empty;
        
        [Required]
        [Column("Email")]
        public string Email { get; set; } = string.Empty;
        
        [Column("Remarks")]
        public string? Remarks { get; set; } = string.Empty;
        
        [Column("PurposeOfUseDescription")]
        public string? PurposeOfUseDescription { get; set; } = string.Empty;
        
        [Column("SortOrder")]
        public int? SortOrder { get; set; }
    }

    [Table("DataSubmissionTypePengajuanVA", Schema = "Submissions")]
    public class VASubmissionType
    {
        [Key]
        [Column("Id")]
        public Guid? Id { get; set; }
        
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }
        
        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("Key")]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [Column("Value")]
        public string Value { get; set; } = string.Empty;
    }

    [Table("DataTypeOfUsagePengajuanVA", Schema = "Submissions")]
    public class VASubmissionTypeOfUsage
    {
        [Key]
        [Column("Id")]
        public Guid? Id { get; set; }
        
        [Required]
        [Column("SubmissionVAId")]
        public Guid SubmissionVAId { get; set; }
        
        [ForeignKey("SubmissionVAId")]
        [JsonIgnore]
        public VASubmission VASubmission { get; set; } = null!;
        
        [Required]
        [Column("Key")]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [Column("Value")]
        public string Value { get; set; } = string.Empty;
    }
}
