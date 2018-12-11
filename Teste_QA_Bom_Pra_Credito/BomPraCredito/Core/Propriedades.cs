using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomPraCredito.Core
{
    public static class Propriedades
    {
        public static Boolean FECHAR_BROWSER = true;

        //public static Browsers browser = Browsers.FIREFOX;
        public static Browsers browser = Browsers.CHROME;

        public enum Browsers
        {
            CHROME,
            FIREFOX
        }
    }
}
