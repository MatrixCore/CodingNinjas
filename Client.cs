using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTest
{
    public class Client
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string ID { get; private set; }
        public string DateOfBirth { get; private set; }
        public bool Aid { get; private set; } //Determines if the client has qualified for finaical aid
        public Client(string name, string surname, string IDNum, string day, string month, string year, bool aid)
        {
            Name = name;
            Surname = surname;
            ID = IDNum;
            DateOfBirth = $"{day}/{month}/{year}";
            Aid = aid;
        }

        public override string ToString()
        {
            if (Aid)
            {
                return $"{Surname} ({ID})";
            }
            return $"{Surname} ({ID}) [Advice Only]";
        }
        
    }

 
}
