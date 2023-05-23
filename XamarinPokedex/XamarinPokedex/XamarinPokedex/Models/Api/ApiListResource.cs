using System;
using System.Collections.Generic;

namespace XamarinPokedex.Models.Api
{
	public class ApiListResource<T>
    {
		public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
		public IEnumerable<T> Results { get; set; }
        public ApiListResource()
		{
		}
	}
}
