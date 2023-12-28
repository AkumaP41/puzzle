using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form15Puzzles : PuzzleBaseForm
    {
        public Form15Puzzles()
        {
            InitializeComponent();
            gridSize = 4;
            lblMovesMade.Text += inmoves;

            lblTimeElapsed.Text = "00:00:00";

            originalImage = Properties.Resources.candy; // chỗ này là tên ảnh nè
            images = CropImageToPieces(originalImage, 150, 150);
        }

        private void SwitchPictureBox(object sender, EventArgs e)
        {
            int inPictureBoxIndex = 0;
            if (lblTimeElapsed.Text == "00:00:00")
                timer.Start();
            if (gridSize == 4)
            {
                inPictureBoxIndex = groupBox1.Controls.IndexOf(sender as Control);
            }

            if (CanMove(inPictureBoxIndex))
            {
                if (gridSize == 4)
                {
                    SwapImages((PictureBox)groupBox1.Controls[inNullSliceIndex],
                    (PictureBox)groupBox1.Controls[inPictureBoxIndex]);
                }


                inNullSliceIndex = inPictureBoxIndex;
                lblMovesMade.Text = "Moves Made : " + (++inmoves);

                if (CheckWin(this.groupBox1))
                {
                    timer.Stop();
                    MessageBox.Show("Congratulations...\nYou've done it!\nTime Elapsed : "
                        + timer.Elapsed.ToString().Remove(8) + "\nTotal Moves Made : "
                        + inmoves, "Puzzle Game");
                    MessageBox.Show("Xin chúc mừng!\nBạn đã chiến thắng!\nThời gian hoàn thành : " + timer.Elapsed.ToString().Remove(8) + "\nSố nước đi : " + inmoves, "Puzzle Game");
                    if (MessageBox.Show("Bạn có muốn lưu lại kết quả lần này?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Modify mod = new Modify();
                        mod.Command("Update PLAYER Set TIME = '" + Convert.ToInt32(timer.Elapsed.TotalSeconds) + "', MOVES ='" + inmoves + "' , SCORE = '" + 10e6 * 1.0 / (Convert.ToInt32(timer.Elapsed.TotalSeconds) + 2 * inmoves) + "' where USERNAME = '" + Username + "'");
                    }

                    inmoves = 0;
                    lblMovesMade.Text = "Moves Made : 0";
                    lblTimeElapsed.Text = "00:00:00";
                    timer.Reset();
                    DialogResult result = MessageBox.Show("Do you want to proceed to the next level?", "Next Level", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        Form8Puzzles nextlevel = new Form8Puzzles();
                        this.Hide();
                        nextlevel.Show();


                    }

                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            gridSize = 4;
        }

        private void lblMovesMade_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
                Shuffle(this.groupBox1);
                timer.Reset();
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                lblMovesMade.Text = "Moves Made : 0";
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            AskPermissionBeforeQuite(sender, e as FormClosingEventArgs);
        }

        private void AskPermissionBeforeQuite(object sender, FormClosingEventArgs e)
        {
            DialogResult YesOrNO = MessageBox.Show("Thoát game ?", "Puzzle Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sender as Button != btnQuit && YesOrNO == DialogResult.No) e.Cancel = true;
            if (sender as Button == btnQuit && YesOrNO == DialogResult.Yes) Environment.Exit(0);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                timer.Stop();
                groupBox1.Visible = false;
                btnPause.Text = "Resume";
            }
            else
            {
                timer.Start();
                groupBox1.Visible = true;
                btnPause.Text = "Pause";
            }
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
                Shuffle(this.groupBox1);
            }
        }
    }
}
