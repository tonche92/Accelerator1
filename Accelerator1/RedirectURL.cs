using Accelerator1.Model;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace Accelerator1
{
    public class RedirectURL : IRedirectURL
    {
        public string? shortUrl { get; private set; }
        public string? website { get; private set; }
        public void Get(string shortUrlInput, AcceleratorContext _dbcontext)
        {
            var dbRow = _dbcontext.UrlRedirections.Where(x => x.ShortUrl == shortUrlInput).FirstOrDefault();
            if (dbRow != null)
            {
                shortUrl = dbRow.ShortUrl;
                website = dbRow.Website ;
            }
        }

        public void Create(string website, AcceleratorContext _dbcontext)
        {
            this.website = website;
            do
            {
                shortUrl = GetRandomUrl();
            } while (_dbcontext.UrlRedirections.Where(x => x.ShortUrl == shortUrl).FirstOrDefault() != null);
            var urlRedirectionRow = new UrlRedirection();
            urlRedirectionRow.ShortUrl = shortUrl;
            urlRedirectionRow.Website = website;
            _dbcontext.UrlRedirections.Add(urlRedirectionRow);
            _dbcontext.SaveChanges();
        }

        private static string GetRandomUrl()
        {
            string randomUrl = "";
            for (int i = 0; i < 5; i++)
            {
                int typeChar = new Random().Next(0, 3);
                int ASCIIid;
                if (typeChar == 0)
                {
                    ASCIIid = new Random().Next(48, 58);
                }
                else if (typeChar == 1)
                {
                    ASCIIid = new Random().Next(65, 91);
                }
                else
                {
                    ASCIIid = new Random().Next(97, 123);
                }
                randomUrl += ((char)ASCIIid).ToString();
            }
            return randomUrl;
        }
    }
}
