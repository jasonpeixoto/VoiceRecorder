/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;
using VoiceRecorder.Models;
using VoiceRecorder.Views;
using Xamarin.Forms;

namespace VoiceRecorder.Services
{
    public class NavigationService : BaseService, INavigationService
    {
        public NavigationService()
        {
        }

        private NavigationService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task PopAllFromStack()
        {
            await Shell.Current.Navigation.PopToRootAsync();
            await Shell.Current.Navigation.PopAsync();
        }

        /// <summary>
        /// Goto dashboard
        /// </summary>
        /// <returns></returns>
        public async Task Dashboard()
        {
            await PopAllFromStack();
            await Shell.Current.GoToAsync("//DashboardPage");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task PlayRecording(RecordingLog model)
        {
            //await Shell.Current.Navigation.PushAsync(new PlayRecordingPage(model));
        }
    }
}
