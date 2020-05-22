using conexaoComDB.Classes;
using conexaoComDB.dao;
using conexaoComDB.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexaoComDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserCsharp user = new UserCsharp();
            UserDao userDao = new UserDao();

            user.setNome(textBox1.Text);  //seta o nome
            user.setEmail(textBox2.Text); // seta o email

            userDao.Salvar(user);

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try       //metodo mostrar usuario pelo Id;
            {
                UserDao userDao = new UserDao();
                long id = long.Parse(txtId.Text);
                UserCsharp userCsharp = userDao.Mostrar(id);

                if (userCsharp.GetErroId())
                {
                    MessageBox.Show("ID Não encontrado"); //se der 
                }
                else
                {
                    textBox1.Text = userCsharp.getNome();
                    textBox2.Text = userCsharp.getEmail();
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show("Não há dados a pesquisar");
            }
        }
    }
}
