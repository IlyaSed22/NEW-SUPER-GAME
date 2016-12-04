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
    public partial class Form1 : Form
    {
        
        public Form1()
        { 
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка игры или новая игра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            Game.Instance.Start();
            

            foreach (var hero in Game.Instance.EnemyTeam)
            {
                hero.OnDeath += DeathStrike;
            }

            foreach (var hero in Game.Instance.YourTeam)
            {
                hero.OnDeath += DeathStrike;
            }

            listBox1.DataSource = new BindingSource(Game.Instance.YourTeam, null);
            listBox2.DataSource = new BindingSource(Game.Instance.EnemyTeam, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Выбранный герой
            Hero hero = (Hero)listBox1.SelectedItem;
            richTextBox3.Text = String.Format(" Health: {0}\n Урон: {1}\n Класс: {2}", hero.Health, hero.strong, hero.GetClassName());


            // Заполнение комбобокса действиями из словаря героя
            comboBox1.DataSource = new BindingSource(hero.Skills, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hero hero1 = (Hero)listBox1.SelectedItem;
            Hero hero2 = (Hero)listBox2.SelectedItem;

            // Выбираем из комбобокса выбранное умение
            var skill = (Hero.SkillHandler)comboBox1.SelectedValue;

            skill(hero2);

            listBox2.DataSource = new BindingSource(Game.Instance.EnemyTeam, null);
            listBox1.DataSource = new BindingSource(Game.Instance.YourTeam, null);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hero hero = (Hero)listBox2.SelectedItem;
            richTextBox2.Text = String.Format(" Health: {0}\n Урон: {1}\n Класс: {2}", hero.Health, hero.strong, hero.name);
        }

        /// <summary>
        /// Сохранение игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var hero in Game.Instance.YourTeam)
            {
                hero.OnDeath -= DeathStrike;
            }
            foreach (var hero in Game.Instance.EnemyTeam)
            {
                hero.OnDeath -= DeathStrike;
            }
            using (Stream streanm = File.Open("team1.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(streanm, Game.Instance.YourTeam);
            }
            using (Stream streanm = File.Open("team2.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(streanm, Game.Instance.EnemyTeam);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedSkill = (KeyValuePair<string, Hero.SkillHandler>)comboBox1.SelectedItem;

            // Если выбрано лечение заполни второй листбокс игроками первой команды
            if (selectedSkill.Key == "Лечение")
            {
                listBox2.DataSource = new BindingSource(Game.Instance.YourTeam, null);
            }
            // Если другое умение, заполни игроками второй команды
            else
            {
                listBox2.DataSource = new BindingSource(Game.Instance.EnemyTeam, null);
            }
        }

        public void DeathStrike(Hero h1)
        {
            Game.Instance.EnemyTeam.RemoveAll(hero => hero == h1);
            Game.Instance.Check();
            Game.Instance.YourTeam.RemoveAll(hero => hero == h1);
            richTextBox1.Text += "Персонаж " + h1 + " погиб\n";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game.Instance.YourTeam.Clear();
            Game.Instance.EnemyTeam.Clear();
            var f = new Form2();
            f.ShowDialog();
            listBox2.DataSource = new BindingSource(Game.Instance.EnemyTeam, null);
            listBox1.DataSource = new BindingSource(Game.Instance.YourTeam, null);
            richTextBox1.Clear();
        }
    }
}
