using System;

namespace OMG.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string? Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            
            Console.WriteLine("Transação efetuada com sucesso!");
            Console.WriteLine($"{this.Nome}, seu saldo é {this.Saldo}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Transação efetuada com sucesso!");
            Console.WriteLine($"{this.Nome}, seu saldo é {this.Saldo}");
        }

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
           retorno += this.TipoConta + " | "; 
           retorno += "Nome: " + this.Nome + " | "; 
           retorno += "Saldo: R$" + this.Saldo + " | "; 
           retorno += "Crédito: R$" + this.Credito; 
           return retorno;
        }
    }
}