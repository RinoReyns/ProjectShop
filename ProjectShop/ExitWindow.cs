using System.Windows;

namespace ProjectShop
{
    public static class ExitWindow
    {
        private static int onlyOneExitMessage { get; set; } = 0;
        public static bool Exit(int i = 0)
        {
            if (onlyOneExitMessage == 0)
            {
                onlyOneExitMessage = i;
                MessageBoxResult result = MessageBox.Show("Do you really want to end your shopping without order?", "Exit", MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
                else if (result == MessageBoxResult.No)
                {
                    onlyOneExitMessage = 0;
                    return true;
                }
            }
            return false;
        }
    }
}
