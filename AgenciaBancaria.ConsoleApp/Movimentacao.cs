namespace AgenciaBancaria.ConsoleApp
{
    public class Movimentacao
    {
        public decimal Valor { get; }
        public bool EhCredito { get; }

        public Movimentacao(decimal valor, bool ehCredito)
        {
            Valor = valor;
            EhCredito = ehCredito;
        }

        public override string ToString()
        {
            return $"R${this.Valor,-8} {(this.EhCredito ? "Crédito" : "Débito"),-10}";
        }
    }
}

