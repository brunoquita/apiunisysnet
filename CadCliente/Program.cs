using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ClienteContext())
            {
                //Populando o banco de dados com alguns registros
                var clientejoao = new CadCliente { Nome = "João da Silva " };
                var bairrocentro = new CadBairro { Nome = "Centro" };
                var bairrovendanova = new CadBairro { Nome = "Venda Nova" };
                clientejoao.Bairros.Add(bairrocentro);
                clientejoao.Bairros.Add(bairrovendanova);
                db.CadCliente.Add(clientejoao);
                db.SaveChanges();

            }
        }
        public class CadCliente //Tabela de cliente
        {
            public int CdCadCliente { get; set; }
            public string Nome { get; set; }
            public virtual List<CadBairro> Bairros { get; set; }//Lista de bairros do cliente
            public CadCliente()
            {
                this.Bairros = new List<CadBairro>();//Retornando  a lista de bairros
   
            }
        }

        public class CadBairro//Cadastro de bairros
        {
            public int CdCadBairro { get; set; }
            public string Nome { get; set; }
            public virtual CadCliente CadCliente { get; set; }//Lista de clientes do bairros

        }
        public class ClienteContext: DbContext//Conectar com o banco de de dados definido em appconfig
        {
            public DbSet<CadCliente> CadCliente { get; set; }
            public DbSet<CadBairro> CadBairro{ get; set; }
        }
    }
}
