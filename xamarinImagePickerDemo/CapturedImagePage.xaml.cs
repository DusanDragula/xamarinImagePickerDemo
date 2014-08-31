using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xamarinImagePickerDemo
{	
	public partial class CapturedImagePage : ContentPage
	{	
		public ImageSource Source { get; set; }

		public CapturedImagePage(ImageSource image)
		{
			InitializeComponent();

			Source = image;

			BindingContext = this;
		}
	}
}