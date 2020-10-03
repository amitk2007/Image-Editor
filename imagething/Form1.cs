using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalImageProcessing;
using System.IO;
using System.Drawing.Imaging;

namespace imagething
{
    public partial class Form1 : Form
    {
        #region Variables
        /// <summary>
        /// The filters for the image file to upload
        /// </summary>
        string filesFilters = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff" + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
        /// <summary>
        /// The path to the main Output filder of this project
        /// </summary>
        string inputFolderPath = @"\Images\Inputs";
        string outputFolderPath = @"\Oututs\";
        string filename;
        string tosave;
        Bitmap origional;
        Bitmap second;
        Bitmap bmp;
        int[] filter;
        int holder;
        Point firstPoint;
        Point secondPoint;
        Color color = Color.White;
        enum filters
        {
            firstFilter,
            secondFilter,
            counter1,
            counter2,
            checker,
            filterNum,
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            ResetMenus();

            //Setting up all of the error massages
            ErrorsClass.SetUpErrorsDictionary();

            //Set the main images folder to the 'Input' folder of this project
            inputFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + inputFolderPath;
            //Set the main images folder to the 'Output' folder of this project
            outputFolderPath = Directory.GetCurrentDirectory() + outputFolderPath;

            if (Directory.Exists(inputFolderPath))
            {
                openFileDialog1.InitialDirectory = inputFolderPath;
            }
        }

        #region Load & Save buttons

        private void imagePath_Click(object sender, EventArgs e)
        {

        }
        private void savepath_Click(object sender, EventArgs e)
        {

        }
        //Second image load
        private void secondImagePath_Click(object sender, EventArgs e)
        {
            //geting image from the computer with the file type you want
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Visible = true;
                second = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                pictureBox2.Image = second;
            }
        }

        #endregion

        private void change_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //setting bmp with thw origional photo
            bmp = origional;
            //chosing the filter you want to the photo
            if (imageFilterBox.SelectedItem != null)
            {
                switch (imageFilterBox.SelectedItem.ToString())
                {
                    case "Default image":
                        bmp = origional;
                        break;
                    case "No Color":
                        if (moreOptions.SelectedItem != null)
                        {
                            bmp = StudentUtilities.NoColor(origional, moreOptions.SelectedItem.ToString());
                        }
                        else
                        {
                            ErrorsClass.PrintMassage(ErrorCodes.ColorNotChosen);
                        }
                        break;
                    case "No background":
                        bmp = StudentUtilities.RemoveBackground(origional, color, trackBar1.Value);
                        break;
                    case "B&W":
                        bmp = StudentUtilities.ToGreyscale(origional);
                        break;
                    case "Combine":
                        #region combine
                        //filter{first filter, second filter,counter1 ,counter2 ,checker (not for the filter himself),filter num (not for the filter himself)}
                        filter = new int[6] { 0, 0, 0, 0, 0, 0 };
                        if (filterValus.Text != null && filterValus.Text != "0.X,0.Y")
                        {
                            if (second != null && origional != null)
                            {
                                for (int i = 0; i < filterValus.Text.Length; i++)
                                {
                                    if (filterValus.Text[i] == '.')
                                    {
                                        filter[(int)filters.checker] = 1;
                                    }
                                    if (filterValus.Text[i] == ',')
                                    {
                                        filter[(int)filters.checker] = 0;
                                        //changing the number of filter that is changing
                                        filter[(int)filters.filterNum] = 1;
                                    }
                                    if (filterValus.Text[i] >= '0' && filterValus.Text[i] <= '9')
                                    {
                                        if (filter[(int)filters.checker] > 0)
                                        {
                                            holder = filter[(int)filters.filterNum];
                                            filter[holder] = filter[holder] * 10;
                                            filter[holder] = filter[holder] + (int)filterValus.Text[i] - 48;
                                            if (filter[(int)filters.filterNum] == 0)
                                            {
                                                filter[(int)filters.counter1]++;
                                            }
                                            else
                                            {
                                                filter[(int)filters.counter2]++;
                                            }
                                            /*MessageBox.Show(filterValus.Text[i].ToString());
                                            int a = filterValus.Text[i];
                                            MessageBox.Show(a.ToString());
                                            MessageBox.Show((filter[(int)filters.counter]*10).ToString());
                                            double b = (filter[(int)filters.counter] * 10);
                                            MessageBox.Show(a.ToString()+","+b.ToString()+","+(a/b).ToString());
                                            filter[(int)filters.filterNum] = ((int)filterValus.Text[i] /(filter[(int)filters.counter]*10));
                                            filter[(int)filters.counter]++;*/
                                        }
                                    }
                                }
                                if (filter[(int)filters.counter1] == 0 || filter[(int)filters.counter2] == 0)
                                {
                                    MessageBox.Show("You need to insert two numbers that are smaller then 1 and not 0");
                                    break;
                                }
                                double one = (double)filter[(int)filters.firstFilter] / Math.Pow(10, filter[(int)filters.counter1]);
                                double two = (double)filter[(int)filters.secondFilter] / Math.Pow(10, filter[(int)filters.counter2]);
                                bmp = StudentUtilities.LinearCombinationColored(origional, second, one, two, false);
                            }
                            else
                            {
                                MessageBox.Show("You need to insert 2 pics");
                            }
                        }
                        else
                        {
                            MessageBox.Show("you need to put/change valuse");
                        }
                        #endregion
                        break;
                    case "Threshold":
                        #region check if the number is 0<=x<=255 and if integer
                        int j;
                        if (int.TryParse(filterValus.Text, out j))
                        {
                            if (int.Parse(filterValus.Text) >= 0 && int.Parse(filterValus.Text) <= 255)
                            {
                                bmp = StudentUtilities.MatrixToBitmap(StudentUtilities.Threshold(StudentUtilities.BitmapToMatrix(origional), int.Parse(filterValus.Text)));
                            }
                            else
                            {
                                MessageBox.Show("the int meed to be between 0 and 255");
                            }
                        }
                        else
                        {
                            MessageBox.Show("you need to put a number");
                        }
                        #endregion
                        break;
                    case "bluer":
                        bmp = StudentUtilities.bluer(origional);
                        break;
                    case "bluer Exept":
                        if (point1 != null && point2 != null)
                        {
                            bmp = StudentUtilities.bluerExept(origional, GetPointFromText(point1.Text), GetPointFromText(point2.Text));
                        }
                        break;
                    case "bluer Just":
                        if (point1 != null && point2 != null)
                        {
                            bmp = StudentUtilities.bluerJust(origional, GetPointFromText(point1.Text), GetPointFromText(point2.Text));
                        }
                        break;
                    case "Swich Colors":
                        bmp = StudentUtilities.SwichColors(origional, Rcol.SelectedItem.ToString(), Gcol.SelectedItem.ToString(), Bcol.SelectedItem.ToString());
                        break;

                }
            }
            else
            {
                ErrorsClass.PrintMassage(ErrorCodes.OptionNotChosen);
            }
            pictureBox1.Image = bmp;

