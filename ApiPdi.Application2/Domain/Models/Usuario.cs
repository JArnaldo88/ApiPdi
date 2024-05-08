using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPdi.Application2.Domain.Models
{

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }


        public Usuario(int id, string nome, string sobrenome, string endereco, int numero, string telefone, string email, string ativo)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Numero = numero;
            Telefone = telefone;
            Email = email;
            Ativo = ativo;
        }

        public void ImprimirDetalhes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Sobrenome: {Sobrenome}");
            Console.WriteLine($"Endereço: {Endereco}, {Numero}");
            Console.WriteLine($"Telefone: {Telefone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Ativo:{Ativo}");
        }
    }
}
