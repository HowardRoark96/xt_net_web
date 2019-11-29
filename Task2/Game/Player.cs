using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Player : Unit, IMovable
    {
        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }

        public byte Direction { get; set; }

        public Map Map { get; }

        public override Field Location { get; set; }

        public Player(Field location, int maxHealth, int speed = 5, string name = "Player")
        {
            Speed = speed;
            MaxHealth = maxHealth;
            Location = location;
            Name = name;
        }

        public void MoveHorizontal()
        {
            if (Location.Coordinates.X > 0 && Location.Coordinates.X + Location.Width < this.Map.Size.Width && CanMove())
            {
                Location.Coordinates.X += this.Speed * Direction;
            }

        }

        public void MoveVertical()
        {
            if (Location.Coordinates.Y > 0 && Location.Coordinates.Y + Location.Length < this.Map.Size.Length && CanMove())
            {
                Location.Coordinates.Y += this.Speed * Direction;
            }
        }

        public bool CanMove()
        {
            bool canMove = false;
            foreach (var item in Map.mapObjects)
            {

            }
            return canMove;
        }

        public void GetDamage(int Damage)
        {
            CurrentHealth -= Damage;
            HealthCheck();
        }

        public void Heal(int HealPower)
        {
            CurrentHealth += HealPower;
            HealthCheck();
        }

        public void HealthCheck()
        {
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                Gameover();
            }
        }

        public void Gameover()
        {
            Console.Clear();
        }

    }
}
