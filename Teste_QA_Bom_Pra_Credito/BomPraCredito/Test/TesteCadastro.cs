using BomPraCredito.Core;
using BomPraCredito.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomPraCredito.Test
{
    class TesteCadastro
    {
        CadastroPage cadastro = new CadastroPage();

        [SetUp]
        public void IniciaNavegador()
        {
            DriverFactory.IniciaNavegador("https://demo.bompracredito.com.br/emprestimo-pessoal");
        }

        [TearDown]
        public void FechaNavegador()
        {
            DriverFactory.KillDriver();
        }

        [Test]
        public void DeveRealizarCadastroAssalariado()
        {
            cadastro.btnValor();
            cadastro.btnParcelas();
            cadastro.setNome();
            cadastro.setEmail();

            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnTwoThousand")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnNineTerm")).Enabled);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("name")).Text);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("email")).Text);
            BaseTest.esperar(2000);

            cadastro.btnContinuarHome();
            BaseTest.esperar(2000);
            cadastro.setCPF();
            var cpf = DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value");
            cadastro.setDataNascimento("19/03/1984");
            cadastro.setValorMensal("400000");
            cadastro.SelecionarSexoMasculino();
            cadastro.SelecionarOutrosDivorciado();
            cadastro.SelecionarOcupacaoAssalariado();
            cadastro.SelecionarProfissaoDesenhista();
            cadastro.SelecionarFormacao();
            cadastro.SelecionarBanco();
            cadastro.SelecionarChequeNao();
            cadastro.SelecionarRestricaoNomeNao();
            cadastro.SelecionarImovelProprioNao();
            cadastro.SelecionarCarroProprioSim();

            Assert.AreEqual(cpf, DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value"));
            Assert.AreEqual("19/03/1984", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.dateOfBirth")));
            Assert.AreEqual("4.000,00", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.monthlyGrossIncome")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.gender2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.maritalStatusOthers")).Enabled);
            Assert.AreEqual("Assalariado", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.jobType']/option[2]")));
            Assert.AreEqual("              Desenhista\r\n            ", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.profession']/option[89]")));
            Assert.AreEqual("Superior Completo", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.educationLevel']/option[6]")));
            Assert.AreEqual("Santander", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.bankingData.bankNumber']/option[9]")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.bankingData.hasCheckbook2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.hasNegativeCreditRecord2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasProperty2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasVehicle")).Enabled);

            cadastro.btnContinuarCadastro();
            BaseTest.esperar(2000);
            cadastro.setCep("09560-400");
            BaseTest.esperar(2000);
            cadastro.setNumero("53");
            cadastro.setCelular("(11)98135-0706");

            Assert.AreEqual("09560-400", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.cep")));
            Assert.AreEqual("53", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.number")));
            Assert.AreEqual("(11) 981350706", BasePage.ObterTextoEscritoPorAtributo(By.Id("mobilePhone")));

            cadastro.btnContinuarCadastro();
            new WebDriverWait(DriverFactory.getDriver(), TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id("emailConfirmation"))));
            var ConfirmEmail = DriverFactory.getDriver().FindElement(By.Id("email")).GetAttribute("value");
            cadastro.setConfirmaEmail(ConfirmEmail);

            BaseTest.esperar(2000);
        }

        [Test]
        public void DeveRealizarCadastroEmpresario()
        {
            cadastro.btnValor2();
            cadastro.btnParcelas();
            cadastro.setNome();
            cadastro.setEmail();

            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnTenThousand")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnNineTerm")).Enabled);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("name")).Text);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("email")).Text);
            BaseTest.esperar(2000);

            cadastro.btnContinuarHome();
            BaseTest.esperar(2000);
            cadastro.setCPF();
            var cpf = DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value");
            cadastro.setDataNascimento("15/01/1991");
            cadastro.setValorMensal("4000000");
            cadastro.SelecionarSexoMasculino();
            cadastro.SelecionarCasado();
            cadastro.SelecionarOcupacaoEmpresario();
            cadastro.SelecionarProfissaoPiscicultor();
            cadastro.SelecionarFormacao();
            cadastro.SelecionarBanco();
            cadastro.SelecionarChequeSim();
            cadastro.SelecionarRestricaoNomeNao();
            cadastro.SelecionarImovelProprioSim();
            cadastro.SelecionarCarroProprioSim();

            Assert.AreEqual(cpf, DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value"));
            Assert.AreEqual("15/01/1991", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.dateOfBirth")));
            Assert.AreEqual("40.000,00", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.monthlyGrossIncome")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.gender2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.maritalStatus")).Enabled);
            Assert.AreEqual("Empresário", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.jobType']/option[7]")));
            Assert.AreEqual("              Piscicultor\r\n            ", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.profession']/option[4]")));
            Assert.AreEqual("Superior Completo", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.educationLevel']/option[6]")));
            Assert.AreEqual("Santander", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.bankingData.bankNumber']/option[9]")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.bankingData.hasCheckbook")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.hasNegativeCreditRecord2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasProperty")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasVehicle")).Enabled);

            cadastro.btnContinuarCadastro();
            BaseTest.esperar(2000);
            cadastro.setCep("09560-400");
            BaseTest.esperar(2000);
            cadastro.setNumero("53");
            cadastro.setCelular("(11)98135-0706");

            Assert.AreEqual("09560-400", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.cep")));
            Assert.AreEqual("53", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.number")));
            Assert.AreEqual("(11) 981350706", BasePage.ObterTextoEscritoPorAtributo(By.Id("mobilePhone")));

            cadastro.btnContinuarCadastro();
            new WebDriverWait(DriverFactory.getDriver(), TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id("emailConfirmation"))));
            var ConfirmEmail = DriverFactory.getDriver().FindElement(By.Id("email")).GetAttribute("value");
            cadastro.setConfirmaEmail(ConfirmEmail);

            BaseTest.esperar(2000);
        }

        [Test]
        public void DeveRealizarCadastroEstudante()
        {
            cadastro.btnValor();
            cadastro.btnParcelas();
            cadastro.setNome();
            cadastro.setEmail();

            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnTwoThousand")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("btnNineTerm")).Enabled);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("name")).Text);
            Assert.IsEmpty(DriverFactory.getDriver().FindElement(By.Id("email")).Text);
            BaseTest.esperar(2000);

            cadastro.btnContinuarHome();
            BaseTest.esperar(2000);
            cadastro.setCPF();
            var cpf = DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value");
            cadastro.setDataNascimento("07/03/1994");
            cadastro.setValorMensal("100000");
            cadastro.SelecionarSexoMasculino();
            cadastro.SelecionarSolteiro();
            cadastro.SelecionarOcupacaoEstudante();
            cadastro.SelecionarFormacaoEstudante();
            cadastro.SelecionarBanco();
            cadastro.SelecionarChequeNao();
            cadastro.SelecionarRestricaoNomeNao();
            cadastro.SelecionarImovelProprioNao();
            cadastro.SelecionarCarroProprioNao();

            Assert.AreEqual(cpf, DriverFactory.getDriver().FindElement(By.Id("borrower.cpf")).GetAttribute("value"));
            Assert.AreEqual("07/03/1994", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.dateOfBirth")));
            Assert.AreEqual("1.000,00", BasePage.ObterTextoEscritoPorAtributo(By.Id("borrower.monthlyGrossIncome")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.gender2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.maritalStatus")).Enabled);
            Assert.AreEqual("Estudante", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.jobType']/option[8]")));
            Assert.IsFalse(DriverFactory.getDriver().FindElement(By.Id("borrower.profession")).Enabled);
            Assert.AreEqual("2º grau", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.educationLevel']/option[4]")));
            Assert.AreEqual("Santander", BasePage.ObterTextoEscritoPorTexto(By.XPath("//*[@id='borrower.bankingData.bankNumber']/option[9]")));
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.bankingData.hasCheckbook2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("borrower.hasNegativeCreditRecord2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasProperty2")).Enabled);
            Assert.IsTrue(DriverFactory.getDriver().FindElement(By.Id("hasVehicle2")).Enabled);

            cadastro.btnContinuarCadastro();
            BaseTest.esperar(2000);
            cadastro.setCep("09560-400");
            BaseTest.esperar(2000);
            cadastro.setNumero("53");
            cadastro.setCelular("(11)98135-0706");

            Assert.AreEqual("09560-400", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.cep")));
            Assert.AreEqual("53", BasePage.ObterTextoEscritoPorAtributo(By.Id("homeAddress.number")));
            Assert.AreEqual("(11) 981350706", BasePage.ObterTextoEscritoPorAtributo(By.Id("mobilePhone")));

            cadastro.btnContinuarCadastro();
            new WebDriverWait(DriverFactory.getDriver(), TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id("emailConfirmation"))));
            var ConfirmEmail = DriverFactory.getDriver().FindElement(By.Id("email")).GetAttribute("value");
            cadastro.setConfirmaEmail(ConfirmEmail);

            BaseTest.esperar(2000);
        }
    }
}
