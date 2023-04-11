using System.IO;

namespace ukol1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = ""; string znak_pred = "";
            FileStream datovy_tok = new FileStream("cisla.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(datovy_tok);
            bw.Write(textBox1.Text);


            BinaryReader br = new BinaryReader(datovy_tok);
            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                text = br.ReadString();
            }
            bool otaznik = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '?')
                {
                    MessageBox.Show("Poøadí v souboru: " + (i + 1).ToString());
                    MessageBox.Show("Znak pøed: " + znak_pred);
                    otaznik = true;
                }
                else
                {
                    znak_pred = text[i].ToString();
                }
            }
            if (!otaznik)
            {
                MessageBox.Show("Špatnì zadaný text");
            }
            datovy_tok.Close();
        }

        bool once = true;
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {    
            if (once)
            { 
            textBox1.Text = "";
            once = false;
            }
        }
    }
}