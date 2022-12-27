using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ByteBank_2._0.Functions
{
    internal class InputOutput
    {
        static public List<Users> GetClientsDB()
        {
            List<Users> DBclients = new List<Users>();
            string path = @"C:\Users\alanr\Desktop\Alan\Projects\Computer Science\ByteBank\ByteBank_2.0\ClientsDB.json";
            string JsonString = "";

            try
            {
                JsonString = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                File.Create(path);
            }

            if (JsonString != "")
            {
                DBclients = JsonSerializer.Deserialize<List<Users>>(JsonString);
            }
            else
            {
                return new List<Users>();
            }

            return DBclients;
        }

        static public void SalvarUsuariosDB(List<Users> Usuarios)
        {
            string path = @"C:\Users\alanr\Desktop\Alan\Projects\Computer Science\ByteBank\ByteBank_2.0\ClientsDB.json";
            File.WriteAllText(path, JsonSerializer.Serialize<List<Users>>(Usuarios));
        }
    }
}
