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
            var s3Client = new AmazonS3Client("ASIA5VCJBR53PWMPG5OZ", "BPOLUnUpe8ghI2fxQZPKtVySdFdnKvk5NMIs28h3", "FwoGZXIvYXdzEA0aDHZy3hP2ibc15jLedSLCAQqSzOgO6/rxMX/SUsPTulKe2c7CbSkhvKym6E/w8ixrz4GRhnRcAVvnctxWp5D16kDyXcii6f3Ni9lj/EI3aXwMirGX1/fV4gQ8+cpNuz/wuMw/MAYfyp+QYxBp8IbHUFDrC+ovLgd0VYFCMCJ2Q+3t7Fdi8RiuN7qAMzIyKKz/YvcIM+X4F+g7iF8K2htBWVvGQVrglZolrwLeflGrn3yOuLbpjtKxLWbpHtACloOgT/LJv+Iq0PH0t7TSxr44e0a6KMfGz5sGMi3ysqpNWnXJsFZ21z9618EsMESDXIpmtMMLy9I094PgaDWw1I+jmC0kzhfOOnM=", RegionEndpoint.USEast1);

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

            var s3Client = new AmazonS3Client("ASIA5VCJBR53PWMPG5OZ", "BPOLUnUpe8ghI2fxQZPKtVySdFdnKvk5NMIs28h3", "FwoGZXIvYXdzEA0aDHZy3hP2ibc15jLedSLCAQqSzOgO6/rxMX/SUsPTulKe2c7CbSkhvKym6E/w8ixrz4GRhnRcAVvnctxWp5D16kDyXcii6f3Ni9lj/EI3aXwMirGX1/fV4gQ8+cpNuz/wuMw/MAYfyp+QYxBp8IbHUFDrC+ovLgd0VYFCMCJ2Q+3t7Fdi8RiuN7qAMzIyKKz/YvcIM+X4F+g7iF8K2htBWVvGQVrglZolrwLeflGrn3yOuLbpjtKxLWbpHtACloOgT/LJv+Iq0PH0t7TSxr44e0a6KMfGz5sGMi3ysqpNWnXJsFZ21z9618EsMESDXIpmtMMLy9I094PgaDWw1I+jmC0kzhfOOnM=", RegionEndpoint.USEast1);

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
