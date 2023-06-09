using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CineMagic.Views
{
    /// <summary>
    /// A Movie's details page.
    /// </summary>
    public sealed partial class MovieDetailsPage : Page
    {
        public MovieDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Actor_ItemClick(object sender, ItemClickEventArgs e)
        {
            // TODO Navigate to actor details page
        }

        private void Similar_ItemClick(object sender, ItemClickEventArgs e)
        {
            // TODO Navigate to similar movie details page
        }
    }
}
