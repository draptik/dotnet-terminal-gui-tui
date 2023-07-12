using Terminal.Gui;

public class MyTopLevel : Toplevel
{
    private readonly StatusItem _oStatusItem = new(Key.CharMask, "OS: ", null);

    public MyTopLevel()
    {
        // Menu
        var menuBar = new MenuBar(new MenuBarItem[]
        {
            new("_File", new[]
            {
                new MenuItem("_Quit", "Quit this application",
                    () => 
                        Application.RequestStop(), null, null, Key.Q | Key.CtrlMask),
            }),
            new("_Help", new[]
            {
                new MenuItem("_About", "About this application",
                    () => 
                        MessageBox.Query(50, 7, "About", "This is a demo", "Ok"))
            })
        });
        

        // Status bar
        var statusBar = new StatusBar(new StatusItem[]
        {
            new(Key.Q | Key.CtrlMask, "~CTRL-Q~ Quit", () => Application.RequestStop()),
            _oStatusItem
        });

        Add(menuBar);
        Add(new MainWindow()); // Add the main top-level window
        Add(statusBar);

        Loaded += LoadedHandler;
    }

    private void LoadedHandler()
    {
        _oStatusItem.Title =
            $"OS: {Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem} {Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion}";
        
        Loaded -= LoadedHandler;
    }
}