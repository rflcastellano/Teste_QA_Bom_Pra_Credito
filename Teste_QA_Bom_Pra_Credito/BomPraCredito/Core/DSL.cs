using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomPraCredito.Core
{
    public class DSL
    {
        /********* TextField e TextArea ************/

        public void escrever(By by, String texto)
        {
            DriverFactory.getDriver().FindElement(by).Clear();
            DriverFactory.getDriver().FindElement(by).SendKeys(texto);
        }

        public void escrever(String id_campo, String texto)
        {
            escrever(By.Id(id_campo), texto);
        }

        public String obterValorCampo(String id_campo)
        {
            return DriverFactory.getDriver().FindElement(By.Id(id_campo)).GetAttribute("value");
        }

        /********* Radio e Check ************/

        public void clicarRadio(By by)
        {
            DriverFactory.getDriver().FindElement(by).Click();
        }

        public void clicarRadio(String id)
        {
            clicarRadio(By.Id(id));
        }

        public Boolean isRadioMarcado(String id)
        {
            return DriverFactory.getDriver().FindElement(By.Id(id)).Selected;
        }

        public void clicarCheck(String id)
        {
            DriverFactory.getDriver().FindElement(By.Id(id)).Click();
        }

        public Boolean isCheckMarcado(String id)
        {
            return DriverFactory.getDriver().FindElement(By.Id(id)).Selected;
        }

        /********* Combo ************/

        public void selecionarComboPrime(String radical, String valor)
        {
            clicarRadio(By.XPath("//*[@id='" + radical + "_input']/../..//span"));
            clicarRadio(By.XPath("//*[@id='" + radical + "_items']//li[.='" + valor + "']"));
        }

        /********* Botao ************/

        public void clicarBotao(String id)
        {
            DriverFactory.getDriver().FindElement(By.Id(id)).Click();
        }

        public String obterValueElemento(String id)
        {
            return DriverFactory.getDriver().FindElement(By.Id(id)).GetAttribute("value");
        }

        /********* Link ************/

        public void clicarLink(String link)
        {
            DriverFactory.getDriver().FindElement(By.LinkText(link)).Click();
        }

        /********* Textos ************/

        public String obterTexto(By by)
        {
            return DriverFactory.getDriver().FindElement(by).Text;
        }

        public String obterTexto(String id)
        {
            return obterTexto(By.Id(id));
        }
    }
}
