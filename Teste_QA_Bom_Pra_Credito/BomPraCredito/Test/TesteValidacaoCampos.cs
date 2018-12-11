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
    class TesteValidacaoCampos
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
        public void DeveValidarCamposObrigatorios()
        {
            //***************Step1***************//
            cadastro.btnContinuarHome();

            Assert.AreEqual("Valor obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='error-message']")).Text);
            Assert.AreEqual("Qtd. Parcelas obrigatória",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[2]/div/div[2]/span")).Text);
            Assert.AreEqual("Nome obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[3]/div/div/span[1]")).Text);
            Assert.AreEqual("E-mail obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[4]/div[2]/div[3]/span[1]")).Text);

            cadastro.btnValor();
            cadastro.btnContinuarHome();
            Assert.AreEqual("Qtd. Parcelas obrigatória",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[2]/div/div[2]/span")).Text);
            Assert.AreEqual("Nome obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[3]/div/div/span[1]")).Text);
            Assert.AreEqual("E-mail obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[4]/div[2]/div[3]/span[1]")).Text);

            cadastro.btnParcelas();
            cadastro.btnContinuarHome();
            Assert.AreEqual("Nome obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[3]/div/div/span[1]")).Text);
            Assert.AreEqual("E-mail obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[4]/div[2]/div[3]/span[1]")).Text);

            cadastro.setNome();
            cadastro.btnContinuarHome();
            Assert.AreEqual("E-mail obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='ep1']/div[4]/div[2]/div[3]/span[1]")).Text);

            cadastro.setEmail();
            cadastro.btnContinuarHome();

            //***************Step2***************//
            cadastro.btnContinuarCadastro();
            BaseTest.esperar(2000);
            Assert.AreEqual("CPF inválido",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[1]/div[3]")).Text);
            Assert.AreEqual("Data deve ser preenchida no formato DD/MM/AAAA",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[2]/div[3]")).Text);
            Assert.AreEqual("Informe sua renda corretamente.",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[3]/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[4]/div/div[5]")).Text);
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.setCPF();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Data deve ser preenchida no formato DD/MM/AAAA",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[2]/div[3]")).Text);
            Assert.AreEqual("Informe sua renda corretamente.",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[3]/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[4]/div/div[5]")).Text);
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.setDataNascimento("19/03/1984");
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Informe sua renda corretamente.",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[3]/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[4]/div/div[5]")).Text);
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.setValorMensal("400000");
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[4]/div/div[5]")).Text);
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarSexoMasculino();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[4]/div/div[5]")).Text);
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarCasado();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarOcupacaoAssalariado();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Selecione",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[1]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarProfissaoDesenhista();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[9]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarFormacao();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/div[10]/div/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarBanco();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarChequeSim();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[1]/fieldset[2]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarRestricaoNomeNao();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[1]/div/div[3]")).Text);
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarImovelProprioSim();
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-borrower-info/div/form/div[2]/fieldset[2]/div/div[3]")).Text);

            cadastro.SelecionarCarroProprioSim();
            cadastro.btnContinuarCadastro();
            BaseTest.esperar(2000);

            //***************Step3***************//
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("CEP deve possuir 8 dígitos.",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[1]/div[1]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[1]/div[2]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[1]/div[3]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[1]/div[5]/div[3]")).Text);
            Assert.AreEqual("O DDD deve possuir pelo menos 2 dígitos.",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[2]/div[3]")).Text);

            cadastro.setCep("09560-400");
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("Campo Obrigatório",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[1]/div[3]/div[3]")).Text);
            Assert.AreEqual("O DDD deve possuir pelo menos 2 dígitos.",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[2]/div[3]")).Text);

            BaseTest.esperar(2000);
            cadastro.setNumero("53");
            cadastro.btnContinuarCadastro();
            Assert.AreEqual("O DDD deve possuir pelo menos 2 dígitos.",
               DriverFactory.getDriver().FindElement(By.XPath("//*[@class='main-area']/div[3]/app-address-info/div/form/div[2]/div[3]")).Text);

            cadastro.setCelular("(11)98135-0706");
            cadastro.btnContinuarCadastro();

            //***************Step4***************//
            new WebDriverWait(DriverFactory.getDriver(), TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id("emailConfirmation"))));
            cadastro.btnContinuarCadastroStep2();
            Assert.AreEqual("O e-mail de confirmação deve ser igual ao e-mail.",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[2]/div[3]")).Text);
            Assert.AreEqual("Reposta obrigatória",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/fieldset/div/div[3]")).Text);
            Assert.AreEqual("Data deve ser preenchida no formato DD/MM/AAAA",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[4]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[5]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[6]/div[2]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[7]/div[2]")).Text);
            Assert.AreEqual("Por favor, escreva o nome completo e sem caracteres especiais, ele é obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[8]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[9]/div/div[4]")).Text);
            Assert.AreEqual("Data deve ser preenchida formato MM/AAAA",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[10]/div[3]")).Text);
            Assert.AreEqual("Campo Obrigatório",
                DriverFactory.getDriver().FindElement(By.XPath("//*[@id='true']/div/form/div[11]/div[2]")).Text);

            BaseTest.esperar(2000);
            var ConfirmEmail = DriverFactory.getDriver().FindElement(By.Id("email")).GetAttribute("value");
            cadastro.setConfirmaEmail(ConfirmEmail);
                        
            BaseTest.esperar(5000);
        }
    }
}
