using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ColsarParser
{
    public class HtmlParser
    {
        protected WebClient hWClient = new WebClient();

        public string DlHtmlString(string url)
        {
            using (hWClient)
            {
                using (Stream data = hWClient.OpenRead(url))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
