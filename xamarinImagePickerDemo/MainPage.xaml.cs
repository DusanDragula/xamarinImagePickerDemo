using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xamarinImagePickerDemo
{	
	public partial class MainPage : ContentPage
	{	
		public Button TakePhotoButton { get { return TakePhotoBtn; } }

		public MainPage ()
		{
			InitializeComponent ();
		}
	}
}