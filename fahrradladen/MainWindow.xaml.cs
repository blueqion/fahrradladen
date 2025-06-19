using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fahrradladen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Datenbank db = new Datenbank();
        List<Fertigwaren> lfw = new List<Fertigwaren>();
        List<Rohstoffe> lrs = new List<Rohstoffe>();
        public MainWindow()
        {
            InitializeComponent();
            listefuellen();
            listefuellenrw();
        }

        private void ___ButtonSpeichern__Click(object sender, RoutedEventArgs e)
        {
            Fertigwaren fw = new Fertigwaren(0, TextBoxModel.Text);
            db.createFertigwaren(fw);
            TextBoxModel.Text = "";
            listefuellen();
        }
            
        private void listefuellen()
        {
            ListBoxFarradmodel.Items.Clear();
            lfw = db.readFertigwaren();
            foreach (Fertigwaren fw in lfw)
            {
                ListBoxFarradmodel.Items.Add(fw.FwModel);
            }
        }
        private void listefuellenrw()
        {
            ListBoxRohstoffe2.Items.Clear();
            lrs = db.readRohstoffe();
            foreach (Rohstoffe rs in lrs)
            {
                ListBoxRohstoffe2.Items.Add(rs.RsBezeichnung);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rohstoffe rs = new Rohstoffe(0, TextBoxBezeichnung.Text, double.Parse(TextBoxPreis.Text));
            db.createRohstoffe(rs);
            TextBoxModel.Text = "";
            listefuellenrw();

        } 
    }
}