using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.RoteValuesCalculator
{
    //TODO: Adicionar configurações ao XML
    public static class Config
    {
        public static string AccessToken { get; set; }

        public static int AddressSearchType { get; set; }
        public static int AddressResultRangePageIndex { get; set; }
        public static int AddressResultRecordsPerPage { get; set; }
    }
}
