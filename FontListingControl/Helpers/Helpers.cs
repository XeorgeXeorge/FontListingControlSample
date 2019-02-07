using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;
using Windows.UI.Xaml.Media;

namespace FontListingControl.Helpers
{
/// <summary>
/// i am not sure so sure why i built a helpers class, maybe it just cuz i like to talk too much.  
/// </summary>
   public static class Helpers
    {
        /// <summary>
        /// Its the font family that is intially used and set as a default throughout, it is also the font family that is used when stuff goes wrong.
        /// </summary>
        public static string DefaultFallInitialAndFallbackFamilyName { get => "Calibri"; }

        


     public static FontFamily GetFontFamilyFromString(string fontFamilyName)
        {

            try
            {
                return new FontFamily(fontFamilyName);
            }
            catch
            {
                return new FontFamily(Helpers.DefaultFallInitialAndFallbackFamilyName);
                // i for one do not care to find out if an actual parsing exception can occur, 
                // but in any case this static helper method is not the place to check up and handle such exceptions, it is an antipatern
                //it is just done for the shake of simplicity
               
            }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="priorotizeLocalLanguages"></param>
        /// <param name="AllowComicSans">
        /// YOU SHALL NOT PASS</param>
        /// <returns></returns>
        public static List<string> GetInstalledFontFamilyNames(bool priorotizeLocalLanguages=true )
        {
            List<string> toreturnList;
            if (priorotizeLocalLanguages)
            {
               toreturnList = CanvasTextFormat.GetSystemFontFamilies(CurrentUserLocales)
                //.Where(x=>!x.ToLower().Contains("comic"))         /*YOU SHALL NOT PASS, enable line to remove unnesserary fonts intividually*/
                .ToList();
            }
            else {
              toreturnList=   CanvasTextFormat.GetSystemFontFamilies().OrderByDescending(x => x).ToList();
            }






            return toreturnList;
        }


        /// <summary>
        /// A redundant quality check that evaluetes if the provided font is indeed installed
        /// Everything changes and it not the same, for example, in a scenario where the user changes his default languages, or even syncs the app settings to a different computer
        /// we need to evalute that the font saved in the settings does actually exist. 
        /// </summary>
        /// <param name="fontFamilyName"></param>
        /// <returns></returns>
        public static bool IsFontInstalled(string fontFamilyName)
        {
            return GetInstalledFontFamilyNames(false).Exists(x=>x==fontFamilyName) ;

        }



        
        static IReadOnlyList<string> CurrentUserLocales
        {
            get => ApplicationLanguages.Languages;                       

        }
        



    }
}
