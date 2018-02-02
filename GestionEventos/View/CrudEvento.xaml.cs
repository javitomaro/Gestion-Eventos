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

namespace GestionEventos.View
{
    /// <summary>
    /// Interaction logic for CrudEvento.xaml
    /// </summary>
    public partial class CrudEvento : Window
    {
        public CrudEvento()
        {
            InitializeComponent();
        }

        private void radioButtonSelectAddress_Checked(object sender, RoutedEventArgs e)
        {

            this.textBoxCalle.Visibility = Visibility.Hidden;
            this.textBoxPoblacion.Visibility = Visibility.Hidden;
            this.textBoxCP.Visibility = Visibility.Hidden;
            this.labelPostal.Visibility = Visibility.Hidden;

            this.textBoxCalle.Text = null;
            this.textBoxPoblacion.Text = null;
            this.textBoxCP.Text = null;

            this.comboBoxPoblación.Visibility = Visibility.Visible;
            this.comboBoxCalle.Visibility = Visibility.Visible;

        }

        private void rButonAddress_Checked(object sender, RoutedEventArgs e)
        {
            this.textBoxCalle.Visibility = Visibility.Visible;
            this.textBoxPoblacion.Visibility = Visibility.Visible;
            this.textBoxCP.Visibility = Visibility.Visible;
            this.labelPostal.Visibility = Visibility.Visible;

            this.comboBoxPoblación.Visibility = Visibility.Hidden;
            this.comboBoxCalle.Visibility = Visibility.Hidden;
            this.comboBoxPoblación.SelectedValue = false;
            this.comboBoxCalle.SelectedValue = false;
        }
    }
}
