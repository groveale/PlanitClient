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
        private Entry authEntry, nameEntry, numberEntry;
        private Label pleaseEnterLabel;
        private Button authButton, joinButton;
        private Image joinImage;

        public JoinPage()
        {
            
            nameEntry = new Entry
            {
                Text = "your name",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            numberEntry = new Entry
            {
                Text = "your number",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };

            authEntry = new Entry
            {
                Text = "your code",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                IsVisible = false
            };

            pleaseEnterLabel = new Label
            {
                Text = "please enter...",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };


            joinButton = new Button
            {
                Text = "join",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            joinButton.Clicked += OnJoinButtonClicked;

            authButton = new Button
            {
                Text = "auth",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                IsVisible = false
            };
            authButton.Clicked += OnAuthButtonClicked;

            // Join button Decleration
            joinImage = new Image()
            {
                Source = Device.OnPlatform("ic_action_bad.png",
                                          "ic_action_bad.png",
                                          "Images/HomePage/JoinPlanet50.png"),
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            InitializeComponent();

            // Build the page.
            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    joinImage,
                    pleaseEnterLabel,
                    nameEntry,
                    numberEntry,
                    joinButton
                }
            };
        }

        async void OnAuthButtonClicked(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        async void OnJoinButtonClicked(object sender, EventArgs args)
        {
            // Send number to MobileAPI
            var userNumber = numberEntry.Text;
            bool foundNumber = await DoesUserExist(userNumber);

            if (foundNumber)
            {
                await DisplayAlert("Already Exists", "Click OK to go to login psge", "login");
                await Navigation.PushAsync(new JoinPage());
            }
            else
            {
                var userName = nameEntry.Text;

                // send json to server to create user
                CreateUser(userName, userNumber);
            }
        }

        private void CreateUser(string userName, string userNumber)
        {
            throw new NotImplementedException();
        }

        private Task<bool> DoesUserExist(string userNumber)
        {
            throw new NotImplementedException();
        }
    }
}
