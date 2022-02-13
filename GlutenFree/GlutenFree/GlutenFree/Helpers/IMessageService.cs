using System.Threading.Tasks;

namespace GlutenFree.Helpers
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message, string button);
    }
}
