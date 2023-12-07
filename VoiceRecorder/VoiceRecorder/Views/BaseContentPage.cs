/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------using VoiceRecorder.Extensions;
using VoiceRecorder.Extensions;
using VoiceRecorder.Interfaces;
using VoiceRecorder.ViewModels;
using Xamarin.Forms;

namespace VoiceRecorder.Views
{
    public class BaseContentPage<VM> : ContentPage where VM : BaseViewModel
    {
        public IAppServices Services => IOC.Services;
        public VM ViewModel;

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// ------------------------------------------------------------------------------------------
        public BaseContentPage(dynamic obj = null)
        {
            ViewModel = ObjectExtentions.GetObject<VM>();
            ViewModel.Init(obj);
            BindingContext = ViewModel;
            NavigationPage.SetHasNavigationBar(this, true);
            Title = ViewModel.Title;
            SetupBindings();
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public virtual void SetupBindings()
        {

        }
    }
}