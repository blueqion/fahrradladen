using K4os.Compression.LZ4.Streams.Frames;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fahrradladen
{
    public class Datenbank
    {
        string connstring = "SERVER=localhost;UID='root';PASSWORD='';DATABASE=fahrradLaden";
        MySqlConnection conn;

        public Datenbank()
        {
            conn = new MySqlConnection(connstring);
        }
        public void createFertigwaren(Fertigwaren f)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO fertigwaren VALUES(NULL, '{0}');", f.FwModel);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public void createRohstoffe(Rohstoffe r)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO rohstoffe VALUES(NULL, '{0}', {1});", r.RsBezeichnung, r.RsPreis);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public void createfwrs(int fwid, int rsid, int anzahl)
        {
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO fwrs VALUES({0}, {1}, {2});", fwid, rsid, anzahl);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public List<Fertigwaren> readFertigwaren()
        {
            List<Fertigwaren> lfw = new List<Fertigwaren>();
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM fertigwaren;");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Fertigwaren fw = new Fertigwaren(
                        reader.GetInt32(0),
                        reader.GetString(1));
                    lfw .Add(fw);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return lfw;
        }
        public List<Rohstoffe> readRohstoffe()
        {
            List<Rohstoffe> lrs = new List<Rohstoffe>();
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM rohstoffe;");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rohstoffe rs = new Rohstoffe(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDouble(2));
                    lrs.Add(rs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return lrs;
        }
        public List<Fwrs> readZuordnung(int fid)
        {
            List<Fwrs> lrsid = new List<Fwrs>();
            conn.Open();
            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT rsid, rsAnzahl FROM fwrs where fwid={0};", fid);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Fwrs temp = new Fwrs(
                        reader.GetInt32(0),
                        reader.GetInt32(1));
                    lrsid.Add(temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("readZuordnung wirft: " + ex.Message);
            }
            conn.Close();
            return lrsid;
        }
    }
}
