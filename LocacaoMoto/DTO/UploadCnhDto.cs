using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class UploadCnhDto
{
    [Required]
    public IFormFile CnhPhoto { get; set; }
}
