namespace Saplin.CPDT.UICore.ViewModels
{
    public class TestSessionsViewModel : BaseViewModel
    {
        private ObservableCollection2<TestSession> testSessions = new ObservableCollection2<TestSession>(yieldInReverse: true);

        public void Add(TestSession testSession)
        {
            foreach (var t in testSessions)
                t.Selected = false;

            testSessions.Add(testSession);

            testSession.Selected = true;
            if (!HasItems)
            {
                HasItems = true;
                RaisePropertyChanged(nameof(HasItems));
            }
        }

        public ObservableCollection2<TestSession> TestSessions
        {
            get { return testSessions; }
            private set
            {
                if (value != testSessions)
                {
                    testSessions = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool HasItems
        {
            get; private set;
        }

    }
}
