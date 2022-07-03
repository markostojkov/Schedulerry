namespace Schedulerry.Api.Contracts.AppSettings
{
    public class AwsStorageSettings
    {
        public int DefaultPreSignUrlExpirationMinutes { get; set; }

        public string StorageServerRegion { get; set; }

        public string BucketName { get; set; }

        public string Username { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }
    }
}
