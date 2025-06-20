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
            dgRohstoffe.ItemsSource = lrs;
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
                ComboBoxRohstoffe.Items.Add(rs.RsBezeichnung);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxRohstoffe2.Items.Clear();
            ComboBoxRohstoffe.Items.Clear();
            Rohstoffe rs = new Rohstoffe(0, TextBoxBezeichnung.Text, double.Parse(TextBoxPreis.Text));
            db.createRohstoffe(rs);
            TextBoxModel.Text = "";
            listefuellenrw();
            TextBoxBezeichnung.Text = "";
            TextBoxPreis.Text = "";
            dgRohstoffe.ItemsSource = lrs;
        }

        private void ButtonZuordnen_Click(object sender, RoutedEventArgs e)
        {
            int fid = ListBoxFarradmodel.SelectedIndex;
            fid = lfw[fid].FwID;
            int rid = ComboBoxRohstoffe.SelectedIndex;
            rid = lrs[rid].RsId;
            int anzahl = int.Parse(TextBoxAnzahl.Text);
            db.createfwrs(fid, rid, anzahl);
            listefuellenzuordnen(fid);
        }
        private void listefuellenzuordnen(int fid)
        {
            ListBoxRohstoffe.Items.Clear();
            double gesammtpreis = 0;
            List<Fwrs> fwrslist = new List<Fwrs>();
            fwrslist = db.readZuordnung(fid);
            foreach(Fwrs fwrs in fwrslist)
            {
                Rohstoffe temp = lrs.Find(x => x.RsId == fwrs.Rsid);

                ListBoxRohstoffe.Items.Add(temp.RsBezeichnung + ", Anzahl: " + fwrs.Anzahl);
                gesammtpreis = temp.RsPreis * fwrs.Anzahl + gesammtpreis;
            }
            LabelGesammtPreis.Content = "Gesammtpreis: " + gesammtpreis;
        }

        private void fahrradmodell_selectionChanged(object sender, RoutedEventArgs e)
        {
            int fid = ListBoxFarradmodel.SelectedIndex;
            fid = lfw[fid].FwID;

            listefuellenzuordnen(fid);
        }
    }
}