using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using SkiaSharp;

namespace Calculator3D
{
    public partial class Form1 : Form
    {
        SoundPlayer snd;

        //variables
        #region

        double usedFilament; //zu¿yty filament
        double spoolFilament; //ca³a szpula filamentu
        double costFilament; // koszt ca³ej szpuli filamentu
        double margin; //mar¿a
        double totalCostFilament; //ca³kowity koszt filamentu
        double preparationTime;//przygotowanie
        double preparationWork;//przygotowanie roboczogodzina
        double treatmentTime; //obróbka
        double treatmentWork;//obróbka roboczogodzina
        double totalCostWork; //ca³kowity koszt filamentu
        double costPrinter;
        double energyConsumption;//zu¿ycie energii
        double energyCost;//koszt energii
        double totalCostOther; //ca³kowity koszt filamentu
        double vat;
        double totalCost;//koszt obiektu
        double a;
        double b;
        double energy;
        double cost;
        double amor;
        double energyL;
        double xProj;
        double spool;
        double materialF;
        double premia;
        double rabat;

        //Boolean colorButton = true;
        string docFile;
        string name3D;
        string material;
        string namePrinter;




        //decimal test = 4.434m;
        #endregion
        
        //Time
        DateTime today = DateTime.Now;

        //Methods calculation
        #region
        void Calculation1()
        {
            //totalCostFilament
            
            if (margin < 0 || usedFilament <= 0 || spoolFilament <= 0 || costFilament <= 0)
            {
                totalCostFilament = 0;
                label37.Text = totalCostFilament.ToString("0.00");
                label50.Text = premia.ToString("0.00");
            }
            else if (margin == 0)
            {
                spool = costFilament / spoolFilament; //0.1
                materialF = spool * usedFilament;
                totalCostFilament = materialF;
                premia = totalCostFilament - materialF;
                label37.Text = totalCostFilament.ToString("0.00");
                label50.Text = premia.ToString("0.00");
            }
            else
            {
                spool = costFilament / spoolFilament; //0.1
                materialF = spool * usedFilament;
                totalCostFilament = (materialF + (materialF * (margin / 100)));
                premia = totalCostFilament - materialF;
                label37.Text = totalCostFilament.ToString("0.00");
                label50.Text = premia.ToString("0.00");
            }

        }

        void Calculation2()
        {
            double minutes = 1;
            double hour = 60 * minutes;
            a = preparationWork * preparationTime / hour;
            b = treatmentWork * treatmentTime / hour;
            totalCostWork = a + b;
            label38.Text = totalCostWork.ToString("0.00");
            label45.Text = a.ToString("0.00");
            label46.Text = b.ToString("0.00");

        }

        void Calculation3()
        {   
            energy = energyConsumption * energyCost;
            totalCostOther = costPrinter * 0.0005 + energy / 1000;
            label39.Text = totalCostOther.ToString("0.00");
            amor = costPrinter * 0.0005;
            energyL = energy / 1000;
            label48.Text = amor.ToString("0.00");
            label49.Text = energyL.ToString("0.00");
        }



        void Calculation4()
        {
            double a;
                cost = (totalCostOther + totalCostWork + totalCostFilament + xProj) * vat / 100;
                totalCost = cost + (totalCostOther + totalCostWork + totalCostFilament + xProj);
                a = totalCost - rabat;
                totalCost = a;
                label40.Text = totalCost.ToString("0.00");
                label59.Text = cost.ToString("0.00");
        }


        /*
        void ButtonDefault()
        {
            if(colorButton == false)
            {
                button4.BackColor = Color.SandyBrown;
                colorButton = false;
            }
            else
            {
                button4.BackColor = Color.LightBlue;
                colorButton = true;
            }
            colorButton = !colorButton;
        }
        */
        #endregion


       
        public Form1()
        {

            InitializeComponent();
            snd = new SoundPlayer("1.wav");
            snd.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            timer1.Enabled = true;



        }

