using FontListingControl.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class FontListView : UserControl
    {
        public FontListView()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// creates a list of ListViewFontItems from the acquired installed fonts list,
        /// notice how the dependancy properties that are used to intentify each control are asigmned directly into their 
        /// attached DependencyProperties
        /// </summary>
        public void PopulateList()
        {
            FontsList.Items.Clear();
            foreach (var fname in Helpers.GetInstalledFontFamilyNames())
            {
                FontsList.Items.Add(new ListViewFontItem()
                {
                    BaseFontFamilyName = fname,
                    BaseFontFamily = Helpers.GetFontFamilyFromString(fname)
                });
            }
        }

        // PropertyChangedEvenetHandler is a type of event handler
        //allows you to put on a string argument inside its argument
        // you can also build your own custom event, or you can just play dirty 
        //and cast whatever you like back and forth via the sender as it is 'object' anyway.
      
        
        public event PropertyChangedEventHandler FontFamilyChanged;

       
        /// <summary>
        /// when the selection of the list changes an even is send, this event is subscribed by the FontPickerControl t
        /// hat further handles
        /// </summary>
        
        private void FontsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               var sfont= (e.AddedItems.FirstOrDefault() as ListViewFontItem).BaseFontFamilyName;

                FontFamilyChanged?.Invoke(sender, new PropertyChangedEventArgs(sfont));//the fire off happens here
            }
            catch {
            }

        }
    }
}
