using System;
using NUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BomPraCredito.Core
{
    public class BaseTest
    {
        public static void esperar(int tempo)
        {
            Thread.Sleep(tempo);
        }
    }
}
