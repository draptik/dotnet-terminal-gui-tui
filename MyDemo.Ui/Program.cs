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
        Application.Run();
    }
}