using FontListingControl.Helpers;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FontPickerControl.Controls
{
    public sealed partial class ListViewFontItem : UserControl
    {

        public FontFamily BaseFontFamily
        {
            get { return (FontFamily)GetValue(BaseFontFamilyProperty); }
            set { SetValue(BaseFontFamilyProperty, value); }
        }
         
        public static readonly DependencyProperty BaseFontFamilyProperty =
            DependencyProperty.Register("BaseFontFamily", typeof(FontFamily), typeof(UserControl), new PropertyMetadata(new FontFamily(Helpers.DefaultFallInitialAndFallbackFamilyName)));

        public string BaseFontFamilyName
        {
            get { return (string)GetValue(BaseFontFamilyNameProperty); }
            set { SetValue(BaseFontFamilyNameProperty, value); }
        } 
        public static readonly DependencyProperty BaseFontFamilyNameProperty =
            DependencyProperty.Register("BaseFontFamilyName", typeof(string), typeof(UserControl), new PropertyMetadata(Helpers.DefaultFallInitialAndFallbackFamilyName));


        public ListViewFontItem()
        {
            this.InitializeComponent();
        }
    }
}
