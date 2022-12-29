namespace Accelerator1
{
    public class UrlCreateResult
    {
        public string shortUrl { get; private set; }
        public string QR { get; private set; }
        public UrlCreateResult (string shortUrl, string QR)
        {
            this.shortUrl = shortUrl;
            this.QR = QR;
        }
    }
}
