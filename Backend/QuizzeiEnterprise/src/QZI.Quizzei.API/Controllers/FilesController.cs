using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;

namespace QZI.Quizzei.API.Controllers
{
    //[Authorize]
    [Route("api/files")]
    public class FilesController : Controller
    {
        private readonly IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }  

        [HttpPost("upload/{quizInfoUuid:guid}")]
        public async Task<IActionResult> Upload(Guid quizInfoUuid, IFormFile file)
        {
            var fileName = file.FileName;
            var stream = file.OpenReadStream();

            var response = await _filesService.UploadFileToBucket(quizInfoUuid, fileName, stream);

            return Ok(response);
        }

        [HttpGet("get-files-from-quiz-information/{quizInfoUuid:guid}")]
        public async Task<IActionResult> GetFilesFromQuizInformation(Guid quizInfoUuid)
        {
            var response = await _filesService.GetFilesFromQuizInfo(quizInfoUuid);

            return Ok(response);
        }

        [HttpGet("get-all-files")]
        public async Task<IActionResult> GetAllFiles()
        {
            var response = await _filesService.GetRandomFiles();

            return Ok(response);
        }

        [HttpGet("download-file/{fileUuid:guid}")]
        public async Task<IActionResult> DownloadFile(Guid fileUuid)
        {
            var response = await _filesService.DownloadFileFromS3(fileUuid);

            return File(response.FileStream, "application/pdf", response.FileName);
        }
    }
}
