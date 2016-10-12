using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Syndication;

namespace Rss_Reader
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Sample Address: http://www.izsu.gov.tr/Pages/rss.aspx?rssId=3
        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(UrlBox.Text);
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(uri);

            if (feed != null)
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    listBox.Items.Add(item.Title.Text  + " - " + item.Summary.Text);
                }
            }
        }
    }
}
