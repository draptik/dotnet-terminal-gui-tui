using Terminal.Gui;

public class MyTopLevel : Toplevel
{
    private readonly StatusItem _oStatusItem = new(Key.CharMask, "OS: ", null);

    public MyTopLevel()
    {
        // Menu
        var menu = new MenuBar(new MenuBarItem[]
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

        var mainPane = new FrameView("Main Pane")
        {
            X = 0,
            Y = 1, // for menu bar
            Width = Dim.Fill(),
            Height = Dim.Fill(1) // for status bar
        };

        Add(menu);
        Add(mainPane);
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