namespace Schedulerry.Api.ApplicationServices.Storage
{
    public interface IStorageService
    {
        public string GetPresingedUploadAssetsUrl(string path);
    }
}
