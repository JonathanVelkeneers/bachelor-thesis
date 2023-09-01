using System;
using System.Collections.Generic;

namespace XamarinPokedex.Models
{
    public class SearchOption
    {
        public string FilterProperty { get; set; }
        public string SortProperty { get; set; } = "";
        public int SortDirection { get; set; } = 1;
        public string SearchQuery { get; set; } = "";

        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 260;
    }
}