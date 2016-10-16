using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PlanitClient04.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            //ToDo
            // Figure out logic to get phone number + imei number from OS and login automatically
            // If already authenticated

            // Login Button Declaration
            Image loginButton = new Image()
            {
                Source = Device.OnPlatform("ic_action_bad.png",
                                          "ic_action_bad.png",
                                          "Images/HomePage/LoginPlanet50.png"),
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            // Login Button Clicked
            defineTap(loginButton, "login");

            // Join button Decleration
            Image joinButton = new Image()
            {
                Source = Device.OnPlatform("ic_action_bad.png",
                                          "ic_action_bad.png",
                                          "Images/HomePage/JoinPlanet50.png"),
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };
            // Join Image Clicked
            defineTap(joinButton, "join");

            // Label
            Label tagline = new Label()
            {
                Text = "the social calendar app",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
                
            InitializeComponent();

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    loginButton,
                    tagline,
                    joinButton
                }
            };
        }

        private void defineTap(Image image, string button)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            if (button.ToLowerInvariant() == "join")
            {
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new JoinPage());
                };
            }
            else
            {
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new HomePage());
                };
            }
            image.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
