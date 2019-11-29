using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    abstract class AggressiveMonster : Unit, IMovable
    {
        private int _health;

        public override Field Location { get; set; }

        public int Health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                _health = value;
            }
        }

        public int MaxHealth { get; set; }

        public int Speed { get; set; }

        public int Damage { get; set; }

        public byte Direction { get; set; }

        public AggressiveMonster(Field location, int maxHealth = 40, int health = 20, int speed = 6, int damage = 4)
        {
            Location = location;
            MaxHealth = maxHealth;
            Health = health;
            Speed = speed;
            Damage = damage;
        }

        public abstract void Persecution(Player p);
    }
}

