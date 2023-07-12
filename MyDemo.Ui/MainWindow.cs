using Terminal.Gui;

namespace MyDemo.Ui;

public class MainWindow : Window
{
    public MainWindow()
    {
        Title = "Main Window";
        X = 0;
        Y = 1; // Leave one row for the toplevel menu
        Width = Dim.Fill();
        Height = Dim.Fill(1); // Leave one row for the toplevel status bar

        var textField = new TextField("Hello World")
        {
            X = Pos.Center(),
            Y = Pos.Center(),
            Width = 12,
            Height = 1
        };
        
        Add(textField);
    }
}