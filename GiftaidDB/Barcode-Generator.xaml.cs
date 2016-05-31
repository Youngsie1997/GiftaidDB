using System;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BarcodeLib;
using PostgreSQL_Connection;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for Barcode_Generator.xaml
    /// </summary>
    public partial class Barcode_Generator : Window
    {
        
        

        public Barcode_Generator()
        {
            InitializeComponent();
        }
        
        private void BarcodeGenerator_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BarcodePicbox_Click(object sender, EventArgs e) //Saves the barcode if clicked on
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageFormat savetype;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */ savetype = ImageFormat.Bmp; break;
                    case 2: /* GIF */ savetype = ImageFormat.Gif; break;
                    case 3: /* JPG */ savetype = ImageFormat.Jpeg; break;
                    case 4: /* PNG */ savetype = ImageFormat.Png; break;
                    case 5: /* TIFF */savetype = ImageFormat.Tiff; break;
                    default: break;
                }
                BarcodePicbox.Image.Save(sfd.FileName, ImageFormat.Png);
            }
            




        }
    }
}
