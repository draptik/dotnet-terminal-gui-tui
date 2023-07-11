using Terminal.Gui;

namespace MyDemo.Ui;

public class DirectoryBrowserView : Window
{
    public DirectoryBrowserView()
    {
        // Code from https://bartwullems.blogspot.com/2022/01/build-gui-console-applications-through.html

		// Creates the top-level window to show
		var win = new Window("File Browser")
		{
			X = 0,
			Y = 1, // Leave one row for the toplevel menu

			// By using Dim.Fill(), it will automatically resize without manual intervention
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};

		Add(win);

		// Creates a menubar, the item "New" has a help menu.
		var menu = new MenuBar(new MenuBarItem[] {
					new("_File", new MenuItem [] {
						new("_New", "Creates new file", null),
						new("_Close", "",null),
						new("_Quit", "", () => { if (Quit ()) Running = false; })
					}),
					new("_Edit", new MenuItem [] {
						new("_Copy", "", null),
						new("C_ut", "", null),
						new("_Paste", "", null)
					})
				});
		Add(menu);

		static bool Quit()
		{
			var n = MessageBox.Query(50, 7, "Quit application", "Are you sure you want to quit this app?", "Yes", "No");
			return n == 0;
		}


		var listView = new ListView()
		{
			X = 1,
			Y = 2,
			Height = Dim.Fill(),
			Width = Dim.Fill(1),
			//ColorScheme = Colors.TopLevel,
			AllowsMarking = false,
			AllowsMultipleSelection = false
		};

		var currentDirectory = Environment.CurrentDirectory;
		var files = Directory.GetFiles(currentDirectory);
		listView.SetSource(files);

		// Add some controls, 
		win.Add(
			listView,
			new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar")
		);

		var scrollBar = new ScrollBarView(listView, true);

		scrollBar.ChangedPosition += () => {
			listView.TopItem = scrollBar.Position;
			if (listView.TopItem != scrollBar.Position)
			{
				scrollBar.Position = listView.TopItem;
			}
			listView.SetNeedsDisplay();
		};

		scrollBar.OtherScrollBarView.ChangedPosition += () => {
			listView.LeftItem = scrollBar.OtherScrollBarView.Position;
			if (listView.LeftItem != scrollBar.OtherScrollBarView.Position)
			{
				scrollBar.OtherScrollBarView.Position = listView.LeftItem;
			}
			listView.SetNeedsDisplay();
		};

		listView.DrawContent += (e) => {
			scrollBar.Size = listView.Source.Count - 1;
			scrollBar.Position = listView.TopItem;
			scrollBar.OtherScrollBarView.Size = listView.Maxlength - 1;
			scrollBar.OtherScrollBarView.Position = listView.LeftItem;
			scrollBar.Refresh();
		};

    }
}