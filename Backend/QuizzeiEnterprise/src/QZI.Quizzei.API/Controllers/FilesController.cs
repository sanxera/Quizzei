using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

namespace QZI.Quizzei.API.Controllers
{
    //[Authorize]
    [Route("api/files")]
    public class FilesController : Controller
    {
        [HttpPost("upload-pdf")]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            var stream = file.OpenReadStream();

            var s3Client = new AmazonS3Client("ASIA5VCJBR53PWMPG5OZ", "BPOLUnUpe8ghI2fxQZPKtVySdFdnKvk5NMIs28h3", "FwoGZXIvYXdzEA0aDHZy3hP2ibc15jLedSLCAQqSzOgO6/rxMX/SUsPTulKe2c7CbSkhvKym6E/w8ixrz4GRhnRcAVvnctxWp5D16kDyXcii6f3Ni9lj/EI3aXwMirGX1/fV4gQ8+cpNuz/wuMw/MAYfyp+QYxBp8IbHUFDrC+ovLgd0VYFCMCJ2Q+3t7Fdi8RiuN7qAMzIyKKz/YvcIM+X4F+g7iF8K2htBWVvGQVrglZolrwLeflGrn3yOuLbpjtKxLWbpHtACloOgT/LJv+Iq0PH0t7TSxr44e0a6KMfGz5sGMi3ysqpNWnXJsFZ21z9618EsMESDXIpmtMMLy9I094PgaDWw1I+jmC0kzhfOOnM=", RegionEndpoint.USEast1);

            var s3Request = new PutObjectRequest
            {
                BucketName = "quizzei-bucket",
                Key = "meuarquivo.pdf",
                InputStream = stream,
                ContentType = "application/pdf",
                CannedACL = S3CannedACL.BucketOwnerFullControl
            };

            var s3Response = await s3Client.PutObjectAsync(s3Request);

            return Ok();
        }
    }
}
