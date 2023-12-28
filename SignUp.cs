using System;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            string usn = tb_Username.Text;
            string pw = tb_Password.Text;
            string cpw = tb_ConfirmPW.Text;
            string name = tb_Name.Text;
            if (pw != cpw)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác!");
                return;
            }
            try
            {
                string query = "Insert into PLAYER values ('" + usn + "', '" + pw + "', '" + name + "', NULL, NULL, NULL, NULL)";
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công, về màn hình đăng nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Hide();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
