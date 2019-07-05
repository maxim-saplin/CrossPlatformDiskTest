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

            
        }

        bool animationStarted = false;
        string[] animationSeq = {"/", "-", "\\", "|"};
        int curAnimIndex = 0;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsVisible))
            {
                if (IsVisible)
                {
                    float accumPercent = 0;
                    int spiner = 2;

                    animationStarted = true;
                    Device.StartTimer(TimeSpan.FromMilliseconds(450),
                        () =>
                        {
                            if (animationStarted)
                            {
                                curAnimIndex++;
                                if (curAnimIndex > animationSeq.Length - 1) curAnimIndex = 0;
                                animationLabel.Text = animationSeq[curAnimIndex];

                                var curTest = ViewModelContainer.DriveTestViewModel.CurrentTestNumber;
                                var totalTests = ViewModelContainer.DriveTestViewModel.TotalTests;
                                var progress = ViewModelContainer.DriveTestViewModel.ProgressPercent;

                                testNumberLabel.Text = string.Format(ViewModelContainer.L11n.TestOf,
                                    curTest,
                                    totalTests);

                                var curPercent = ((float)(curTest - 1) / totalTests) * 100 + (float)progress / totalTests;
                                if (accumPercent < curPercent && --spiner < 0) accumPercent = curPercent;

                                totalPercentLabel.Text = string.Format(ViewModelContainer.L11n.TestTotal, accumPercent);

                                return true;
                            }

                            return false;
                        }
                    );
                }
                else
                {
                    animationStarted = false;
                    testNumberLabel.Text = "       ";
                    totalPercentLabel.Text = "   ";
                }
            }
        }
    }
}
