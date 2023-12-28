using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form3Puzzles : PuzzleBaseForm
    {
        public Form3Puzzles()
        {
            InitializeComponent();
            lblMovesMade.Text += inmoves;

            lblTimeElapsed.Text = "00:00:00";

            originalImage = Properties.Resources.mewtwo; // chỗ này là tên ảnh nè
            images = CropImageToPieces(originalImage, 594/ 2, 594 /2);
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //Shuffle(this.groupBox1);
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
                Shuffle(this.groupBox1);
                timer.Reset();
                lblTimeElapsed.Text = "00:00:00";
                inmoves = 0;
                lblMovesMade.Text = "Moves Made : 0";
            }
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

        private void SwitchPictureBox(object sender, EventArgs e)
        {
            int inPictureBoxIndex = 0;
            if (lblTimeElapsed.Text == "00:00:00")
                timer.Start();
            if (gridSize == 2)
            {
                inPictureBoxIndex = groupBox1.Controls.IndexOf(sender as Control);
            }

            if (CanMove(inPictureBoxIndex))
            {
                if (gridSize == 2)
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
                    //(gbPuzzleBox.Controls[8] as PictureBox).Image = lstOriginalPictureList[8];

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

        private void Btn_Autowin_Click(object sender, EventArgs e)
        {
            timer.Stop();
           

            MessageBox.Show("Bạn đã chiến thắng! Bạn có muốn chuyển sang màn 2 không?", "Thông báo", MessageBoxButtons.YesNo);

            // Nếu người dùng chọn "Yes"
            if (DialogResult == DialogResult.Yes)
            {
                // Thực hiện các bước để chuyển sang màn 2
                // Ví dụ: 
                // Màn 2 có thể là một form mới, bạn có thể tạo một đối tượng mới và hiển thị nó.

                Form8Puzzles form2 = new Form8Puzzles();
                this.Hide();
                form2.ShowDialog();
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
