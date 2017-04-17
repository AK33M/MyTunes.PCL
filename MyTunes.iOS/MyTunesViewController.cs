using UIKit;
using System.Linq;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0)) {
				TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
			}
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SongLoader.Loader = new StreamLoader();
			var data = await SongLoader.Load();

			TableView.Source = new ViewControllerSource<Song>(TableView)
			{
				DataSource = data.ToList(),
				TextProc = (arg) => arg.Name,
				DetailTextProc = (arg) => $"{arg.Artist} - {arg.Album}"
			};
		}
	}

}

