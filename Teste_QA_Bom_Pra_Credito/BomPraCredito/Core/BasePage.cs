using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace BomPraCredito.Core
{
    public static class BasePage
    {
        public static void EscreverTexto(By by, String texto)
        {
            DriverFactory.getDriver().FindElement(by).SendKeys(texto);
        }

        public static String ObterTextoEscritoPorTexto(By by)
        {
            return DriverFactory.getDriver().FindElement(by).Text;
        }

        public static String ObterTextoEscritoPorAtributo(By by)
        {
            return DriverFactory.getDriver().FindElement(by).GetAttribute("value");
        }

        public static void Clicar(By by)
        {
            DriverFactory.getDriver().FindElement(by).Click();
        }

        public static void ClicarPorTexto(String texto)
        {
            Clicar(By.LinkText(texto));
        }
       
        public static String GerarCpf()
        {
             int soma = 0, resto = 0;
             int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
             int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

             Random rnd = new Random();
             string semente = rnd.Next(100000000, 999999999).ToString();

             for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                semente = semente + resto;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                semente = semente + resto;
                return semente;
        }
    }
}
