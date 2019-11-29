using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Map
    {
        public Field Size { get; set; }
        public List<AggressiveMonster> monsters { get; set; }
        public List<MapObject> mapObjects { get; set; }
    }
}
