using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Files;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuizInfoFileRepository _fileRepository;

        public FilesService(IQuizInfoFileRepository fileRepository, IUnitOfWork unitOfWork, IQuizInfoRepository quizInfoRepository)
        {
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _quizInfoRepository = quizInfoRepository;
        }

        public async Task<UploadFileResponse>  UploadFileToBucket(Guid quizInfoUuid, string fileName, Stream fileStream)
        {
            var file = new QuizInformationFile(fileName, quizInfoUuid);

            await UploadToS3(fileName, fileStream);

            await _fileRepository.AddAsync(file);
            await _unitOfWork.SaveChangesAsync();

            return new UploadFileResponse(file.QuizInfoFileUuid, fileName);
        }

        public async Task<GetRandomFilesResponse> GetRandomFiles()
        {
            var files = await _fileRepository.GetQuizInfoFileInRange(500);

            var response = new GetRandomFilesResponse();
            foreach (var file in files)
            {
                response.FilesResponse.Add(new FileResponse(file.QuizInfoFileUuid, file.Name));
            }

            return response;
        }

        public async Task<GetFilesFromQuizInfoResponse> GetFilesFromQuizInfo(Guid quizInfoUuid)
        {
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizInfoUuid);

            var response = new GetFilesFromQuizInfoResponse();
            foreach (var file in quizInfo.Files)
            {
                response.FilesResponse.Add(new FileResponse(file.QuizInfoFileUuid, file.Name));
            }

            return response;
        }

        private static async Task UploadToS3(string fileName, Stream fileStream)
        {
            var s3Client = new AmazonS3Client("ASIA5VCJBR53HLOTA2U3", "T7qo3j9g999pAaH2pZfZumPrW4ClKKas33YAhuI4", "FwoGZXIvYXdzECwaDA/PmWgD/IOr11qqySLCAZFQnevF3GK1XEn48CEKYOhxlPrrA1kkZNciL04qH1PCvQXQi4kCNTax7wc7jo9mE3jbRF1u2Hg7WLkgTOYUzw+S8IDvPD5AHmmVPlmNTFb3XzD6QoVCDhdq1iLeNhd+pVAoohFcQ31QeY4o49WN4iAzHBA7C2UVBDgfufSqFOcvZGo07e4KgohkJFNyYwktYzSL1LZ6jyjEuq+E/TviZjZNc16xq/BVjX5nNDTl67ffb9b+03H/bNkQvqrsutY3NazlKKG21psGMi3u8AXoxDgM6DE9puAp7EJQ+PXl7Ome3+sofvuZdyeVPKOHVtdP4QHJbar2pgw=", RegionEndpoint.USEast1);

            var s3Request = new PutObjectRequest
            {
                BucketName = "quizzei-bucket",
                Key = fileName,
                InputStream = fileStream,
                ContentType = "application/pdf",
                CannedACL = S3CannedACL.BucketOwnerFullControl
            };

            await s3Client.PutObjectAsync(s3Request);
        }

        public async Task<DownloadFileResponse> DownloadFileFromS3(Guid fileUuid)
        {
            var file = await _fileRepository.GetQuizInfoFileById(fileUuid);

            var s3Client = new AmazonS3Client("ASIA5VCJBR53HLOTA2U3", "T7qo3j9g999pAaH2pZfZumPrW4ClKKas33YAhuI4", "FwoGZXIvYXdzECwaDA/PmWgD/IOr11qqySLCAZFQnevF3GK1XEn48CEKYOhxlPrrA1kkZNciL04qH1PCvQXQi4kCNTax7wc7jo9mE3jbRF1u2Hg7WLkgTOYUzw+S8IDvPD5AHmmVPlmNTFb3XzD6QoVCDhdq1iLeNhd+pVAoohFcQ31QeY4o49WN4iAzHBA7C2UVBDgfufSqFOcvZGo07e4KgohkJFNyYwktYzSL1LZ6jyjEuq+E/TviZjZNc16xq/BVjX5nNDTl67ffb9b+03H/bNkQvqrsutY3NazlKKG21psGMi3u8AXoxDgM6DE9puAp7EJQ+PXl7Ome3+sofvuZdyeVPKOHVtdP4QHJbar2pgw=", RegionEndpoint.USEast1);

            var s3Request = new GetObjectRequest
            {
                BucketName = "quizzei-bucket",
                Key = file.Name
            };

            var response = await s3Client.GetObjectAsync(s3Request);

            return new DownloadFileResponse(response.ResponseStream, file.Name);
        }
    }
}
