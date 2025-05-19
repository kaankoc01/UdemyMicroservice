using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyMicroservice.Order.Domain.Entity
{
    public class Address : BaseEntity<int>
    {
		public string Line { get; set; } = null!;
		public string District { get; set; } = null!;
		public string Street { get; set; } = null!;
		public string Province { get; set; } = null!;
		public string ZipCode { get; set; } = null!;
		
	}
}