        // Label & textBox
        #region
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"http://www.mefiu.pl", UseShellExecute = true });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                usedFilament = Convert.ToDouble(textBox5.Text);
                Calculation1();
                Calculation4();
            }
            catch
            {
                usedFilament = 0;
                Calculation1();
                Calculation4();
                //ButtonDefault();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                costFilament = Convert.ToDouble(textB.Text);
                Calculation1();
                Calculation4();
            }
            catch
            {
                costFilament = 0;
                Calculation1();
                Calculation4();
                //ButtonDefault();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                spoolFilament = Convert.ToDouble(nr3.Text);
                Calculation1();
                Calculation4();
            }
            catch
            {
                spoolFilament = 0;
                Calculation1();
                Calculation4();
                //ButtonDefault();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                margin = Convert.ToDouble(tex.Text);
                Calculation1();
                Calculation4();
            }
            catch
            {
                margin = 0;
                //ButtonDefault();
                Calculation1();
                Calculation4();
            }
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            Calculation1();
            button1.BackColor = Color.LightSalmon;
            //button1.ForeColor = Color.Red;
        }
        */

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                preparationTime = Convert.ToDouble(textBox511.Text);
                Calculation2();
                Calculation4();
            }
            catch
            {
                preparationTime = 0;
                Calculation2();
                Calculation4();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                preparationWork = Convert.ToDouble(textBox6.Text);
                Calculation2();
                Calculation4();
            }
            catch
            {
                preparationWork = 0;
                Calculation2();
                Calculation4();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                treatmentTime = Convert.ToDouble(textBox7.Text);
                Calculation2();
                Calculation4();
            }
            catch
            {
                treatmentTime = 0;
                Calculation2();
                Calculation4();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                treatmentWork = Convert.ToDouble(textBox8.Text);
                Calculation2();
                Calculation4();
            }
            catch
            {
                treatmentWork = 0;
                Calculation2();
                Calculation4();
            }
        }
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            Calculation2();
            button2.BackColor = Color.LightSalmon;
        }
        */

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                costPrinter = Convert.ToDouble(textBox9.Text);
                Calculation3();
                Calculation4();
            }
            catch
            {
                costPrinter = 0;
                Calculation3();
                Calculation4();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                energyConsumption = Convert.ToDouble(textBox10.Text);
                Calculation3();
                Calculation4();
            }
            catch
            {
                energyConsumption = 0;
                Calculation3();
                Calculation4();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                energyCost = Convert.ToDouble(textBox11.Text);
                Calculation3();
                Calculation4();
            }
            catch
            {
                energyCost = 0;
                Calculation3();
                Calculation4();
            }
        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            Calculation3();
            button3.BackColor = Color.LightSalmon;
        }
        */


        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vat = Convert.ToDouble(textBox12.Text);
                Calculation4();
            }
            catch
            {
                vat = 0;
                Calculation4();
            }
            label59.Text = cost.ToString("0.00");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculation4();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        
        #region
        private void button5_Click(object sender, EventArgs e)
        {
            // to boximage
            
        }
        #endregion

        // More label & textBox
        #region
        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            docFile = textBox16.Text;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            name3D = textBox2.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
           
            material = textBox1.Text;  
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            namePrinter = textBox3.Text;

        }

        private void label37_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            
           

        }

        private void label45_Click(object sender, EventArgs e)
        {
            label45.Text = a.ToString("0.00");
        }

        private void label46_Click(object sender, EventArgs e)
        {
            label46.Text = b.ToString("0.00");
        }

        private void label47_Click(object sender, EventArgs e)
        {
            
        }

        private void label48_Click(object sender, EventArgs e)
        {
            label48.Text = cost.ToString("0.00");
        }

        private void label49_Click(object sender, EventArgs e)
        {
            label49.Text = energyL.ToString("0.00");
        }

        private void label50_Click(object sender, EventArgs e)
        {
            label50.Text = premia.ToString("0.00");
        }

        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged_2(object sender, EventArgs e)
        {
          
            try
            {
                rabat = Convert.ToDouble(textBox17.Text);
                Calculation4();
            }
            catch
            {
                rabat = 0;
                Calculation4();
            }
            label61.Text = rabat.ToString("0.00");

        }

        private void label53_Click(object sender, EventArgs e)
        {
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox18_TextChanged_2(object sender, EventArgs e)
        {
            
            try
            {
                xProj = Convert.ToDouble(textBox4.Text);
                Calculation4();
            }
            catch
            {
                xProj = 0;
                Calculation4();
            }
            label57.Text = xProj.ToString("0.00");
            
        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {
          
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void label59_Click(object sender, EventArgs e)
        {
            
        }

        private void label61_Click(object sender, EventArgs e)
        {
            label61.Text = rabat.ToString();
            
        }

        private void label59_Click_1(object sender, EventArgs e)
        {
            label59.Text = cost.ToString("0.00");
        }

        private void textBox4_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion
        // PDF generation
        #region

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            // code in your main method
            Document.Create(container =>
            {

                container.Page(page =>
                {

                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(18));

                    page.Header()
                        .Text("Nazwa modelu: " + name3D)
                        .SemiBold().FontSize(25).FontColor(Colors.Blue.Medium);


                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {

                            costPrinter.ToString("0,00");

                            x.Spacing(6);

                            x.Item().Text("Sprzêt drukuj¹cy:  " + namePrinter).FontSize(17);
                            x.Item().Text("Typ filamentu:  " + material).FontSize(17);
                            x.Item().Text("Wystawiono:  " + today).FontSize(17);
                            x.Item().Text("  ");
                            x.Item().Text("KOSZT PROJEKTU - PLIK STL:  " + label57.Text + " PLN").FontSize(17);
                            x.Item().Text("  ");
                            x.Item().Text("KOSZTY FILAMENTU:  " + label37.Text + " PLN").FontSize(17);
                            x.Item().Text("*zu¿yty filament: " + usedFilament + " gram" + "  *mar¿a: " + margin + "%").FontSize(17);
                            x.Item().Text("  ").FontSize(17);
                            x.Item().Text("KOSZTY ROBOCIZNY:  " + label38.Text + "  PLN").FontSize(17);
                            x.Item().Text("*przygotowanie modelu:  " + label45.Text + "  PLN").FontSize(17);
                            x.Item().Text("*post procesing obiektu:  " + label46.Text + "  PLN").FontSize(17);
                            x.Item().Text("  ").FontSize(17);
                            x.Item().Text("INNE KOSZTY:  " + label39.Text + " PLN").FontSize(17);
                            x.Item().Text("*amortyzacja drukarki:  " + label48.Text + " PLN").FontSize(17);
                            x.Item().Text("*energia elektryczna:  " + label49.Text + " PLN").FontSize(17);
                            x.Item().Text("*VAT " + vat + " % to  " + label59.Text + " PLN").FontSize(17);
                            x.Item().Text("  ");
                            x.Item().Text("Rabat:  -" + label61.Text + " PLN").FontSize(17);
                            x.Item().Text("KOSZT CA£KOWITY:  " + label40.Text + " PLN")
                            .Bold().Underline().FontSize(17);






                        });
                    /*
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                    */
                });
            })
           .GeneratePdf(docFile + ".pdf");
            DialogResult window;
            window = MessageBox.Show("Plik " + docFile + " znajduje siê w folderze 'Calculation3D'",
                "Wygenerowano PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Okienko
        }
        #endregion
    }
    
}