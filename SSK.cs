using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class SSK
    {
		private KompetensLevel _kompetens;
        private bool _isBokad;
		private string _namn;

		public string Namn
		{
			get { return _namn; }
			set { _namn = value; }
		}


		public KompetensLevel Kompetens
		{
			get { return _kompetens; }
		}
		public bool IsBokad
		{
			get { return _isBokad; }
		}

		public SSK(KompetensLevel kompetens)
		{
			this._kompetens = kompetens;

        }
	}
}
