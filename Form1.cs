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

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 30;
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dd = ofd.ShowDialog();


            
            if (dd == DialogResult.OK)
            {
                progressBar1.PerformStep();
                progressBar1.Value = 60;
                var Ocr = new IronTesseract();

                textBox1.Text = ofd.FileName;

                using (var input = new OcrInput())
                {
                    input.AddPdf(ofd.FileName, textBox2.Text);
                    var Result = Ocr.Read(input);
                    progressBar1.Value = 75;
                    Console.WriteLine(Result.Text);
                    MessageBox.Show($"{Result.Pages.Count()} páginas procesadas","Terminado");
                    Console.WriteLine($"{Result.Pages.Count()} páginas procesadas");

                    richTextBox1.Text = Result.Text;


                    progressBar1.Value = 100;
                    // 1 page for every page of the PDF
                }

            }
            else
            {
                textBox1.Text = "";
                progressBar1.Value = 0;
                richTextBox1.Text = "";
            }






        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Desea salir de la aplicación ?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }
    }
}