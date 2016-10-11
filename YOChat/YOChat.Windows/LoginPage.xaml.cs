using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YOChat.DataModel;
using YOChat.Windows.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YOChat.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            CountryPhoneCode.ItemsSource = new List<Country>()
            {
                new Country() { Flag = "/Assets/Flags/tr.png", CountryName="Turkey", PhoneCode="+90"},
                new Country() { Flag = "/Assets/Flags/fr.png", CountryName="France", PhoneCode="+33"},
                new Country() { Flag = "/Assets/Flags/de.png", CountryName="Germany", PhoneCode="+49"}
            };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CountryPhoneCode.SelectedItem != null)
            {
                var _id = Guid.NewGuid().ToString("N");
                var _countryPhoneCode = (CountryPhoneCode.SelectedItem as Country).PhoneCode;
                var _countryName = (CountryPhoneCode.SelectedItem as Country).CountryName;
                var _name = FullName.Text;
                var _phoneNumber = PhoneNumber.Text;
                var _password = Password.Password;

                var client = new HttpClient()
                {
                    BaseAddress = new Uri("http://yochat.azurewebsites.net/chat/")
                };

                var json = await client.GetStringAsync("createuser?id=" + _id + "&fullName=" + _name + "&password=" + _password + "&phoneNumber=" + _phoneNumber + "&countryPhoneCode=" + _countryPhoneCode);

                var serializer = new DataContractJsonSerializer(typeof(User));
                var ms = new MemoryStream();
                var user = serializer.ReadObject(ms) as User;

                Frame.Navigate(typeof(MainPage), user);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Lütfen Ülkenizi Seçiniz!");
                await dialog.ShowAsync();
            }
        }
    }
}
