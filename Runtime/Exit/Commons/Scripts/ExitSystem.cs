using Exit.View;
using UScreens;

namespace Exit
{
    public static class ExitSystem
    {
        public static void Show() =>
            UScreenRepo.Get<ExitViewController>().Show();
    }
}