using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Patient
    {
        private DateTime _startTid;
        private DateTime _slutTid;

        public DateTime StartTid
        {
            get { return _startTid; }
            set { _startTid = value; }
        }
        public DateTime SlutTid
        {
            get { return _slutTid; }
            set { _slutTid = value; }
        }

        public Patient()
        {

        }
	}
}
