using System.Text;

namespace AgenciaBancaria.ConsoleApp
{
    public class ContaCorrente
    {
        private static int contadorNrContas = 1001;
        private List<Movimentacao> movimentacoes { get; }
        private string numero { get; }
        private decimal limite { get; }
        private decimal saldo { get => ObterSaldo(); }
        private bool ehEspecial { get; }

        public ContaCorrente(decimal saldoInicial, decimal limite, bool ehEspecial)
        {
            this.numero = GerarNrConta();

            this.limite = limite;

            this.ehEspecial = ehEspecial;

            this.movimentacoes = new List<Movimentacao>();

            if (saldoInicial > 0)
                this.Depositar(saldoInicial);
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor precisa ser maior que Zero para efetuar o depósito.");

            Registrar(valor, true);
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor precisa ser maior que Zero para efetuar o saque.");

            if (limite + saldo - valor < 0)
                throw new Exception($"O valor de R${valor} é superior ao disponível de R${limite + saldo}");

            Registrar(-valor, false);
        }

        public void Transferir(decimal valor, ContaCorrente conta)
        {
            if (valor <= 0)
                throw new Exception("O valor precisa ser maior que Zero para efetuar a transferência.");

            if (limite + saldo - valor < 0)
                throw new Exception($"O valor de R${valor} é superior ao disponível de R${limite + saldo}.");

            conta.Depositar(valor);

            Registrar(-valor, false);
        }

        public string MostrarExtrato()
        {
            StringBuilder extrato = new();

            decimal saldoConta = 0;

            extrato.AppendLine($"*** Extrato Conta {numero} ***\nValor      Operação   Saldo\n-----------------------------");

            movimentacoes.ForEach(movimentacao => { saldoConta += movimentacao.Valor; extrato.AppendLine($"{movimentacao} R${saldoConta}"); });

            return extrato.ToString();
        }

        public string MostrarSaldo()
        {
            return $"saldo conta {numero} ----------- R$ {saldo}";
        }

        private void Registrar(decimal valor, bool ehCredito)
        {
            movimentacoes.Add(new Movimentacao(valor, ehCredito));
        }

        private decimal ObterSaldo()
        {
            return movimentacoes.Sum(i => i.Valor);
        }

        private string GerarNrConta()
        {
            return contadorNrContas++.ToString();
        }
    }
}

