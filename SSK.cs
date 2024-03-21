using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BokningsProgram
{
    public class SSK
    {
		private KompetensLevel _kompetens;
        private bool _isBooked;
		private string _name;
		private string _HSAid;

		public string HSAID
		{
			get { return _HSAid; }
			set { _HSAid = value; }
		}
		public string Name
		{
            get { return _name; }
			set { _name = value; }
		}
		public KompetensLevel Kompetens
		{
			get { return _kompetens; }
		}
		public bool IsBokad
		{
			get { return _isBooked; }
		}
		public SSK(string name, string HSAid, KompetensLevel kompetens)
		{
			_name = name;
			_HSAid = HSAid;
			_kompetens = kompetens;
		}
		private void IsTheyBooked() //bra engelska...
		{

		}
        public override string ToString()
        {
			string strOut = $"{_name}, {_HSAid}";
			return strOut;
        }
    }
}
