/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace VoiceRecorder.Helpers
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private readonly object _lockCollection = new object();

        /// <summary>
        /// Create  clone
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static RangeObservableCollection<T> Clone(RangeObservableCollection<T> data)
        {
            return (new RangeObservableCollection<T>()).ClearAddRange(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RangeObservableCollection<T> Create()
        {
            return new RangeObservableCollection<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public RangeObservableCollection<T> AddRange(IEnumerable<T> list)
        {
            if (list != null)
            {
                lock (_lockCollection)
                {
                    foreach (T item in list)
                    {
                        AddNoNotify(item);
                    }

                    SendNotifications();
                }
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public RangeObservableCollection<T> AddRange(IList<T> list)
        {
            if (list != null)
            {
                lock (_lockCollection)
                {
                    foreach (T item in list)
                    {
                        AddNoNotify(item);
                    }

                    SendNotifications();
                }
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public RangeObservableCollection<T> AddNoNotify(T item)
        {
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public RangeObservableCollection<T> ClearAddRange(IEnumerable<T> list)
        {
            if (list != null)
            {
                lock (_lockCollection)
                {
                    Items.Clear();

                    foreach (T item in list)
                    {
                        Items.Add(item);
                    }

                    SendNotifications();
                }
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public RangeObservableCollection<T> ClearAddRange(IList<T> list)
        {
            if (list != null)
            {
                lock (_lockCollection)
                {
                    Items.Clear();

                    foreach (T item in list)
                    {
                        Items.Add(item);
                    }

                    SendNotifications();
                }
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        public RangeObservableCollection<T> SendNotifications()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(new PropertyChangedEventArgs("Keys"));
            OnPropertyChanged(new PropertyChangedEventArgs("Values"));
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            return this;
        }
    }
}