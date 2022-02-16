using System.Threading.Tasks;
using System.Drawing;

namespace GlutenFreeApp.WebService
{
    public interface IAWSS3Service
    {
        Task<bool> UploadImage(Image image, string name);
        Task<Image> GetImage(string name);
    }
}
