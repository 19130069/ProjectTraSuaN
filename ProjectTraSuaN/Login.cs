using Newtonsoft.Json;
using ProjectTraSuaN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTraSuaN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    

  

        private void remember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var requestLogin = new RequestLogin()
            {
                NameUser = txtUser.Text.Trim(),
                Password = txtPass.Text.Trim(),

            };

            using (var httpClinet=new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(requestLogin), Encoding.UTF8, "application/json");

                using (var response = await httpClinet.PostAsync("http://localhost:4000/api/login",content))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if (token == "Invalid credentials")
                    {
                        MessageBox.Show("Ten dan nhap hoac mat khau sai", "Dang nhap khong thanh cong",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPass.Text = "";

                    }
                    else
                    {   
                        this.Hide();
                        RegisterForm registerForm = new RegisterForm();
                        registerForm.ShowDialog();

                    }


                }

            }

           



        }
    }
}
