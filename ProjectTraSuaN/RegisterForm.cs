using Newtonsoft.Json;
using ProjectTraSuaN.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTraSuaN
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            var requestLogin = new RequestRegister()
            {
                NameUser = txtUser.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Pass = txtPass.Text.Trim(),
                Role = "staff"

            };

            if (txtPass.Text != txtPassConf.Text)
            {
                MessageBox.Show("nhap lai mat khau sai", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                txtPassConf.Text = "";



            }

            else
            {
                using (var httpClinet = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(requestLogin), Encoding.UTF8, "application/json");
                    using (var jwt = await httpClinet.GetAsync("http://localhost:4000/api/token"))
                    {
                        string jwtToken = await jwt.Content.ReadAsStringAsync();
                        httpClinet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                        MessageBox.Show(jwtToken);

                        using (var response = await httpClinet.PostAsync("http://localhost:4000/api/user/createuser", content))
                        {
                            string token = await response.Content.ReadAsStringAsync();
                            if (token == "UserName da ton tai")
                            {
                                MessageBox.Show("UserName da ton tai", "Dang nhap khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUser.Text = "";
                            }
                            else if (token == "Email da dang ky")
                            {
                                MessageBox.Show("Email da dang ky", "Dang nhap khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Text = "";
                            }
                            else if (token == "Phone da dang ky")
                            {
                                MessageBox.Show("Phone da dang ky", "Dang nhap khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPhone.Text = "";
                            }
                            else if (token == "")
                            {
                                MessageBox.Show("Chi co admin co the dang ky cho nhan vien", "Dang nhap khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            else
                            {
                                this.Hide();
                                Home homeUi = new Home();
                                homeUi.ShowDialog();

                            }
                        }

                    }

                }

           

            }

        }
    }
}
