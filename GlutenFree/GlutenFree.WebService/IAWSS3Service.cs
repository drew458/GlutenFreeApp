using System.Threading.Tasks;
using System.Drawing;

namespace GlutenFree.WebService
{
    public interface IAWSS3Service
    {
        Task<bool> UploadImage(Image image, string name);
        Task<Image> GetImage(string name);
    }
}