            this.Cursor = Cursors.Default;
        }//changing the image

        private void imageFilterBox_SelectedIndexChanged(object sender, EventArgs e) //opens the items list tothe no color filter
        {
            ResetMenus();

            switch (imageFilterBox.SelectedItem.ToString())
            {
                case "No background":
                    ChangeVisible_RemoveBackground(true);
                    break;
                case "No Color":
                    moreOptions.Visible = true;
                    checkedListBox1.Visible = true;
                    checkedListBox1.Items.Add("red");
                    checkedListBox1.Items.Add("green");
                    checkedListBox1.Items.Add("blue");
                    break;
                case "Combine":
                    secondImagePath.Visible = true;
                    filterValus.Visible = true;
                    filterValus.Text = "0.X,0.Y";
                    break;
                case "Threshold":
                    filterValus.Visible = true;
                    filterValus.Text = "int";
                    break;
                case "bluer Exept":
                    point1.Visible = true;
                    point2.Visible = true;
                    point1.Text = "{X=0,Y=0}";
                    point2.Text = "{X=0,Y=0}";
                    break;
                case "bluer Just":
                    point1.Visible = true;
                    point2.Visible = true;
                    point1.Text = "{X=0,Y=0}";
                    point2.Text = "{X=0,Y=0}";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = StudentUtilities.LinearCombinationColored(origional, second, 0.5, 0.5, false);
        }

        //gets coordinates by click
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs pnt = (MouseEventArgs)e;
            if (pnt.Button == MouseButtons.Right)
            {
                firstPoint = pnt.Location;
                point1.Text = firstPoint.ToString();
            }
            else if (pnt.Button == MouseButtons.Left)
            {
                secondPoint = pnt.Location;
                point2.Text = secondPoint.ToString();
            }
        }

        #region help stuff
        public static Point GetPointFromText(string text)
        {
            int x = 0;
            int y = 0;
            int xORy = 0;
            foreach (char index in text)
            {
                if (index >= '0' && index <= '9')
                {
                    if (xORy == 0)
                    {
                        x = x * 10;
                        x = x + (int)index - 48;
                    }
                    else if (xORy == 1)
                    {
                        y = y * 10;
                        y = y + (int)index - 48;
                    }
                }
                else if (index == 'Y')
                {
                    xORy = 1;
                }
            }
            if (x == 0 && y == 0)
            {
                MessageBox.Show("you didnt insert valus to your point, therefor  x=0,y=0");
            }
            return new Point(x, y);
        }

        /* public static void normalPointToPicturePoint()
         {
             bmp = origional;
             double newX = (GetPointFromText(point1.Text).X * bmp.Width) / pictureBox1.Width;
             double newY = (GetPointFromText(point1.Text).Y * bmp.Height) / pictureBox1.Height;
             //MessageBox.Show(GetPointFromText(point1.Text).X+"<point><bmp>"+bmp.Width+">picbox>"+pictureBox1.Width+"and "+
             //    newX.ToString() + "Test" + newY.ToString());
             bmp.SetPixel((int)Math.Round(newX), (int)Math.Round(newY), Color.FromArgb(255, 0, 0));
             pictureBox1.Image = bmp;
         }*/

        void ResetMenus()
        {
            #region Remove Background

            ChangeVisible_RemoveBackground(false);

            moreOptions.Visible = false;
            moreOptions.Items.Clear();
            secondImagePath.Visible = false;
            filterValus.Visible = false;
            pictureBox2.Visible = false;
            filterValus.Text = "";
            point1.Visible = false;
            point2.Visible = false;
            checkedListBox1.Visible = false;
            #endregion
        }

        bool IsImageLoaded()
        {
            if (filename != "" && filename != null)
            {
                if (bmp != null)
                {
                    return true;
                }
                else
                {
                    ErrorsClass.PrintMassage(ErrorCodes.BmpNotLoaded);
                }
            }
            else
            {
                ErrorsClass.PrintMassage(ErrorCodes.ImageNotLoaded);
            }
            return false;
        }

        string GetFileSaveName()
        {
            string name = Path.GetFileNameWithoutExtension(filename) + "-";
            if (imageFilterBox.SelectedItem.ToString() != "" && imageFilterBox.SelectedItem.ToString() != null)
            {
                name = name + imageFilterBox.SelectedItem.ToString();
            }
            name = name + Path.GetExtension(filename);
            return name;
        }

        void CreateOutputFolder()
        {
            Directory.CreateDirectory(outputFolderPath);
        }
        void OpenSavedFile(string message, string path)
        {
            //opening the final image location (if you want)
            //string message = "The image was saved in '" + tosave + "' do you want to open the file lication?";
            var answer = MessageBox.Show(message, "what is this?", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }
        #endregion

        #region File Menu Buttons
        //Main image load
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Geting files from the computer with a format of an image
            openFileDialog1.Filter = filesFilters;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                origional = new Bitmap(Image.FromFile(filename));
                this.label1.Text = filename;
                pictureBox1.Image = origional;
            }

        }

        //Opens the current file parent folder
        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsImageLoaded())
            {
                System.Diagnostics.Process.Start(Directory.GetParent(filename).ToString());
            }
        }

        //Main image save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsImageLoaded())
            {
                //Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = filesFilters;
                //saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = GetFileSaveName();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    tosave = saveFileDialog1.FileName;
                    label1.Text = saveFileDialog1.FileName;
                    //saving the final image
                    bmp.Save(tosave, ImageFormat.Png);

                    //opening the final image location (if you want)
                    string message = "The image was saved in '" + tosave + "' do you want to open the file lication?";
                    OpenSavedFile(message, Directory.GetParent(tosave).ToString());
                }
            }
        }

        //Main image save to Output folder
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsImageLoaded())
            {
                //Creating Output folder and Saving the image
                CreateOutputFolder();
                tosave = GetFileSaveName();
                if (File.Exists(outputFolderPath + tosave))
                {
                    string fileExistMessage = "There is a file with the same name, Do you want to replace it?";
                    var fileExistAnswer = MessageBox.Show(fileExistMessage, "Duplication problem", MessageBoxButtons.YesNo);
                    if (fileExistAnswer == DialogResult.Yes)
                    {
                        bmp.Save(outputFolderPath + tosave, ImageFormat.Png);
                        string message = "The image was saved in '" + tosave + "' do you want to open the file lication?";
                        OpenSavedFile(message, outputFolderPath);
                    }
                }
                else
                {
                    bmp.Save(outputFolderPath + tosave, ImageFormat.Png);

                    string message = "The image was saved in '" + tosave + "' do you want to open the file lication?";
                    OpenSavedFile(message, outputFolderPath);
                }
            }
        }

        #endregion
        private void ColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ColorPickerButton.BackColor = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            thresholdTextBox.Text = trackBar1.Value.ToString();
        }
        private void thresholdTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(thresholdTextBox.Text, out _))
            {
                int num = int.Parse(thresholdTextBox.Text);
                if (num >= 0 && num <= 255)
                {
                    trackBar1.Value = num;
                }
                else
                {
                    ErrorsClass.PrintMassage(ErrorCodes.TextNotANumber);
                    thresholdTextBox.Text = trackBar1.Value.ToString();
                }
            }
            else
            {
                ErrorsClass.PrintMassage(ErrorCodes.TextNotANumber);
                thresholdTextBox.Text = trackBar1.Value.ToString();
            }
        }


        #region ChangeButtonsVisiblity
        void ChangeVisible_RemoveBackground(bool isVisible)
        {
            ColorPickerButton.Visible = isVisible;
            colorLabel.Visible = isVisible;
            thresholdLabel.Visible = isVisible;
            thresholdTextBox.Visible = isVisible;
            trackBar1.Visible = isVisible;
            if (isVisible)
            {
                trackBar1.Value = 50;
                thresholdTextBox.Text = "50";
            }
        }

        void ChangeVisible_NoColor(bool isVisible)
        {

        }

        //Combine
        //Threshold
        //bluer Exept
        //bluer Just
        #endregion

    }
}
