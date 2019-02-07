using FontListingControl.Helpers;
using FontPickerControl.Controls;
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

 
namespace FontPickerControl
{
    public sealed partial class FontPicker : UserControl
    {
    /// <summary>
    /// What you see here are entities by the name 'DependencyProperty'
    /// Dependency Properties, provide a simplistic yet powerfull way of handling and various ui Properties and a lot more
    /// in conjuction to the Binding system they allow for an automagical  propagation of Properties and misc information, usually between the code part of the app and the XAML part
    /// 
    /// For example, those two bellow are intially binded (x:Bind) to the XAML part of this control in order to reflect the current font family, at the same time
    /// they are clearly visible to the Father control (MainPage) so that too can also update its textbox font family 
    /// 
    /// Tip: you can press 'propdp' and then double tap Tab key to bring up the DependancyProperty Tamplate, note that it needs some argumentation before it is used.
    ///
    /// </summary>

        public FontFamily CurrentFontFamily
        {
            get { return (FontFamily)GetValue(CurrentFontFamilyProperty); }
            set { SetValue(CurrentFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty CurrentFontFamilyProperty =
            DependencyProperty.Register("CurrentFontFamily", typeof(FontFamily), typeof(FontPicker), new PropertyMetadata(new FontFamily(Helpers.DefaultFallInitialAndFallbackFamilyName)));

        public string CurrentFontFamilyName
        {
            get { return (string)GetValue(CurrentFontFamilyNameProperty); }
            set { SetValue(CurrentFontFamilyNameProperty, value); }
        }
        public static readonly DependencyProperty CurrentFontFamilyNameProperty =
            DependencyProperty.Register("CurrentFontFamilyName", typeof(string), typeof(FontPicker), new PropertyMetadata(Helpers.DefaultFallInitialAndFallbackFamilyName));






        public FontPicker()
        {
            this.InitializeComponent();

            GetDefaultFont();
           
        }

        /// <summary>
        /// forces the control inside the flyout to Load the font list when the flyout Opens
        /// it might take up to 2 seconds to load up all the fonts, you can change it so it only loads one time at start up.
        /// </summary>

        private void FontsFlyout_Opened(object sender, object e)
        {
            FontsListView.PopulateList();
        }

        private void FontsListView_FontFamilyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            try
            {
                var fname = e.PropertyName;

                CurrentFontFamilyName = fname;// we assign the PropDps, propdps on the own accord will update the ui and the MainPage Textbox to have the involved FontFamily
                CurrentFontFamily = Helpers.GetFontFamilyFromString(fname);


                Windows.Storage.ApplicationData.Current.LocalSettings.Values["SavedFontFamily"] = fname;// we save the property on the settings so we get it back up on startup
            }
            catch
            {

            }


        } 

    /// <summary>
    /// loads the default fontfamily
    /// </summary>
        private void GetDefaultFont()
        {
            try
            {
                string storedfamily = "";

              if (Windows.Storage.ApplicationData.Current.LocalSettings.Values["SavedFontFamily"] != null)
                {


                }
                else
                {
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["SavedFontFamily"] = Helpers.DefaultFallInitialAndFallbackFamilyName;
                }


                storedfamily = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["SavedFontFamily"];

                if (Helpers.IsFontInstalled(storedfamily))
                {
                    CurrentFontFamilyName = storedfamily;
                    CurrentFontFamily = new FontFamily(storedfamily);
                }
                else
                {
                 //do stuff
                }

            }
            catch
            {
                // everything with file system based operations needs an expection check.
                // on the same ground, Applicationdata will throw expection if you try to assign non homogenic types after it has been already set to type.
                //it can be reset via null asignment
            }  

        }

     
    }
}
