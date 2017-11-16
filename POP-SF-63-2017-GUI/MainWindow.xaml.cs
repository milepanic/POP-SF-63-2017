using POP_SF_63_2017.Model;
using POP_SF_63_2017_GUI.GUI;
using System.Windows;

namespace POP_SF_63_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var namestajProzor = new NamestajCRUD();
            namestajProzor.ShowDialog();
        }
    }
}
