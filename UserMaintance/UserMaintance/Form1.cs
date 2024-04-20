using System.ComponentModel;
using System.Text;
using UserMaintance.Entities;

namespace UserMaintance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.Write;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
            {
                // Végigmegyünk a hallgató lista elemein
                foreach (var s in users)
                {
                    // Egy ciklus iterációban egy sor tartalmát írjuk a fájlba
                    // A StreamWriter Write metódusa a WriteLine-al szemben nem nyit új sort
                    // Így darabokból építhetjük fel a csv fájl pontosvesszõvel elválasztott sorait
                    sw.Write(s.ID);
                    sw.Write(";");
                    sw.Write(s.FullName);
                    sw.WriteLine();
                }
            }
        }
    }
}
