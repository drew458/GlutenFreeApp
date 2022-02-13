using System.Threading.Tasks;

namespace GlutenFree.Helpers
{
    public interface IMessageService
    {
        Task ShowPopUpAsync(string title, string message, string button);
    }
}
