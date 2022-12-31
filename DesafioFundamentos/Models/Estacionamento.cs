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
            var entradaVeiculo = Console.ReadLine();
            
            if (ValidarPlaca(entradaVeiculo))
                veiculos.Add(entradaVeiculo);
            else
                Console.WriteLine("Placa do Veículo incorreta!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            if (!ValidarPlaca(placa))
                Console.WriteLine("Placa do Veículo incorreta!");

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
 
                foreach (var item in veiculos){
                    Console.WriteLine($"Placa - {item}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }

    
}
