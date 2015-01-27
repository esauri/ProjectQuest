using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sauri_Project3
{
    /// <summary>
    /// Interaction logic for InstructionWindow.xaml
    /// </summary>
    public partial class InstructionWindow : Window
    {
        MainWindow myOwner;

        public InstructionWindow(MainWindow owner)
        {
            InitializeComponent();
            myOwner = owner;

            infoBox.Text = "Move around using the arrow keys. Maybe make this a picture instead.";
        }
    }
}
