﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class RumManager
    {
        private List<Room> _listOfRum;

        public List<Room> ListOfRum
        {
            get { return _listOfRum; }
            set { _listOfRum = value; }
        }

        public RumManager()
        {

        }
    }
}
