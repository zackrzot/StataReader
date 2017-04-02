using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StataReader
{
    public class SearchObject
    {
        public String text { get; set; }
        public SearchObject(String _text)
        {
            text = _text;
        }

    }

    public static class SearchFilter
    {

        public static List<SearchObject> ActiveSearchFilter = new List<SearchObject>();


        public static Boolean FilterEntryExists(String text)
        {
            foreach(var item in ActiveSearchFilter)
                if (item.text == text)
                    return true;
            return false;
        }

        public static void RemoveItem(int item)
        {
            if (ActiveSearchFilter.Count == 0)
                return;
            if (item == -1)
                return;
            ActiveSearchFilter.RemoveAt(item);
        }

        public static void LoadDefaultZAbs()
        {
            ActiveSearchFilter = new List<SearchObject>();
            ActiveSearchFilter.Add(new SearchObject("Prob > |z|"));
        }

        public static void LoadDefaultTAbsSpearman()
        {
            ActiveSearchFilter = new List<SearchObject>();
            ActiveSearchFilter.Add(new SearchObject("Prob > |t|"));
            ActiveSearchFilter.Add(new SearchObject("Spearman's rho"));
        }




    }
}
