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

        public Game()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

    
        private void AssignIconsToSquares()
        {
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
            }

        }
    }
}