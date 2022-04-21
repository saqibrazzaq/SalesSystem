namespace products_api.Misc
{
    public class HttpUtil
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HttpUtil(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetBaseUrl()
        {
            return $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}";
        }

        public string GetBaseUrl_Images()
        {
            return GetBaseUrl() + "/" + DefaultValues.ImagesFolderName + "/";
        }

        public string GetBaseUrl_PhoneImages()
        {
            return GetBaseUrl() + "/" + DefaultValues.PhoneImagesFolderName + "/";
        }
    }
}
