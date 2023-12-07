/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel() : base()
        {
        }

        public override void Init()
        {
            Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IAppServices Services;
        public event PropertyChangedEventHandler PropertyChanged;

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyValue"></param>
        /// <param name="propertyName"></param>
        /// ------------------------------------------------------------------------------------------
        protected virtual void OnPropertyChanged<T>(T propertyValue, [CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null && propertyName != System.String.Empty)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Init this instance.
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public virtual void Init()
        {
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Init the specified parameter.
        /// </summary>
        /// <returns>The init.</returns>
        /// <param name="parameter">Parameter.</param>
        /// ------------------------------------------------------------------------------------------
        public virtual void Init(dynamic parameter)
        {
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public BaseViewModel()
        {
            Services = IOC.Services;
            InitlizeModel();
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// ------------------------------------------------------------------------------------------
        public BaseViewModel(IAppServices services)
        {
            Services = services;
            InitlizeModel();
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Initlizes the model.
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public abstract void InitlizeModel();

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public virtual void OnAppearing()
        {
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { OnPropertyChanged(isBusy = value); }
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { OnPropertyChanged(title = value); }
        }

    }
}
