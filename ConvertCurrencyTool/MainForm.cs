using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeHollow.FeedReader;
using System.Net.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace ConvertCurrencyTool
{
    public partial class MainForm : Form
    {
        public class CurrencyByValue
        {
            public int ID;
            public float VALUE;
            public string NAME;
            public string TITLE;
        }

        string _SQLConnectionString;
        int comboBoxFromIndex = 0, comboBoxToIndex = 0;
        List<CurrencyByValue> tagList = new List<CurrencyByValue>();
        DateTime timeLeft;
        int RSSLinkUpdateInMinutes=60;

        public MainForm()
        {
            InitializeComponent();

            _SQLConnectionString = ConfigurationSettings.AppSettings["SQLConnectionString"];
            try { RSSLinkUpdateInMinutes = Convert.ToInt32(ConfigurationSettings.AppSettings["RSSLinkUpdateInMinutes"]); } catch { }
            if (RSSLinkUpdateInMinutes > 60 * 24) RSSLinkUpdateInMinutes = 60 * 24; 
            timeLeft = new DateTime();
            timeLeft = DateTime.Now.AddMinutes(RSSLinkUpdateInMinutes);
            GetAllCurrenciesFromRSS();
            GetValuesFromCurrencyByDate();
            UpdateTagList();
            timer1.Enabled = true;
        }

        public void ParseRSS(int ID, string feedUrl)
        {
            SqlConnection con = new SqlConnection(_SQLConnectionString);
            try
            {
                var readerTask = FeedReader.ReadAsync(feedUrl);
                readerTask.ConfigureAwait(false);

                con.Open();

                foreach (var item in readerTask.Result.Items)
                {
                    string[] result;
                    result = item.Title.Split(' ');

                    try
                    {
                        float value;
                        try { value = Convert.ToSingle(result[0]); }
                        catch { value = Convert.ToSingle(result[0].Replace('.', ',')); }

                        string sql = "insert into CurrencyByDate(C_ID,DT,VAL) values(@C_ID,@DT,@VAL)";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("C_ID", ID);
                        cmd.Parameters.AddWithValue("DT", result[5]);
                        cmd.Parameters.AddWithValue("VAL", value);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            catch { }
            finally
            {
                con.Close();
            }
        }

        public void GetAllCurrenciesFromRSS()
        {
            string sql = "select * from Currency where ID > 0 order by NAME";
            SqlConnection cnn = new SqlConnection(_SQLConnectionString);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cnn.Close(); cnn.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow MyReader = ds.Tables[0].Rows[i];

                var ID = Convert.ToInt16(MyReader["ID"].ToString());
                var RSSLINK = MyReader["RSSLINK"].ToString();
                ParseRSS(ID, RSSLINK);
            }
        }

        public void GetValuesFromCurrencyByDate()
        {
            try
            {
                string sql = "select distinct DT from CurrencyByDate order by DT desc";
                SqlConnection cnn = new SqlConnection(_SQLConnectionString);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cnn.Close(); cnn.Dispose();
                comboBoxDT.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow MyReader = ds.Tables[0].Rows[i];
                    comboBoxDT.Items.Add(MyReader["DT"].ToString());
                }
                if ((comboBoxDT.Items.Count > 0) && (comboBoxDT.SelectedIndex == -1)) comboBoxDT.SelectedIndex = 0;
            }
            catch { }
        }

        public void UpdateTagList()
        {
            if (comboBoxDT.Items.Count > 0)
                try
                {
                    string sql = "select Currency.*, CurrencyByDate.VAL from Currency, CurrencyByDate where Currency.ID = CurrencyByDate.C_ID ";
                    sql += " and DT = @DT";
                    sql += " order by NAME";
                    SqlConnection cnn = new SqlConnection(_SQLConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("DT", comboBoxDT.Items[comboBoxDT.SelectedIndex]);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cnn.Close(); cnn.Dispose();
                    comboBoxFrom.Items.Clear();
                    comboBoxTo.Items.Clear();
                    comboBoxFrom.Items.Add("EUR");
                    comboBoxTo.Items.Add("EUR");
                    //comboBoxFrom.SelectedIndex = comboBoxTo.SelectedIndex = 0;

                    tagList.Clear();
                    var item2 = new CurrencyByValue();
                    item2.ID = 0;
                    item2.NAME = "EUR";
                    item2.TITLE = "EUR";
                    item2.VALUE = 1;
                    tagList.Add(item2);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow MyReader = ds.Tables[0].Rows[i];
                        var item = new CurrencyByValue();
                        item.ID = Convert.ToInt16(MyReader["ID"].ToString());
                        item.NAME = MyReader["NAME"].ToString();
                        item.TITLE = MyReader["TITLE"].ToString();
                        item.VALUE = Convert.ToSingle(MyReader["VAL"].ToString());
                        tagList.Add(item);
                        comboBoxFrom.Items.Add(item.NAME);
                        comboBoxTo.Items.Add(item.NAME);
                    }

                    comboBoxFrom.SelectedIndex = comboBoxFromIndex;
                    comboBoxTo.SelectedIndex = comboBoxToIndex;
                }
                catch { }
        }

        public void MakeConversion()
        {
            try
            {
                if (comboBoxFrom.SelectedIndex >= 0) comboBoxFromIndex = comboBoxFrom.SelectedIndex;
                if (comboBoxTo.SelectedIndex >= 0) comboBoxToIndex = comboBoxTo.SelectedIndex;

                float from, to, amount=0, result;
                from = tagList[comboBoxFromIndex].VALUE;
                to = tagList[comboBoxToIndex].VALUE;
                labelFrom.Text = from.ToString();
                labelTo.Text = to.ToString();
                try
                {
                    amount = Convert.ToSingle(tbAmount.Text.Replace(',', '.'));
                }
                catch
                {
                    try { amount = Convert.ToSingle(tbAmount.Text.Replace('.', ',')); }
                    catch { }
                }
                    result = to / from * amount;
                labelResult.Text = result.ToString() + " " + comboBoxTo.Items[comboBoxTo.SelectedIndex];
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBoxForm = new AboutBox1();
            aboutBoxForm.Show();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currencyForm = new Currency();
            currencyForm.Show();
        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeConversion();
        }

        private void comboBoxDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTagList();
            MakeConversion();
        }

        private void displayHistoricalDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayHistoricalDatesToolStripMenuItem.Checked = !displayHistoricalDatesToolStripMenuItem.Checked;
            labelDT.Visible = comboBoxDT.Visible = displayHistoricalDatesToolStripMenuItem.Checked;
            if(!comboBoxDT.Visible)
            {
                comboBoxDT.SelectedIndex = 0;
                comboBoxDT_SelectedIndexChanged(sender, e);
            }
        }

        private void displayRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayRatesToolStripMenuItem.Checked = !displayRatesToolStripMenuItem.Checked;
            labelFrom.Visible = labelRate.Visible = labelTo.Visible = displayRatesToolStripMenuItem.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var dt = new DateTime();
            dt = DateTime.Now;

            if (timeLeft <= dt)
            {
                GetAllCurrenciesFromRSS();
                timeLeft = dt.AddMinutes(RSSLinkUpdateInMinutes);
            }
            else
            {
                TimeSpan span = timeLeft.Subtract(dt);
                toolStripStatusLabel2.Text = "Next currency update: " + timeLeft.ToLongTimeString();
            }
            toolStripStatusLabel1.Text = dt.ToShortDateString() + " " + dt.ToLongTimeString();
        }
    }
}
