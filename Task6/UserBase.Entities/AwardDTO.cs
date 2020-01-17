using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBase.Entities
{
    [Serializable]
    public class AwardDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public AwardDTO()
        {

        }

        public AwardDTO(int id, string title)
        {
            ID = id;
            Title = title;
        }

        public override string ToString()
        {
            return String.Format("{0}. {1}", ID, Title);
        }
    }
}
