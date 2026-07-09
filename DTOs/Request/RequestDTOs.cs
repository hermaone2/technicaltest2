using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTestAPI.DTOs.Request;

public class SubmissionRequestDto
{
    [Required]
    [JsonPropertyName("approval_type")]
    public string? ApprovalType { get; set; }

    [Required]
    [JsonPropertyName("noref_submission")]
    public string? NorefSubmission { get; set; }

    [JsonPropertyName("call_start_time")]
    public DateTimeOffset? CallStartTime { get; set; }

    [JsonPropertyName("call_end_time")]
    public DateTimeOffset? CallEndTime { get; set; }

    [Required]
    [JsonPropertyName("requester_name")]
    public string? RequesterName { get; set; }

    [EmailAddress]
    [JsonPropertyName("requester_email")]
    public string? RequesterEmail { get; set; }

    [JsonPropertyName("requester_phone")]
    public string? RequesterPhone { get; set; }

    [JsonPropertyName("copart_data")]
    public CopartDataDto? CopartData { get; set; }

    [JsonPropertyName("product_data")]
    public List<ProductDataDto>? ProductData { get; set; }
}

public class CopartDataDto
{
    [JsonPropertyName("Nama_Nasabah")]
    public string? NamaNasabah { get; set; }

    [JsonPropertyName("CIN")]
    public string? Cin { get; set; }

    [JsonPropertyName("nomor_rekening")]
    public string? NomorRekening { get; set; }

    [JsonPropertyName("Nomor_Telepon")]
    public string? NomorTelepon { get; set; }

    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    [JsonPropertyName("Alamat_Identitas")]
    public string? AlamatIdentitas { get; set; }

    [JsonPropertyName("RT_Identitas")]
    public string? RtIdentitas { get; set; }

    [JsonPropertyName("RW_Identitas")]
    public string? RwIdentitas { get; set; }

    [JsonPropertyName("Kelurahan_Identitas")]
    public string? KelurahanIdentitas { get; set; }

    [JsonPropertyName("Kecamatan_Identitas")]
    public string? KecamatanIdentitas { get; set; }

    [JsonPropertyName("Kota_Identitas")]
    public string? KotaIdentitas { get; set; }

    [JsonPropertyName("Provinsi_Identitas")]
    public string? ProvinsiIdentitas { get; set; }

    [JsonPropertyName("Kode_POS_Identitas")]
    public string? KodePosIdentitas { get; set; }
}

public class ProductDataDto
{
    [JsonPropertyName("product_cd")]
    public string? ProductCd { get; set; }

    [JsonPropertyName("noref_product")]
    public string? NorefProduct { get; set; }

    [JsonPropertyName("middleform_id")]
    public string? MiddleformId { get; set; }

    [JsonPropertyName("middleform_mlt_id")]
    public string? MiddleformMltId { get; set; }

    [JsonPropertyName("form_data")]
    public System.Text.Json.JsonElement? FormData { get; set; }
}
