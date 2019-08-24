using System;
using System.Runtime.CompilerServices;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestCompletion : StackLayout
    {
        public TestCompletion()
        {
            InitializeComponent();

            progressBox.Color = testProgressLabel.TextColor;
        }

        bool animationStarted = false;
        string[] animationSeq = {"/", "-", "\\", "|"};
        int curAnimIndex = 0;
        const int progressWidth = 230;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsVisible))
            {
                if (IsVisible)
                {
                    animationStarted = true;
                    testProgressLabel.Text = "     ";
                    progressBox.WidthRequest = 0;
                    Device.StartTimer(TimeSpan.FromMilliseconds(450),
                        () =>
                        {
                            if (animationStarted)
                            {
                                curAnimIndex++;
                                if (curAnimIndex > animationSeq.Length - 1) curAnimIndex = 0;

                                var progress = ViewModelContainer.DriveTestViewModel.ProgressPercent;
                                var curTest = ViewModelContainer.DriveTestViewModel.CurrentTestNumber;
                                var totalTests = ViewModelContainer.DriveTestViewModel.TotalTests;

                                var testNum = string.Format(ViewModelContainer.L11n.TestOf,
                                    curTest,
                                    totalTests);

                                var curPercent = ((float)(curTest - 1) / totalTests) * 100 + (float)progress / totalTests;

                                var totalPercent = string.Format(ViewModelContainer.L11n.TestTotal, curPercent);

                                testProgressLabel.Text = testNum + " " + animationSeq[curAnimIndex] + " " + totalPercent;

                                if (curAnimIndex % 3 == 0 || curPercent >=99)
                                    new Animation(val => progressBox.WidthRequest = val, progressBox.WidthRequest, progressWidth * curPercent / 100, Easing.Linear)
                                        .Commit(progressBox, "p", 32, 600);

                                return true;
                            }

                            testProgressLabel.Text = "     ";
                            progressBox.WidthRequest = 0;

                            return false;
                        }
                    );
                }
                else
                {
                    animationStarted = false;
                }
            }
        }
    }
}
