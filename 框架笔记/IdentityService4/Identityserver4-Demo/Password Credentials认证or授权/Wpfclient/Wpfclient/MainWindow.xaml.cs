using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpfclient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token = "";
        private DiscoveryResponse _disco ;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void access_Click(object sender, RoutedEventArgs e)
        {
            var userName = UserNameIput.Text;
            var passWord = PassWordInput.Text;

            //request access token
            var client = new HttpClient();

            //request 发现文档？
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            _disco=disco;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var AccessResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "WPF client",
                ClientSecret = "WPF client",
                Scope = "api1 openid profile",

                UserName = userName,
                Password = passWord
            });

            if (AccessResponse.IsError)
            {
                MessageBox.Show(AccessResponse.Error);
                return;
            }
            token = AccessResponse.AccessToken;
            AccessToken.Text = AccessResponse.Json.ToString();
        }

        private async void API_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var response = await client.GetAsync("http://localhost:5001/identity");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                APIResult.Text = content;
            }
        }

        private async void identity_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);

            var response=await client.GetAsync(_disco.UserInfoEndpoint);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                IdentityResult.Text = content;
            }
        }
    }
}
