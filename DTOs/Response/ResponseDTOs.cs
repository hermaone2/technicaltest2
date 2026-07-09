using System.Text.Json.Serialization;

namespace TechnicalTestAPI.DTOs.Response;

public class SubmissionResponseDto
{
    [JsonPropertyName("error_schema")]
    public ErrorSchemaDto? ErrorSchema { get; set; }

    [JsonPropertyName("output_schema")]
    public OutputSchemaDto? OutputSchema { get; set; }
}

public class ErrorSchemaDto
{
    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("error_message")]
    public ErrorMessageDto? ErrorMessage { get; set; }
}

public class ErrorMessageDto
{
    [JsonPropertyName("english")]
    public string? English { get; set; }

    [JsonPropertyName("indonesian")]
    public string? Indonesian { get; set; }
}

public class OutputSchemaDto
{
    [JsonPropertyName("noref_submission")]
    public string? NorefSubmission { get; set; }

    [JsonPropertyName("product_data")]
    public List<ProductDataResponseDto>? ProductData { get; set; }
}

public class ProductDataResponseDto
{
    [JsonPropertyName("product_cd")]
    public string? ProductCd { get; set; }

    [JsonPropertyName("noref_product")]
    public string? NorefProduct { get; set; }

    [JsonPropertyName("status_cd_product")]
    public string? StatusCdProduct { get; set; }
}
