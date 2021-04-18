using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace ConvertCurrencyTool
{
    public partial class Currency : Form
    {
        public class CurrencyRecord
        {
            public int ID;
            public string NAME;
            public string TITLE;
            public string RSSLINK;
        }
        string _SQLConnectionString;
        bool newRecord;
        List<CurrencyRecord> tagList = new List<CurrencyRecord>();
        public Currency()
        {
            newRecord = false;
            _SQLConnectionString = ConfigurationSettings.AppSettings["SQLConnectionString"];
            InitializeComponent();
        }
           
        public void GenerateTagList()
        {
            string sql = "select * from Currency where ID > 0 order by NAME";
            SqlConnection cnn = new SqlConnection(_SQLConnectionString);
            SqlCommand cmdGam = new SqlCommand(sql, cnn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmdGam);
            da.Fill(ds);
            TaglistBox.Items.Clear();
            tagList.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow MyReader = ds.Tables[0].Rows[i];
                TaglistBox.Items.Add(MyReader["NAME"].ToString());

                var tag = new CurrencyRecord();
                tag.ID = Convert.ToInt16(MyReader["ID"].ToString());
                tag.NAME = MyReader["NAME"].ToString();
                tag.TITLE = MyReader["TITLE"].ToString();
                tag.RSSLINK = MyReader["RSSLINK"].ToString();
                tagList.Add(tag);
            }
            if (tagList.Count > 0) TaglistBox.SelectedIndex = 0;
            cnn.Close(); cnn.Dispose();
            newRecord = false;
        }

        private void Tags_Load(object sender, EventArgs e)
        {
            GenerateTagList();
        }

        private void TaglistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = TaglistBox.SelectedIndex;
                ID.Value = tagList[i].ID;
                NAME.Text = tagList[i].NAME;
                TITLE.Text = tagList[i].TITLE;
                RSSLINK.Text = tagList[i].RSSLINK;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newRecord = true;
            NAME.Text = "";
            TITLE.Text = "";
            RSSLINK.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((NAME.Text.Trim().Length == 0) ||
                (TITLE.Text.Trim().Length == 0) ||
                (RSSLINK.Text.Trim().Length == 0)
                )
            { MessageBox.Show("Please fill the fields!"); }
            else {
                int i = TaglistBox.SelectedIndex;
                SqlConnection con = new SqlConnection(_SQLConnectionString);
                if (newRecord)
                {
                    try
                    {
                        con.Open();
                        string sql = "insert into Currency(NAME,TITLE,RSSLINK) values(@NAME,@TITLE,@RSSLINK)";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("NAME", NAME.Text);
                        cmd.Parameters.AddWithValue("TITLE", TITLE.Text);
                        cmd.Parameters.AddWithValue("RSSLINK", RSSLINK.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting a new record!" + ex.Message.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    try
                    {
                        con.Open();
                        string sql = "update Currency set ";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        sql += " NAME=@NAME, TITLE=@TITLE, RSSLINK=@RSSLINK ";
                        sql += " where ID=@ID";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("NAME", NAME.Text);
                        cmd.Parameters.AddWithValue("TITLE", TITLE.Text);
                        cmd.Parameters.AddWithValue("RSSLINK", RSSLINK.Text);
                        cmd.Parameters.AddWithValue("ID", ID.Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error updating a record!");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                GenerateTagList();
                TaglistBox.SelectedIndex = i;
                TaglistBox_SelectedIndexChanged(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are You sure You want to delete record " + NAME.Text + ". " + TITLE.Text + "?", "Are You sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(_SQLConnectionString);
                    try
                    {
                        string sql;
                        SqlCommand cmd;
                        con.Open();
                        sql = "Delete from Currency ";
                        sql += " where ID=@ID";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("ID", ID.Value);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch 
                    {
                        MessageBox.Show("Error deleting a record!");
                    }
                    finally
                    {
                        con.Close();
                    }
                    GenerateTagList();
                }
            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
