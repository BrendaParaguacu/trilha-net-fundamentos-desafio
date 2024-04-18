using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaDigitada = Console.ReadLine();

            if (placaDigitada.Count() == 7)
            {
                var placaDigitadaValida = Regex.Replace(placaDigitada, "[a-zA-Z]{3,3}[0-9][a-zA-Z0-9][0-9]{2,2}", ":");

                if (!placaDigitadaValida.Contains(":"))
                {
                    Console.WriteLine("Por gentileza digite uma placa válida! ooXE");
                    AdicionarVeiculo();
                }
                else
                {
                    if(!VerificarPlacaJaCadastrada(placaDigitada))
                    {
                        this.veiculos.Add(placaDigitada.ToUpper());
                    }
                    else
                    {
                        Console.WriteLine("Por gentileza digite uma placa válida!" + placaDigitada + " Placa informada já está cadastrada!");
                        AdicionarVeiculo();
                    }
                }
            }
            else
            {
                Console.WriteLine("Por gentileza digite uma placa válida! AXÉ" + placaDigitada.Count());
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            int horas = 0;
            decimal valorTotal = 0;
            string placa = "";

            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                horas = Convert.ToInt32(Console.ReadLine());

                valorTotal = this.precoInicial + this.precoPorHora * horas;

                this.veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (this.veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine("                             -" + veiculo);
                }
                ;
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VerificarPlacaJaCadastrada(string placa)
        {
            if(veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
