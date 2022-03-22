using System;
using System.Collections.Generic;
using System.Text;

namespace DIO_BANL
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }


        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        /*
         A única regra de saque é: O valor do saque não pode ser maior que o valor que temos de crédito
         Crédito = Saldo + limite;
        */
        public bool Sacar(double valorSaque)
        {
            //Validar Saque
            if(this.Saldo - valorSaque <(this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            /*
                         // -= é a mesma coisa que this.Saldo = this.Saldo - valorSaque;
                O mesmo serve se eu quiser somar(+=) se eu quiser multiplicar(*=), dividir(/=) etc
             */
            this.Saldo -= valorSaque;

            /*
             ...{0} é {1}", this.propr0, this.propr1... => isso é chamado de formatação composta
               Lembrado que o primeiro {} corresponde ao primeiro this e assim sucessivamente
               Conforme o exemplo abaixo
             {0} =  this.propr0
             {1} =  this.propr1
             */
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;

        }

        /*
             Como é uma função que não precisa de um retorno(Verdadeiro ou falso) é um utilizado o método VOID
            Depósito como consiste apenas eu receber um valor na conta não é necessário nenhum tipo de validação 
        */
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        /*
             Como é uma função que não precisa de um retorno(Verdadeiro ou falso) é um utilizado o método VOID
            Transferência precisamos obeder 2 regras: A conta e o valor(lembrando que o saldo não pode ficar negativo) 
        */
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "|TipoConta: " + this.TipoConta + "| ";
            retorno += "|Nome: " + this.Nome + "| ";
            retorno += "|Saldo: " + this.Saldo + "| ";
            retorno += "|Crédito: " + this.Credito + "| ";
            return retorno;
        }

    }
}
