using System.Drawing;

namespace GlutenFreeApp.Helpers
{
    // guardare https://www.youtube.com/watch?v=GKJRR8_DSSs
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
