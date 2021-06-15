using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using CoinTipsApp.Services;
using ZXing.PDF417.Internal;
using System.Windows.Input;

namespace CoinTipsApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
               
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
                  
        private void xferButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
