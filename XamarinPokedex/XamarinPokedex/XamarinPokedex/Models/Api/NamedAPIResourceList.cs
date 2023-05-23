using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPokedex.Models.Api
{
	public class NamedAPIResourceList<T> where T : NamedApiResource
    {
		public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<T> results { get; set; }
    }
}

