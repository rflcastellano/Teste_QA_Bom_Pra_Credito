using Bogus;
using BomPraCredito.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Brazil;
using OpenQA.Selenium;

namespace BomPraCredito.Page
{
    class CadastroPage
    {
        
        DSL dsl = new DSL();


        //***************Escrever***************//

        public void setNome()
        {
            Faker faker = new Faker("pt_BR");
            dsl.escrever("name", faker.Person.FullName);
        }


        public void setEmail()
        {
            Faker faker = new Faker("pt_BR");
            dsl.escrever("email", faker.Internet.Email());
        }

        public void setConfirmaEmail(String texto)
        {
            dsl.escrever("emailConfirmation", texto);
        }

        public void setCPF()
        {
            dsl.escrever("borrower.cpf", BasePage.GerarCpf());
        }

        public void setDataNascimento(String data)
        {
            dsl.escrever("borrower.dateOfBirth", data);
        }

        public void setValorMensal(String valor)
        {
            dsl.escrever("borrower.monthlyGrossIncome", valor);
        }

        public void setCep(String cep)
        {
            dsl.escrever("homeAddress.cep", cep);
        }

        public void setNumero(String numero)
        {
            dsl.escrever("homeAddress.number", numero);
        }

        public void setCelular(String celular)
        {
            dsl.escrever("mobilePhone", celular);
        }

        public void setTelefone(String telefone)
        {
            dsl.escrever("homePhone", telefone);
        }

        //***************Selecionar***************//

        public void SelecionarSexoFeminino()
        {
            dsl.clicarBotao("borrower.gender");
        }

        public void SelecionarSexoMasculino()
        {
            dsl.clicarBotao("borrower.gender2");
        }

        public void SelecionarCasado()
        {
            dsl.clicarBotao("borrower.maritalStatus");
        }

        public void SelecionarSolteiro()
        {
            dsl.clicarBotao("borrower.maritalStatus2");
        }

        public void SelecionarSeparado()
        {
            dsl.clicarBotao("borrower.maritalStatus3");
        }

        public void SelecionarOutrosDivorciado()
        {
            dsl.clicarBotao("borrower.maritalStatusOthers");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.maritalStatusOthers']/option[3]")).Click();
        }

        public void SelecionarOcupacaoAssalariado()
        {
            dsl.clicarBotao("borrower.jobType");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[2]")).Click();
        }

        public void SelecionarOcupacaoEmpresario()
        {
            dsl.clicarBotao("borrower.jobType");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[7]")).Click();
        }

        public void SelecionarOcupacaoEstudante()
        {
            dsl.clicarBotao("borrower.jobType");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.jobType']/option[8]")).Click();
        }

        public void SelecionarProfissaoDesenhista()
        {
            dsl.clicarBotao("borrower.profession");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.profession']/option[89]")).Click();
        }

        public void SelecionarProfissaoPiscicultor()
        {
            dsl.clicarBotao("borrower.profession");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.profession']/option[4]")).Click();
        }

        public void SelecionarFormacao()
        {
            dsl.clicarBotao("borrower.educationLevel");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.educationLevel']/option[6]")).Click();
        }

        public void SelecionarFormacaoEstudante()
        {
            dsl.clicarBotao("borrower.educationLevel");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.educationLevel']/option[4]")).Click();
        }

        public void SelecionarBanco()
        {
            dsl.clicarBotao("borrower.bankingData.bankNumber");
            DriverFactory.getDriver().FindElement(By.XPath("//*[@id='borrower.bankingData.bankNumber']/option[9]")).Click();
        }


        //***************Clicar***************//

        public void SelecionarChequeSim()
        {
            dsl.clicarBotao("borrower.bankingData.hasCheckbook");
        }

        public void SelecionarChequeNao()
        {
            dsl.clicarBotao("borrower.bankingData.hasCheckbook2");
        }

        public void SelecionarRestricaoNomeSim()
        {
            dsl.clicarBotao("borrower.hasNegativeCreditRecord");
        }

        public void SelecionarRestricaoNomeNao()
        {
            dsl.clicarBotao("borrower.hasNegativeCreditRecord2");
        }

        public void SelecionarImovelProprioSim()
        {
            dsl.clicarBotao("hasProperty");
        }

        public void SelecionarImovelProprioNao()
        {
            dsl.clicarBotao("hasProperty2");
        }

        public void SelecionarCarroProprioSim()
        {
            dsl.clicarBotao("hasVehicle");
        }

        public void SelecionarCarroProprioNao()
        {
            dsl.clicarBotao("hasVehicle2");
        }

        //***************Botao***************//

        public void btnValor()
        {
            dsl.clicarBotao("btnTwoThousand");
        }

        public void btnValor2()
        {
            dsl.clicarBotao("btnTenThousand");
        }

        public void btnParcelas()
        {
            dsl.clicarBotao("btnNineTerm");
        }

        public void btnContinuarHome()
        {
            dsl.clicarBotao("btnContinue");
        }

        public void btnContinuarCadastro()
        {
            dsl.clicarBotao("button-borrower-info");
        }

        public void btnContinuarCadastroStep2()
        {
            dsl.clicarBotao("button-personal-info");
        }

        public void btnContinuarCadastroStep3()
        {
            dsl.clicarBotao("button-professional-info");
        }

        public void MarcarWhatsApp()
        {
            dsl.clicarRadio(By.Id("agreeWhatsApp"));
        }
    }
}
