using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable()]
    class Warrior : Hero
    {
        int id;
        public static readonly string nameofclass = "Воин";
        public Warrior()
        {
            base.Health = 150;
            strong = 40;
            Skills.Add("Атака", Attack);
        }
        public override void Attack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(35, 50);
            h1.Health -= dmg;
            h1.ContrAttack(this);
        }

        public override void ContrAttack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(20, 40);
            h1.Health -= dmg;
        }
        public override string GetClassName()
        {
            return nameofclass;
        }
        public static Hero Create()
        {
            return new Warrior();
        }
    }
}
