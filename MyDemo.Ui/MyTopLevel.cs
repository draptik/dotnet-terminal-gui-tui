using MyDemo.Ui.Domain;
using Terminal.Gui;

namespace MyDemo.Ui;

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
        Add(new MainWindow(new CoreDomain())); // Add the main top-level window
        Add(statusBar);

        Loaded += LoadedHandler;
    }

    private void LoadedHandler()
    {
        _oStatusItem.Title = $"OS: {GetOperatingSystemAndVersion()}";
        
        Loaded -= LoadedHandler;
    }
    
    private static string GetOperatingSystemAndVersion()
    {
        var os = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem;
        var osVersion = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion;
        return $"{os} {osVersion}".Trim();
    }
}