using System.Threading.Tasks;

namespace GlutenFree.Helpers
{
    public class MessageService : IMessageService
    {
        public async Task ShowPopUpAsync(string title, string message, string button)
        {
            await App.Current.MainPage.DisplayAlert(title, message, button);
        }
    }
}
