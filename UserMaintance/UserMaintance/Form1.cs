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
            button3.Text = Resource1.Delete;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Kiválasztott elem indexének lekérése
                int selectedIndex = listBox1.SelectedIndex;

                // Az elem törlése a users listából
                if (selectedIndex < users.Count)
                {
                    users.RemoveAt(selectedIndex);

                    // ListBox frissítése az adatváltozások tükrözésére
                    listBox1.DataSource = null; // Elõször töröld a DataSource-t
                    listBox1.DataSource = users; // Állítsd be újra a users listát adatforrásként
                    listBox1.DisplayMember = "FullName";

                    MessageBox.Show("Elem sikeresen törölve.");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem.");
            }
        }
    }
}
