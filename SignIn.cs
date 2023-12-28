using System;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            SignUp dky = new SignUp();
            dky.Show();
        }

        Modify modify = new Modify();

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            string usn = tb_Username.Text;
            string pw = tb_Password.Text;
            if (usn.Trim() == string.Empty || pw.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                string query = "Select * from PLAYER where USERNAME = '" + usn + "' and PASSWORD = '" + pw + "'";
                if (modify.players(query).Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    StartScreen startScreen = new StartScreen(usn);
                    startScreen.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản/Mật khẩu sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
