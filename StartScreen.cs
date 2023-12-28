using System;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class StartScreen : Form
    {
        private string Username;
        public StartScreen()
        {
            InitializeComponent();
        }
        public StartScreen(string username) : this()
        {
            Username = username;
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            Form8Puzzles PG = new Form8Puzzles(Username);
            //Form1 fr= new Form1();
            this.Hide();
            PG.ShowDialog();
        }

        private void Help_btn_Click(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();
            helpScreen.ShowDialog();
        }

        private void About_btn_Click(object sender, EventArgs e)
        {
            AboutScreen aboutScreen = new AboutScreen();
            aboutScreen.ShowDialog();
        }
    }
}
