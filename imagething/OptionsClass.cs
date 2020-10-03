using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imagething
{
    class OptionsClass
    {
        public static Dictionary<string, string> OptionsDescription;

        public static void SetUpOptionsDictionary()
        {
            OptionsDescription = new Dictionary<string, string>();
            OptionsDescription.Add("Default image", "Get you back to the original image");
            OptionsDescription.Add("No Color", "Remove one or more of the RGB channels");
            OptionsDescription.Add("No background", "");
            OptionsDescription.Add("B&W", "Change the image to gray scale");
            OptionsDescription.Add("Combine", "Combine 5 images with 50/50 visiblity");
            OptionsDescription.Add("Threshold", "Gray Scale but only black and whit 255 = black,0 = white)");
            OptionsDescription.Add("bluer", "Blure the image");
            OptionsDescription.Add("bluer Exept", "");
            OptionsDescription.Add("bluer Just", "");
            OptionsDescription.Add("Swich Colors", "switch the values of the RBG channels");
        }
    }
}
