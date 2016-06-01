using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for Barcode_Printer.xaml
    /// </summary>
    public partial class Barcode_Printer : Window
    {
        ScrollViewer sv = new ScrollViewer();




        public Barcode_Printer()
        {
            InitializeComponent();
        }

        private string BarcodeLoad()
        {
            OpenFileDialog barcodeOFD = new OpenFileDialog();

            barcodeOFD.Filter = "Bitmap Image|*.bmp|All Files|*.*";
            barcodeOFD.FileName = string.Empty;
            barcodeOFD.ShowDialog();

            return barcodeOFD.FileName;
        }


        private void BarcodePicbox_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == BarcodePicbox1)
                {
                    BarcodePicbox1.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox2)
                {
                    BarcodePicbox2.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox3)
                {
                    BarcodePicbox3.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox4)
                {
                    BarcodePicbox4.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox5)
                {
                    BarcodePicbox5.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox6)
                {
                    BarcodePicbox6.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox7)
                {
                    BarcodePicbox7.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox8)
                {
                    BarcodePicbox8.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicbox9)
                {
                    BarcodePicbox9.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicBox10)
                {
                    BarcodePicBox10.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if (sender == BarcodePicBox11)
                {
                    BarcodePicBox11.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox12)
                {
                    BarcodePicBox12.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox13)
                {
                    BarcodePicBox13.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox14)
                {
                    BarcodePicBox14.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox15)
                {
                    BarcodePicBox15.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox16)
                {
                    BarcodePicBox16.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox17)
                {
                    BarcodePicBox17.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox18)
                {
                    BarcodePicBox18.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox19)
                {
                    BarcodePicBox19.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                } 
                else if(sender == BarcodePicBox20)
                {
                    BarcodePicBox20.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox21)
                {
                    BarcodePicBox21.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox22)
                {
                    BarcodePicBox22.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox23)
                {
                    BarcodePicBox23.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox24)
                {
                    BarcodePicBox24.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox25)
                {
                    BarcodePicBox25.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox26)
                {
                    BarcodePicBox26.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox27)
                {
                    BarcodePicBox27.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox28)
                {
                    BarcodePicBox28.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox29)
                {
                    BarcodePicBox29.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox30)
                {
                    BarcodePicBox30.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox31)
                {
                    BarcodePicBox31.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox32)
                {
                    BarcodePicBox32.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox33)
                {
                    BarcodePicBox33.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox34)
                {
                    BarcodePicBox34.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicBox35)
                {
                    BarcodePicBox35.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
              
                
                
            }
            catch (Exception)
            {
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.PrintDialog printdlg = new System.Windows.Controls.PrintDialog();
            printdlg.PageRangeSelection = PageRangeSelection.AllPages;
            printdlg.UserPageRangeEnabled = true;
            bool? doPrint = printdlg.ShowDialog();
            if (doPrint != true)
            {
                return;
            }

            btPrint.Visibility = Visibility.Collapsed;
            printdlg.PrintVisual(BarcodeGrid, "Barcode grid");
        }
    }         
}
