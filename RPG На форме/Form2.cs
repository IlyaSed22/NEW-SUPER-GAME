using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        // Слишком сложный интерфейс. NumericUpDown не нужен. Пусть игрок выбирает героев, пока не нажмет "Готово"

        
        public Form2()
        {
            InitializeComponent();
            listBox2.DataSource = new BindingSource(Game.Instance.HeroCreater, null);

            listBox2.DisplayMember = "Key";
            listBox2.ValueMember = "Value";

            //listBox1.DisplayMember = "Key";
            //listBox1.ValueMember = "Value";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //listBox1.DataSource = new BindingSource(Game.Instance.YourTeam, null);
        }

        // Правила выбора команды задай здесь. Например, нельзя выйти, если в команде меньше 3-х игроков.
        private void btnDone_Click(object sender, EventArgs e)
        {
            Game.Instance.AddEnemy(Monster.Create());
            Game.Instance.AddEnemy(Monster.Create());
            Game.Instance.AddEnemy(Monster.Create());
            File.Delete("team1.bin");
            File.Delete("team2.bin");
            
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var creator = (Func<Hero>)listBox2.SelectedValue;

            var newHero = creator();
            Game.Instance.YourTeam.Add(newHero);

            listBox1.DataSource = new BindingSource(Game.Instance.YourTeam, null);

            btnDone.Enabled = true;
        }
    }
}
