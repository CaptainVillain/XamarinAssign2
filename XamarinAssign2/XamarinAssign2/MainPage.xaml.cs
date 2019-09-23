using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinAssign2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool flash = false;
        private Location loc = null;

        public MainPage()
        {
            InitializeComponent();
        }

        async void Flashlight(object sender, EventArgs args)
        {
            try
            {
                if (!flash)
                {
                    // Turn On
                    await Xamarin.Essentials.Flashlight.TurnOnAsync();
                    flash = true;
                }
                else
                {
                    // Turn Off
                    await Xamarin.Essentials.Flashlight.TurnOffAsync();
                    flash = false;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("No flashlight", "It seems you have no flashlight", "Okay");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }

        }

        async void ShowGeo(object sender, EventArgs args)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                loc = await Geolocation.GetLocationAsync(request);
                geoLabel.Text = "Latitude: " + loc.Latitude + " Longitude: " + loc.Longitude;
                await Map.OpenAsync(loc);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

        }


    }
}

