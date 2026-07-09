using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Shared.Common.Entities;

namespace TechnicalTestAPI.Controllers;

[Route("api")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IWebHostEnvironment _env;

    public ProcessController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
    {
        _httpClientFactory = httpClientFactory;
        _env = env;
    }

    [HttpPost("soal2")]
    public async Task<IActionResult> ProcessSubmissions()
    {
        try
        {
            var requestUrl = $"{Request.Scheme}://{Request.Host}/api/endpoint";
            
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(requestUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to call Mock API");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(jsonString);
            var rootArray = document.RootElement;

            if (rootArray.ValueKind != JsonValueKind.Array)
            {
                return BadRequest("Invalid JSON format from Mock API (expected array)");
            }

            var submission = new VASubmission
            {
                SubmissionProductId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow
            };

            foreach (var element in rootArray.EnumerateArray())
            {
                if (element.TryGetProperty("Customer Identification Number (CIN)", out var cin))
                {
                    submission.CompanyCustomerNumber = cin.GetString();
                }
                
                if (element.TryGetProperty("Kode Perusahaan / Company Code", out var compCode))
                {
                    submission.CompanyCode = compCode.GetString();
                }

                if (element.TryGetProperty("Nama Perusahaan / Company Name", out var compName))
                {
                    submission.CompanyName = compName.GetString();
                }

                if (element.TryGetProperty("Corporate ID", out var corpId))
                {
                    submission.CorporateId = corpId.GetString();
                }

                if (element.TryGetProperty("Bidang Usaha / Business Sector", out var bizSector))
                {
                    submission.BusinessSector = bizSector.GetString();
                }

                if (element.TryGetProperty("Situs Web Perusahaan / Company Website", out var compWeb))
                {
                    submission.CompanyWeb = compWeb.GetString();
                }

                if (element.TryGetProperty("Pemungut PPN / VAT Collector", out var vatCollectorArr))
                {
                    var val = GetCheckedValue(vatCollectorArr);
                    if (val != null) submission.VatCollector = val;
                }

                if (element.TryGetProperty("Rerata Nominal Transaksi / Avg. Amount of Transaction", out var avgTrans))
                {
                    submission.AvgTransaction = avgTrans.GetString();
                }

                if (element.TryGetProperty("Nominal Transaksi Tertinggi / Highest Transaction Amount", out var highTrans))
                {
                    submission.HighestTransaction = highTrans.GetString();
                }

                if (element.TryGetProperty("Biaya per Transaksi / Fee per Transaction", out var fee))
                {
                    submission.FeePerTransaction = fee.GetString();
                }

                if (element.TryGetProperty("Informasi Tambahan / Additional Information", out var addInfo))
                {
                    submission.AdditionalInformation = addInfo.GetString();
                }

                // Parse Bill Type
                if (element.TryGetProperty("Jenis Tagihan / Bill Type", out var billTypeArr))
                {
                    foreach (var item in billTypeArr.EnumerateArray())
                    {
                        if (item.TryGetProperty("checkmark", out var checkmark) && checkmark.GetBoolean())
                        {
                            submission.BillType!.Add(new VASubmissionBillType
                            {
                                Id = Guid.NewGuid(),
                                SubmissionVAId = submission.SubmissionProductId,
                                Value = item.GetProperty("value").GetString() ?? ""
                            });
                        }
                    }
                }

                // Parse Channel Transaksi
                if (element.TryGetProperty("Channel Transaksi / Transaction Channel", out var channelArr))
                {
                    foreach (var item in channelArr.EnumerateArray())
                    {
                        if (item.TryGetProperty("checkmark", out var checkmark) && checkmark.GetBoolean())
                        {
                            submission.ChannelType!.Add(new VASubmissionChannelType
                            {
                                Id = Guid.NewGuid(),
                                SubmissionVAId = submission.SubmissionProductId,
                                Value = item.GetProperty("value").GetString() ?? ""
                            });
                        }
                    }
                }

                // Parse Tujuan Penggunaan
                if (element.TryGetProperty("Tujuan Penggunaan BCA VA / BCA VA Purpose of Use", out var purposeArr))
                {
                    foreach (var item in purposeArr.EnumerateArray())
                    {
                        if (item.TryGetProperty("checkmark", out var checkmark) && checkmark.GetBoolean())
                        {
                            submission.PurposeOfUse!.Add(new VASubmissionPurposeOfUse
                            {
                                Id = Guid.NewGuid(),
                                SubmissionVAId = submission.SubmissionProductId,
                                Value = item.GetProperty("value").GetString() ?? ""
                            });
                        }
                    }
                }

                // Parse PIC Entries (from element 1)
                if (element.TryGetProperty("Sub-Kode Perusahaan/Company Sub-Code", out _) && element.TryGetProperty("Entries", out var entriesArrPIC))
                {
                    foreach (var entry in entriesArrPIC.EnumerateArray())
                    {
                        if (entry.TryGetProperty("Nama/Name", out var name))
                        {
                            submission.PicDatas!.Add(new VASubmissionPic
                            {
                                SubmissionVAId = submission.SubmissionProductId,
                                PicName = name.GetString() ?? "",
                                PicPosition = entry.TryGetProperty("Jabatan/Title", out var title) ? title.GetString() ?? "" : "",
                                PicIdNumber = entry.TryGetProperty("NIK/Citizenship No", out var nik) ? nik.GetString() ?? "" : "",
                                PicHandphoneNumber = entry.TryGetProperty("HP/Phone", out var hp) ? hp.GetString() ?? "" : "",
                                PicEmail = entry.TryGetProperty("Email", out var email) ? email.GetString() ?? "" : "",
                                Remarks = GetCheckedValue(entry.GetProperty("Keterangan / Remarks")) ?? ""
                            });
                        }
                    }
                }

                // Parse Sub-Company Entries (from element 3)
                if (!element.TryGetProperty("Sub-Kode Perusahaan/Company Sub-Code", out _) && element.TryGetProperty("Entries", out var entriesArrSubComp))
                {
                    foreach (var entry in entriesArrSubComp.EnumerateArray())
                    {
                        if (entry.TryGetProperty("Sub-Kode Perusahaan / Company Sub-Code", out var subCode))
                        {
                            submission.SubCompanies!.Add(new VASubmissionSubCompany
                            {
                                SubmissionVAId = submission.SubmissionProductId,
                                SubCompanyCode = subCode.GetString() ?? "",
                                SubcompProductName = entry.TryGetProperty("Nama Produk / Product Name", out var prodName) ? prodName.GetString() ?? "" : "",
                                VAAccountNumber = entry.TryGetProperty("No. Rekening Settlement / Settlement Account", out var acc) ? acc.GetString() ?? "" : "",
                                Email = entry.TryGetProperty("Email", out var email) ? email.GetString() ?? "" : "",
                                Remarks = GetCheckedValue(entry.GetProperty("Keterangan / Remarks")) ?? ""
                            });
                        }
                    }
                }
                
                // Parse Element 2 (Approval/Info)
                if (element.TryGetProperty("Unit Penerima Pengajuan / Application Receiving Unit", out var appUnit))
                {
                    submission.BusinessUnit = appUnit.GetString();
                }
                
                if (element.TryGetProperty("Kode & Nama Cabang Koordinator / Coord. Branch Code & Name", out var branchStr))
                {
                    var branchParts = branchStr.GetString()?.Split('-');
                    if (branchParts != null && branchParts.Length > 1)
                    {
                        submission.BranchCode = branchParts[0];
                        submission.BranchName = branchParts[1];
                    }
                }
            }

            // Save the entity to JSON file
            string folderPath = Path.Combine(_env.ContentRootPath, "App_Data");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"submission_soal2_entity_{Guid.NewGuid()}.json";
            string filePath = Path.Combine(folderPath, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string outJson = JsonSerializer.Serialize(submission, options);
            await System.IO.File.WriteAllTextAsync(filePath, outJson);

            return Ok(new { Message = "Successfully mapped and saved to JSON", File = fileName });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private string? GetCheckedValue(JsonElement arrayElement)
    {
        if (arrayElement.ValueKind != JsonValueKind.Array) return null;

        foreach (var item in arrayElement.EnumerateArray())
        {
            if (item.TryGetProperty("checkmark", out var checkmark) && checkmark.GetBoolean())
            {
                return item.TryGetProperty("value", out var val) ? val.GetString() : null;
            }
        }
        return null;
    }
}
