using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class RumManager
    {
        private List<Rum> _listOfRum;

        public List<Rum> ListOfRum
        {
            get { return _listOfRum; }
            set { _listOfRum = value; }
        }

        public RumManager()
        {

        }
    }
}
