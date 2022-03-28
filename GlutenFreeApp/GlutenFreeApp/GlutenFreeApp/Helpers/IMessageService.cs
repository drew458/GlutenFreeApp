using System.Threading.Tasks;

namespace GlutenFreeApp.Helpers
{
    public interface IMessageService
    {
        Task ShowPopUpAsync(string title, string message, string button);
    }
}
