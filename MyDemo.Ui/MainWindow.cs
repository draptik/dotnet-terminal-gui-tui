using MyDemo.Ui.Domain;
using Terminal.Gui;

namespace MyDemo.Ui;

public class MainWindow : Window
{
    public MainWindow(CoreDomain coreDomain)
    {
        Title = "Main Window";
        X = 0;
        Y = 1; // Leave one row for the toplevel menu
        Width = Dim.Fill();
        Height = Dim.Fill(1); // Leave one row for the toplevel status bar

        var label1 = new Label("Enter two short strings:") { X = 0, Y = 0 };
        Add(label1);

        var input1 = new TextField
        {
            X = Pos.Right(label1) + 1,
            Y = 0,
            Width = 5,
            Height = 1
        };
        Add(input1);

        var input2 = new TextField
        {
            X = Pos.Right(input1) + 1,
            Y = 0,
            Width = 5,
            Height = 1
        };
        Add(input2);

        var button = new Button("Do Magic!")
        {
            X = Pos.Right(input2) + 1,
            Y = 0,
            Width = 10,
            Height = 1
        };
        Add(button);

        var result = new Label
        {
            X = Pos.Right(button) + 1,
            Y = 0,
            Width = 10,
            Height = 1
        };
        Add(result);

        button.Clicked += () =>
        {
            var s1 = input1.Text.ToString();
            var s2 = input2.Text.ToString();

            if (s2 != null && s1 != null)
            {
                result.Text = coreDomain.DoMagic(s1, s2);    
            }
        };
    }
}