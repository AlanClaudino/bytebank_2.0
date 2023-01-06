using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ByteBank_2._0.Models;

namespace ByteBank_2._0.Functions
{
    internal class InputOutput
    {
        static public List<Clients> GetClientsDB()
        {
            List<Clients> DBclients = new List<Clients>();
            string path = @"ByteBankDB\ClientsDB.json";
            string JsonString = "";

            if (File.Exists(path))
            {
                JsonString = File.ReadAllText(path);
                DBclients = JsonSerializer.Deserialize<List<Clients>>(JsonString);
            }
            else
            {
                return new List<Clients>();
            }

            return DBclients;
        }

        static public void SalvarUsuariosDB(List<Clients> Usuarios)
        {
            string path = @"ByteBankDB\ClientsDB.json";
            if(!Directory.Exists(@"ByteBankDB")) Directory.CreateDirectory(@"ByteBankDB");
            File.WriteAllText(path, JsonSerializer.Serialize<List<Clients>>(Usuarios));
        }
    }
}
