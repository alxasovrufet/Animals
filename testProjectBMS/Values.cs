
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace testProjectBMS
{
    public partial class Values : Form
    {
        public Values()
        {
            InitializeComponent();
        }

        private void Values_Load(object sender, EventArgs e)
        {
            GetRESTData("https://cat-fact.herokuapp.com/facts/random?animal_type=" + Value.animal.ToLower() + "&amount=" + Value.pieces.ToString());
            dataGridView1.Columns[0].HeaderText = "Used";
            dataGridView1.Columns[1].HeaderText = "Source";
            dataGridView1.Columns[2].HeaderText = "Type";
            dataGridView1.Columns[3].HeaderText = "Deleted";
            dataGridView1.Columns[4].HeaderText = "ID";
            dataGridView1.Columns[5].HeaderText = "User";
            dataGridView1.Columns[6].HeaderText = "Text";
            dataGridView1.Columns[7].HeaderText = "Created_At";
            dataGridView1.Columns[8].HeaderText = "Updated_At";
            dataGridView1.Columns[9].HeaderText = "V";
            dataGridView1.Columns[10].HeaderText = "Status";


           
        }

        private void GetRESTData(string uri)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<JArray>(s);
                    dataGridView1.DataSource = arr;
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
