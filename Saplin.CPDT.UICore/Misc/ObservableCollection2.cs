using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Saplin.CPDT.UICore
{
    /// <summary>
    /// With reverse order enumerator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableCollection2<T> : ObservableCollection<T>, IEnumerable <T>, IEnumerable
    {
        public ObservableCollection2(bool yieldInReverse)
        {
            YieldInReverse = yieldInReverse;
        }

        public bool YieldInReverse { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (!YieldInReverse)
            {
                for (var i = 0; i < base.Count; i++)
                {
                    yield return base[i];
                }

            }

            for (var i = base.Count - 1; i >= 0; i--)
            {
                yield return base[i];
            }
        }

        public new IEnumerator<T> GetEnumerator()
        {
            if (!YieldInReverse)
            {
                for (var i = 0; i < base.Count; i++)
                {
                    yield return base[i];
                }

            }

            for (var i = base.Count - 1; i >= 0; i--)
            {
                yield return base[i];
            }
        }

        public int currentIndex = 0;

        public int CurrentIndex
        {
            get
            {
                if (Count == 0) return -1;
                return currentIndex;
            }
            set
            {
                if (value < 0 || value > Count - 1) throw new IndexOutOfRangeException("CurrentIndex can't be negative or greater or equal to Count");
                currentIndex = value;
            }
        }

        public int NextIndex
        {
            get
            {
                if (Count == 0) return -1;
                if (Count == 1) return 0;

                if (YieldInReverse)
                {
                    return currentIndex - 1 < 0 ? currentIndex = Count - 1 : currentIndex--;
                }
                else
                {
                    return currentIndex + 1 >= Count ? currentIndex = 0 : currentIndex++;
                }
            }
        }

        public int PreviousIndex
        {
            get
            {
                if (Count == 0) return -1;
                if (Count == 1) return 0;

                if (!YieldInReverse)
                {
                    return currentIndex - 1 < 0 ? currentIndex = Count - 1 : currentIndex--;
                }
                else
                {
                    return currentIndex + 1 >= Count ? currentIndex = 0 : currentIndex++;
                }
            }
        }

        public T Current
        {
            get
            {
                if (Count == 0) return default(T);

                return base[currentIndex];
            }
        }

        public T Next
        {
            get
            {
                if (Count == 0) return default(T);

                return base[NextIndex];
            }
        }

        public T Previous
        {
            get
            {
                if (Count == 0) return default(T);

                return base[PreviousIndex];
            }
        }

        public void MoveNext()
        {
            if (Count == 0 || Count == 1) return;

            if (YieldInReverse)
            {
                currentIndex = currentIndex - 1 < 0 ? currentIndex = Count - 1 : currentIndex--;
            }
            else
            {
                currentIndex = currentIndex + 1 >= Count ? currentIndex = 0 : currentIndex++;
            }
        }

        public void MovePreviuos()
        {
            if (Count == 0 || Count == 1) return;

            if (!YieldInReverse)
            {
                currentIndex = currentIndex - 1 < 0 ? currentIndex = Count - 1 : currentIndex--;
            }
            else
            {
                currentIndex = currentIndex + 1 >= Count ? currentIndex = 0 : currentIndex++;
            }
        }
    }
}