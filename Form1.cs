using IronOcr;
using Microsoft.VisualBasic;

namespace OCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            

        }
        delegate void RefreshProgressDelegate(int percent);
        public void RefreshProgress(int value)
        {
            if (this == null) return;
            progressBar1.Value = (int)value;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Invoke(new RefreshProgressDelegate(RefreshProgress), 30);
            OpenFileDialog ofd = new();
            DialogResult dd = ofd.ShowDialog();
                        
            if (dd == DialogResult.OK)
            {
                progressBar1.PerformStep();
                this.Invoke(new RefreshProgressDelegate(RefreshProgress), 60);
                var Ocr = new IronTesseract();

                textBox1.Text = ofd.FileName;

                using var input = new OcrInput();
                input.AddPdf(ofd.FileName, textBox2.Text);
                var Result = Ocr.Read(input);
                this.Invoke(new RefreshProgressDelegate(RefreshProgress), 75);
                Console.WriteLine(Result.Text);
                MessageBox.Show($"{Result.Pages.Length} páginas procesadas", "Terminado");
                Console.WriteLine($"{Result.Pages.Length} páginas procesadas");

                richTextBox1.Text = Result.Text;


                this.Invoke(new RefreshProgressDelegate(RefreshProgress), 100);
                // 1 page for every page of the PDF

            }
            else
            {
                textBox1.Text = "";
                progressBar1.Value = 0;
                richTextBox1.Text = "";
            }




        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Desea salir de la aplicación ?", "Alert!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        
    }
}