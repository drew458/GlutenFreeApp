using System.Threading.Tasks;

namespace GlutenFree.WebService
{
    public interface IAWSS3Service
    {
        Task<string> UploadImage(Image image);
        Task<string> GetImage();
    }
}
