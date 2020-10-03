using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imagething
{
    enum ErrorCodes
    {
        ColorNotChosen,
        ImageNotLoaded,
        BmpNotLoaded,
        OptionNotChosen,
        TextNotANumber
    }

    class ErrorsClass
    {
        public static Dictionary<ErrorCodes, string> ErrorMassages;

        public static void SetUpErrorsDictionary()
        {
            ErrorMassages = new Dictionary<ErrorCodes, string>();
            ErrorMassages.Add(ErrorCodes.ColorNotChosen, "You need to choose color");
            ErrorMassages.Add(ErrorCodes.ImageNotLoaded, "Please open an image first");
            ErrorMassages.Add(ErrorCodes.BmpNotLoaded, "Please edit the image first");
            ErrorMassages.Add(ErrorCodes.OptionNotChosen, "Please choose a filter first");
            ErrorMassages.Add(ErrorCodes.TextNotANumber, "Enter a number beteen 0 and 255");
        }

        public static void PrintMassage(ErrorCodes massageCode)
        {
            System.Windows.Forms.MessageBox.Show(ErrorMassages[massageCode]);
        }
    }
}
