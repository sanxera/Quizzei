using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Files.Responses;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Files
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuizInfoFileRepository _fileRepository;
        private readonly AwsConfiguration _awsConfiguration;

        public FilesService(IQuizInfoFileRepository fileRepository, IUnitOfWork unitOfWork, IQuizInfoRepository quizInfoRepository, AwsConfiguration awsConfiguration)
        {
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _quizInfoRepository = quizInfoRepository;
            _awsConfiguration = awsConfiguration;
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

        private async Task UploadToS3(string fileName, Stream fileStream)
        {
            var s3Client = new AmazonS3Client(_awsConfiguration.AccessKey, _awsConfiguration.SecretAccessKey, RegionEndpoint.SAEast1);

            var s3Request = new PutObjectRequest
            {
                BucketName = _awsConfiguration.BucketName,
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

            var s3Client = new AmazonS3Client(_awsConfiguration.AccessKey, _awsConfiguration.SecretAccessKey, RegionEndpoint.SAEast1);

            var s3Request = new GetObjectRequest
            {
                BucketName = _awsConfiguration.BucketName,
                Key = file.Name
            };

            var response = await s3Client.GetObjectAsync(s3Request);

            return new DownloadFileResponse(response.ResponseStream, file.Name);
        }
    }
}
