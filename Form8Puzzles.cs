using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PuzzleGame
{

    public partial class Form8Puzzles : PuzzleBaseForm
    {
        public Form8Puzzles()
        {
            gridSize = 3;
            InitializeComponent();
            lblMovesMade.Text += inmoves;
            lblTimeElapsed.Text = "00:00:00";
            originalImage = Properties.Resources.original; // chỗ này là tên ảnh nè
            images = CropImageToPieces(originalImage, 594 / 3, 594 / 3);
        }

        public Form8Puzzles(string username) : this()
        {
            Username = username;
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Shuffle(this.gbPuzzleBox);
        }

        private void SwitchPictureBox(object sender, EventArgs e)
        {
            int inPictureBoxIndex = 0;
            if (lblTimeElapsed.Text == "00:00:00")
                timer.Start();

            if (gridSize == 3)
            {
                inPictureBoxIndex = gbPuzzleBox.Controls.IndexOf(sender as Control);
            }
            if (CanMove(inPictureBoxIndex))
            {
                if (gridSize == 3)
                {
                    SwapImages((PictureBox)gbPuzzleBox.Controls[inNullSliceIndex],
                    (PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]);
                }

                inNullSliceIndex = inPictureBoxIndex;
                lblMovesMade.Text = "Moves Made : " + (++inmoves);

                if (CheckWin(this.gbPuzzleBox))
                {
                    timer.Stop();
                    MessageBox.Show("Xin chúc mừng!\nBạn đã chiến thắng!\nThời gian hoàn thành : " + timer.Elapsed.ToString().Remove(8) + "\nSố nước đi : " + inmoves, "Puzzle Game");
                    if (MessageBox.Show("Bạn có muốn lưu lại kết quả lần này?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Modify mod = new Modify();
                        mod.Command("Update PLAYER Set ATTEMPTS = '" + inattempts + "', TIME = '" + Convert.ToInt32(timer.Elapsed.TotalSeconds) + "', MOVES ='" + inmoves + "' , SCORE = '" + 10e6 * 1.0 / (Convert.ToInt32(timer.Elapsed.TotalSeconds) + 2 * inmoves) + "' where USERNAME = '" + Username + "'");
                    }

                    inmoves = 0;
                    lblMovesMade.Text = "Moves Made : 0";
                    lblTimeElapsed.Text = "00:00:00";
                    timer.Reset();
                    if (MessageBox.Show("Do you want to proceed to the next level?", "Next Level", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Form15Puzzles nextlevel = new Form15Puzzles();
                        this.Hide();
                        nextlevel.Show();
                    }
                }
            }
        }



        private void btnQuit_Click(object sender, EventArgs e)
        {
            AskPermissionBeforeQuite(sender, e as FormClosingEventArgs);
        }


        private void UpdateTimeElapsed(object sender, EventArgs e)
        {
            if (timer.Elapsed.ToString() != "00:00:00")
                lblTimeElapsed.Text = timer.Elapsed.ToString().Remove(8);
            if (timer.Elapsed.ToString() == "00:00:00")
                btnPause.Enabled = false;
            else
                btnPause.Enabled = true;
            if (timer.Elapsed.Minutes.ToString() == "5")
            {
                timer.Reset();
                lblMovesMade.Text = "Moves Made : 0";
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                btnPause.Enabled = false;
                MessageBox.Show("Time Is Up\nTry Again", "Puzzle Game");
                Shuffle(this.gbPuzzleBox);
            }
        }

        private void PauseOrResume(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                timer.Stop();
                gbPuzzleBox.Visible = false;
                btnPause.Text = "Resume";
            }
            else
            {
                timer.Start();
                gbPuzzleBox.Visible = true;
                btnPause.Text = "Pause";
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            DialogResult YesOrNo = new DialogResult();
            if (lblTimeElapsed.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show("Are You Sure To RESTART ?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (YesOrNo == DialogResult.Yes || lblTimeElapsed.Text == "00:00:00")
            {
                inattempts++;
                Shuffle(this.gbPuzzleBox);
                timer.Reset();
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                lblMovesMade.Text = "Moves Made : 0";
            }
        }
        private List<Image> GetCurrentImageList()
        {
            List<Image> currentImageList = new List<Image>();

            foreach (Control control in gbPuzzleBox.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    currentImageList.Add(pictureBox.Image);
                }
            }

            return currentImageList;
        }

        private void btn_Autowin_Click(object sender, EventArgs e) // nút điếm thúi, xong con game nhớ gỡ
        {
            timer.Stop();
            MessageBox.Show("Xin chúc mừng!\nBạn đã chiến thắng!\nThời gian hoàn thành : " + timer.Elapsed.TotalSeconds + "\nSố nước đi : " + inmoves, "Puzzle Game");
            if (MessageBox.Show("Bạn có muốn lưu lại kết quả lần này?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Modify mod = new Modify();
                mod.Command("Update PLAYER Set ATTEMPTS = '" + inattempts + "', TIME = '" + Convert.ToInt32(timer.Elapsed.TotalSeconds) + "', MOVES ='" + inmoves + "' , SCORE = '" + 10e6 * 1.0 / (Convert.ToInt32(timer.Elapsed.TotalSeconds) + 2 * inmoves) + "' where USERNAME = '" + Username + "'");
            }
            //(gbPuzzleBox.Controls[8] as PictureBox).Image = lstOriginalPictureList[8];

            inmoves = 0;
            lblMovesMade.Text = "Moves Made : 0";
            lblTimeElapsed.Text = "00:00:00";
            timer.Reset();
            DialogResult result = MessageBox.Show("Do you want to proceed to the next level?", "Next Level", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Shuffle(this.gbPuzzleBox);
            }
            Application.Exit();
        }

        private void gbOriginal_Enter(object sender, EventArgs e)
        {

        }

        private void frmPuzzleGame_Load(object sender, EventArgs e)
        {
            gridSize = 3;
        }

        private void AskPermissionBeforeQuite(object sender, FormClosingEventArgs e)
        {
            DialogResult YesOrNO = MessageBox.Show("Thoát game ?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sender as Button != btnQuit && YesOrNO == DialogResult.No) e.Cancel = true;
            if (sender as Button == btnQuit && YesOrNO == DialogResult.Yes) Environment.Exit(0);
        }
    }
}
