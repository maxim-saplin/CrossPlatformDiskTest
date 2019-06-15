using System.Collections.Generic;
using System.Linq;

namespace Saplin.CPDT.UICore.ViewModels
{
    public static class ViewModelContainer
    {
        private static readonly List<object> singletons = new List<object>();

        public static T GetSingletonInstance<T>()  where T : BaseViewModel, new()
        {
            var instance = singletons.Where(i => i is T).FirstOrDefault();

            if (instance == null)
            {
                instance = new T();
                singletons.Add(instance);
            }

            return instance as T;
        }

        public static DriveTestViewModel DriveTestViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<DriveTestViewModel>(); }
        }

        public static TestSessionsViewModel TestSessionsViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<TestSessionsViewModel>(); }
        }

        public static OptionsViewModel OptionsViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<OptionsViewModel>(); }
        }

        public static NavigationViewModel NavigationViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<NavigationViewModel>(); }
        }

        public static AboutViewModel AboutViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<AboutViewModel>(); }
        }

        public static ErrorViewModel ErrorViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<ErrorViewModel>(); }
        }

        public static ResultsDbViewModel ResultsDbViewModel
        {
            get { return ViewModelContainer.GetSingletonInstance<ResultsDbViewModel>(); }
        }

        public static L11n L11n
        {
            get { return ViewModelContainer.GetSingletonInstance<L11n>(); }
        }

        public static void Init()
        {
            object tmp = L11n;
            tmp = ResultsDbViewModel;
            tmp = ErrorViewModel;
            tmp = AboutViewModel;
            tmp = NavigationViewModel;
            tmp = OptionsViewModel;
            tmp = TestSessionsViewModel;
            tmp = DriveTestViewModel;
        }
    }
}
