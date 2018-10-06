using System.Collections.Generic;
using System.Globalization;

namespace Registration.FetchCountries
{
    public class Countries
    {
        public static List<string> country_name_list()
        {
            List<string> Culturelist = new List<string>();
            CultureInfo[] getcultureinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo getculture in getcultureinfo)
            {
                RegionInfo getregioninfo = new RegionInfo(getculture.LCID);
                if (!(Culturelist.Contains(getregioninfo.EnglishName)))
                {
                    Culturelist.Add(getregioninfo.EnglishName);
                }
            }
            Culturelist.Sort();
            Culturelist.Insert(0, "Select Country");
            return Culturelist;
        }
    }
}