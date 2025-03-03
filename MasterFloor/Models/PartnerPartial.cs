using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
	public partial class Partner
	{
		/// <summary>
		/// NotMapped - указывает, что свойство или класс должны быть исключены из сопоставления с базой данных.
		/// </summary>
		[NotMapped]
		public int Discount { get; set; }
	}
}
