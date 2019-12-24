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
    class StateFolder
    {
        public List<StateFile> State;
        public DateTime StateTime { get; set; }

        public StateFolder()
        {
            State = new List<StateFile>();
        }
        public StateFolder(DateTime time)
        {
            State = new List<StateFile>();
            StateTime = time;
        }

        public void AddStateFile(FileInfo file)
        {
            State.Add(new StateFile(file));
        }
    }
}
