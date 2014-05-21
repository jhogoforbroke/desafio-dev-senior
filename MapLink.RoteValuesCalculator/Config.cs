using System;

namespace MapLink.RoteValuesCalculator
{
    public static class Config
    {
        public static string AccessToken
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["AccessToken"] ?? "";
            }
        }

        public static int AddressSearchType
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AddressSearchType"]);
            }
        }

        public static int AddressResultRangePageIndex
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AddressResultRangePageIndex"]);
            }
        }

        public static int AddressResultRecordsPerPage
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AddressResultRecordsPerPage"]);
            }
        }

        public static int DesciptionType
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DesciptionType"]);
            }
        }

        public static string Language
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Language"] ?? "";
            }
        }
    }
}
