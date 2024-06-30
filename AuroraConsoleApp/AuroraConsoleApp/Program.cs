using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuroraConsoleApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var words = "Hello [name] [[author]]";
            var values = new Dictionary<string, string>
        {
            { "name", "Jim" }
        };

            string result = Interpolate(words, values);
            Console.WriteLine(result);

        }


    //    // values from the dictionary get substituted into square brackets
    //    Assert.Equal("Hello Jim", Interpolate("Hello [name]", new Dictionary<string, string>{{"name", "Jim"}}));
    //// escape the square brackets by doubling them:
    //Assert.Equal("Hello Jim [author]", Interpolate("Hello [name] [[author]]", new Dictionary<string, string>{{"name", "Jim"}}));

    public static string Interpolate(string words, Dictionary<string, string> values)
        {

            string removeDoubleExcape = words.Replace("[[", "%^^%");
            removeDoubleExcape = removeDoubleExcape.Replace("]]", "%~~%");

            foreach(var keyVal in values)
            {
                string key =  "[" + keyVal.Key + "]";
                if(removeDoubleExcape.Contains(key))
                {
                    removeDoubleExcape = removeDoubleExcape.Replace(key, keyVal.Value);
                }

            }


            removeDoubleExcape = removeDoubleExcape.Replace("%^^%", "[");
            removeDoubleExcape = removeDoubleExcape.Replace("%~~%", "]");

            return removeDoubleExcape;
        }

    }




}
