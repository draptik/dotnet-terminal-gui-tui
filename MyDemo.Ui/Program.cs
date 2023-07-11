using MyDemo.Ui;
using Terminal.Gui;

internal class Program
{
    public static void Main(string[] args)
    {
        Application.Init();

        var top = Application.Top;

        var login = new Label("Login: ") { X = 0, Y = 0 };
        top.Add(login);

        var win = new Window("My Demo")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        top.Add(win);
        try
        {
            // NOTE: It seems that the Application.Run() method should be wrapped in a try/finally block.
            // Otherwise, the application will not exit when the user closes the window.
            Application.Run();
        }
        finally
        {
            Application.Shutdown();
        }
    }
}