using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable()]
    class Monster : Hero
    {
        public static readonly string nameofclass = "Монстр";
        public override void Attack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(20, 70);
            h1.Health -= dmg;
            h1.ContrAttack(this);
        }

        public Monster()
        {
            base.Health = 200;
            
        }
        public override void ContrAttack(Hero h1)
        {
            Random rnd = new Random();
            dmg = rnd.Next(20, 50);
            h1.Health -= dmg;
        }
        public override string GetClassName()
        {
            return nameofclass;
        }
        public static Hero Create()
        {
            return new Monster();
        }
    }
}
