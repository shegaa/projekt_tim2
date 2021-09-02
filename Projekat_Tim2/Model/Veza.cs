using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Veza
	{
		

		public int Id
		{
            get; set;
        }

		

		public int IdPrvog
		{
            get; set;
        }
		

		public int IdDrugog
		{
            get;set;
		}
		

		public TipVeze TipV
		{
            get; set;
        }

		public Veza(int id, int idPrvog, int idDrugog, TipVeze tipV)
		{
			Id = id;
			IdPrvog = idPrvog;
			IdDrugog = idDrugog;
			TipV = tipV;
		}
        public Veza()
        {

        }
    }
}
