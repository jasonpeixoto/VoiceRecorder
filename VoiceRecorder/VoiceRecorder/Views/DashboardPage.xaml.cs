/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using VoiceRecorder.ViewModels;
using Xamarin.Forms.Xaml;

namespace VoiceRecorder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : BaseContentPage<DashboardViewModel>
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SetupBindings()
        {
            base.SetupBindings();
        }

    }
}