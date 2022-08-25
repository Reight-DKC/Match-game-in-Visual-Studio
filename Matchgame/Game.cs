using System.Media;
using System.Diagnostics;


namespace Matchgame
{
    public partial class Game : Form
    {
        private Random random = new Random();
        private List<string> icons = new List<string>() {
            "!", "!", "N", "N",
            ",", ",", "k", "k",
            "b", "b", "v", "v",
            "w", "w", "z", "z",
        };
        Label? firstClicked = null;
        Label? secondClicked = null;

        public Game()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        SoundPlayer sonido = new SoundPlayer();
       

        private void AssignIconsToSquares()
        {
            timer2.Start();
            foreach (Control control in table.Controls)
            {
                Label? iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }

        }

        private void Game_Load(object sender, EventArgs e)
        {
        }

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }
            Label? clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                {              
                    return;
                }
                if (firstClicked == null)
                {
                    sonido.Stream = Properties.Resources.click;
                    sonido.Play();
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    sonido.Stream = Properties.Resources.logro;
                    sonido.Play();
                    return;
                }
                sonido.Stream = Properties.Resources.error;
                sonido.Play();
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in table.Controls)
            {
                Label? iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }
            timer2.Stop();
            MessageBox.Show("You won the mach game!", "Congratulations");
            MessageBox.Show(myLabel);
            Close();
        }

        private int i = 0;

        private string myLabel;


        private void timer2_Tick(object sender, EventArgs e)
        {
            i++;
            myLabel = "Match Duration:" + i.ToString() + "seconds";
        }
    }
} 