using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace XamarinMiniCrm.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/philsmith86")));
        }

        public ICommand OpenWebCommand { get; }
    }
}