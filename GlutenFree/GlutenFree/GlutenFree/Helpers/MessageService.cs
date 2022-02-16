using System.Threading.Tasks;

namespace GlutenFreeApp.Helpers
{
    public class MessageService : IMessageService
    {
        public async Task ShowPopUpAsync(string title, string message, string button)
        {
            await App.Current.MainPage.DisplayAlert(title, message, button);
        }
    }
}
