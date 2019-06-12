using System;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Saplin.CPDT.UICore;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.ShareViewAsImage))]
namespace Saplin.CPDT.Droid
{
    public class ShareViewAsImage : IShareViewAsImage
    {
        const string fileName = "share.png";
        const int padding = 15;
        const string title = "CPDT Benchmark";

        public ShareViewAsImage()
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
        }

        public void Share(View view, bool blackBackground)
        {
            //try
            //{
                var uri = SaveToFile(view, blackBackground);
                Share(uri);
            //}
            //catch { };
        }

        private Android.Net.Uri SaveToFile(View view, bool blackBackground)
        {
            var renderer = Platform.GetRenderer(view);

            var androidView = renderer.View;

            var image = Bitmap.CreateBitmap(androidView.Width + 2 * padding, androidView.Height, Bitmap.Config.Argb8888);

            var c = new Canvas(image);
            var paint = new Paint() { Color = blackBackground ? Android.Graphics.Color.Black : Android.Graphics.Color.White };
            paint.SetStyle(Paint.Style.Fill);
            c.DrawPaint(paint);
            //c.DrawRect(new Rect(0, 0, image.Width, image.Height), paint);
            c.Translate(padding, 0);
            androidView.Draw(c);


            var path = MainActivity.Instance.BaseContext.GetExternalFilesDir(null).AbsolutePath;
            var filePath = System.IO.Path.Combine(path, fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            image.Compress(Bitmap.CompressFormat.Png, 100, stream);

            stream.Close();

            var imageUri = Android.Net.Uri.Parse($"file://{filePath}");

            return imageUri;
        }

        private void Share(Android.Net.Uri uri)
        {
            var sharingIntent = new Intent();
            sharingIntent.SetAction(Intent.ActionSend);
            sharingIntent.SetType("image/*");
            sharingIntent.PutExtra(Intent.ExtraText, title);
            sharingIntent.PutExtra(Intent.ExtraStream, uri);
            sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
            MainActivity.Instance.StartActivity(Intent.CreateChooser(sharingIntent, title));
        }
    }
}
