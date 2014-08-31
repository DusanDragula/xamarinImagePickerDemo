using System;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xamarinImagePickerDemo;
using xamarinImagePickerDemo.iOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace xamarinImagePickerDemo.iOS
{
	public class MainPageRenderer : PageRenderer
	{
		private Page _page;
		private UIImage _image;

		public MainPageRenderer() {}

		public override async void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (_image != null) {
				var source = ImageSource.FromStream(() => _image.AsPNG().AsStream());
				await _page.Navigation.PushAsync(new CapturedImagePage(source));
				_image = null;
			}
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			var page = e.NewElement as MainPage;
			if (page != null) {
				_page = page;
				page.TakePhotoButton.Clicked += (sender, args) => {
					var imageController = new UIImagePickerController();
					imageController.SourceType = UIImagePickerControllerSourceType.Camera;
					imageController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
					imageController.CameraCaptureMode = UIImagePickerControllerCameraCaptureMode.Photo;
					imageController.Canceled += (s, a) => {
						imageController.DismissViewController(true, null);
					};
					imageController.FinishedPickingMedia += (s, a) => {
						if (a.Info[UIImagePickerController.MediaType].ToString() == "public.image") {
							_image = a.OriginalImage;
						}
						imageController.DismissViewController(true, null);
					};
					PresentViewController(imageController, true, null);
				};
			}
		}
	}
}