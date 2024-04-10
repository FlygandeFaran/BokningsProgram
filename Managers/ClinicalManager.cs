using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram.Managers
{
    public class ClinicalManager
    {
        private SSKmanager _sskManager;
        private RoomManager _roomManager;

        public RoomManager RoomManager
        {
            get { return _roomManager; }
            set { _roomManager = value; }
        }
        public SSKmanager SskManager
        {
            get { return _sskManager; }
            set { _sskManager = value; }
        }

        ClinicalManager()
        {
            _roomManager = new RoomManager();
            _sskManager = new SSKmanager();
        }
    }
}
