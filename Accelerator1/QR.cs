using QRCoder;
using System.Buffers.Text;

namespace Accelerator1
{
    public class QR : IQRService
    {
        public string websiteToQR(string shortUrl)
        {
            QRCodeData qrCodeData;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                qrCodeData = qrGenerator.CreateQrCode(shortUrl, QRCodeGenerator.ECCLevel.Q);
            }
            var imgType = Base64QRCode.ImageType.Png;
            var qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(20, SixLabors.ImageSharp.Color.DeepPink, SixLabors.ImageSharp.Color.White, true, imgType);
        }
    }
}
