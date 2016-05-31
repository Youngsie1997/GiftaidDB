using System;
using System.Windows;
using System.Data;
using System.Drawing;
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
    }
}
