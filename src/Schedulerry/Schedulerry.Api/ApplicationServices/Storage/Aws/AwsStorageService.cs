using Amazon.S3;
using Amazon.S3.Model;
using Schedulerry.Api.Services;
using System;

namespace Schedulerry.Api.ApplicationServices.Storage
{
    public class AwsStorageService : IStorageService
    {
        public AwsStorageService(IAmazonS3 awsS3Client, AppSettings appSettings)
        {
            AwsS3Client = awsS3Client;
            AppSettings = appSettings;
        }

        public IAmazonS3 AwsS3Client { get; }
        public AppSettings AppSettings { get; }

        public string GetPresingedUploadAssetsUrl(string path)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = AppSettings.AwsStorageSettings.BucketName,
                Key = path,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(AppSettings.AwsStorageSettings.DefaultPreSignUrlExpirationMinutes))
            };

            return AwsS3Client.GetPreSignedURL(request);
        }
    }
}
