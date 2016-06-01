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
                else if( sender == BarcodePicbox3)
                {
                    BarcodePicbox3.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicbox4)
                {
                    BarcodePicbox4.Image = System.Drawing.Image.FromFile(BarcodeLoad());
                }
                else if(sender == BarcodePicbox5)
                {
                    BarcodePicbox5.Image = System.Drawing.Image.FromFile(BarcodeLoad());
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

            printdlg.PrintVisual(BarcodeGrid, "Barcode grid");
        }
    }         
}
