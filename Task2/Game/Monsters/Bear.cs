using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Bear : AggressiveMonster
    {
        public Map map { get; set; }
        public Bear(Field location, int health, int maxHealth, int speed = 6, int damage = 4) : base(location, health, maxHealth, speed, damage)
        {

        }

        public bool CanMove(Field location)
        {
            foreach (var item in map.mapObjects)
            {
                if (item.Location == Location)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Persecution(Player pl)
        {
            if (Location.Coordinates.X > pl.Location.Coordinates.X && CanMove(Location))
            {
                Location.Coordinates.X -= Speed * Direction;
            }
            if (Location.Coordinates.X < pl.Location.Coordinates.X && CanMove(Location))
            {
                Location.Coordinates.X += Speed * Direction;
            }
            if (Location.Coordinates.Y > pl.Location.Coordinates.X && CanMove(Location))
            {
                Location.Coordinates.Y -= Speed * Direction;
            }
            if (Location.Coordinates.Y < pl.Location.Coordinates.Y && CanMove(Location))
            {
                Location.Coordinates.Y += Speed * Direction;
            }
        }
    }
}
