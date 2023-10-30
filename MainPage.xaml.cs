namespace CameraOnIMEI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public static async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
#if ANDROID
                    var getPathDcim = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDcim);

                    string v = Path.Combine(getPathDcim, photo.FileName);
                    string pathPhoto = v;
#endif
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }


            }
        }

        private void PhotoBtn_Clicked(object sender, EventArgs e)
        {
            MainPage.TakePhoto();
        }
    }
}

    





