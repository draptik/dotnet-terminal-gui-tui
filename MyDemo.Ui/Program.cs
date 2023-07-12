using MyDemo.Ui;
using Terminal.Gui;

internal class Program
{
    public static void Main(string[] args)
    {
        Application.Init();

        try
        {
            // NOTE: It seems that the Application.Run() method should be wrapped in a try/finally block.
            // Otherwise, the application will not exit when the user closes the window.
            // Application.Run(new DirectoryBrowserView());
            Application.Run(new MyTopLevel());
        }
        finally
        {
            Application.Shutdown();
        }
    }
}