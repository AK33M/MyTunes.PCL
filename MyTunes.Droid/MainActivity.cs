﻿using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SongLoader.Loader = new StreamLoader(this);
			var data = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song>() {
				DataSource = data.ToList(),
				TextProc = (arg) => arg.Name,
				DetailTextProc = (arg) => $"{arg.Artist} - {arg.Album}"
			};
		}
	}
}


