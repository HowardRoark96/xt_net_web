using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task5
{
    [Serializable()]
    class StateFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ChangeTime { get; set; }

        public StateFile(FileInfo file, DateTime changeTime = default(DateTime))
        {
            Name = file.Name;
            Path = file.FullName;
            CreationTime = file.CreationTime;
            ChangeTime = changeTime;
        }
    }
}
