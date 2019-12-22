using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Saplin.CPDT.Droid
{
    [Activity(Process = ":LocalProc", MainLauncher = false)]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            MoveTaskToBack(true);
            base.OnCreate(savedInstanceState);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Toast.MakeText(Android.App.Application.Context, "Second Activity", ToastLength.Short).Show();
        }
    }
}
