using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PlanitClient04.Pages
{
    public partial class JoinPage : ContentPage
    {

        public JoinPage()
        {
            
            Label pleaseEnterLabel = new Label()
            {
                Text = "please enter...",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };


            Button joinButton = new Button
            {
                Text = "join",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            defineTap(joinButton, "join");

            authButton = new Button
            {
                Text = "auth",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                IsVisible = false
            };
            defineTap(authButton, "auth");

            InitializeComponent();

            // Build the page.
            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    pleaseEnterLabel,
                    nameEntry,
                    numberEntry,
                    joinButton
                }
            };
        }

        private void defineTap(Button button, string buttonName)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            if (buttonName.ToLowerInvariant() == "join")
            {
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    // Unlock the rest of the UI
                    await Navigation.PushAsync(new HomePage());
                };
            }
            else
            {
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new HomePage());
                };
            }
            button.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
