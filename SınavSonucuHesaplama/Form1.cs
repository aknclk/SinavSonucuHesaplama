using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Xml.Linq;


namespace SınavSonucuHesaplama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            double sorusayisi = Convert.ToDouble(maskedTextBox1.Text);
            double dogru = Convert.ToDouble(maskedTextBox2.Text);
            double yanlis = Convert.ToDouble(maskedTextBox3.Text);
            double net;
            double bos;

            net = dogru - (yanlis / 4);
            textBox5.Text = net.ToString("0.00");

            bos = sorusayisi - (dogru + yanlis);
            textBox2.Text = bos.ToString();
        }

        int sira = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            sira++;
            richTextBox1.AppendText(Environment.NewLine + sira +"-"+ " "+  textBox1.Text + "     " + "Doğru: " + maskedTextBox2.Text + "     " + "Yanlış: " + maskedTextBox3.Text + "     " + "Boş: " + textBox2.Text + "     " + "Net: " + textBox5.Text);            
        }           
        
        private void button5_Click(object sender, EventArgs e)
        {            

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "PDF DOSYASI (*.pdf) | *.pdf";
            file.Title = "PDF DOSYASI OLUŞTUR";

            if (file.ShowDialog() == DialogResult.OK)
            {                                              
                FileStream rapor = File.Open(file.FileName, FileMode.Create);
                Document pdf = new Document();
                PdfWriter.GetInstance(pdf, rapor);
                pdf.Open();
                pdf.AddCreator("ExamPad"); 
                pdf.AddTitle("Sınav Sonuç Listesi");
                pdf.AddCreationDate();
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1254", true);
                iTextSharp.text.Font yazifontu = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                Paragraph icerik = new Paragraph(richTextBox1.Text, yazifontu);
                pdf.Add(icerik);
                pdf.Close();               

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Akın ÇELİK" + "\n" + "\n" + "Aralık 2022");
        }


        int Movee;
        int Mouse_X;
        int Mouse_Y;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movee == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}




           
