using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class ClientManager
    {
        private readonly DatabaseManager _dbManager;

        public ClientManager(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        // CREATE
        public void AddClient(Client client)
        {
            if (!ValidationHelper.IsValidEmail(client.Email))
                throw new ArgumentException("Nieprawidłowy email.");

            if (!ValidationHelper.IsValidPhone(client.Phone))
                throw new ArgumentException("Nieprawidłowy nr tel.");

            string query = @"
            INSERT INTO Clients (FirstName, LastName, Email, Phone, RegistrationDate)
            VALUES (@FirstName, @LastName, @Email, @Phone, @RegistrationDate)";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@FirstName", client.FirstName),
            new SqlParameter("@LastName", client.LastName),
            new SqlParameter("@Email", client.Email),
            new SqlParameter("@Phone", client.Phone),
            new SqlParameter("@RegistrationDate", client.RegistrationDate)
            };

            _dbManager.ExecuteNonQuery(query, System.Data.CommandType.Text, parameters);
        }

        // READ (all clients, with pagination)
        public List<Client> GetAllClients(int pageSize = 10, int pageNumber = 1)
        {
            // Using OFFSET-FETCH for pagination
            // Example: ORDER BY Id OFFSET X ROWS FETCH NEXT Y ROWS ONLY
            string query = $@"
            SELECT Id, FirstName, LastName, Email, Phone, RegistrationDate
            FROM Clients
            ORDER BY Id
            OFFSET {(pageNumber - 1) * pageSize} ROWS
            FETCH NEXT {pageSize} ROWS ONLY;";

            var dataTable = _dbManager.ExecuteReader(query, System.Data.CommandType.Text);

            var clients = new List<Client>();
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                var client = new Client
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                };
                clients.Add(client);
            }

            return clients;
        }

        // UPDATE
        public void UpdateClient(Client client)
        {
            if (!ValidationHelper.IsValidEmail(client.Email))
                throw new ArgumentException("Nieprawidłowy email.");

            if (!ValidationHelper.IsValidPhone(client.Phone))
                throw new ArgumentException("Nieprawidłowy nr tel.");

            string query = @"
            UPDATE Clients
            SET FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                Phone = @Phone
            WHERE Id = @Id";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@Id", client.Id),
            new SqlParameter("@FirstName", client.FirstName),
            new SqlParameter("@LastName", client.LastName),
            new SqlParameter("@Email", client.Email),
            new SqlParameter("@Phone", client.Phone)
            };

            _dbManager.ExecuteNonQuery(query, System.Data.CommandType.Text, parameters);
        }

        // DELETE
        public void DeleteClient(int clientId)
        {
            string query = @"DELETE FROM Clients WHERE Id = @Id";
            var parameter = new SqlParameter("@Id", clientId);
            _dbManager.ExecuteNonQuery(query, System.Data.CommandType.Text, parameter);
        }

        // SEARCH by LastName
        public List<Client> SearchClientsByLastName(string lastName)
        {
            string query = @"
            SELECT Id, FirstName, LastName, Email, Phone, RegistrationDate
            FROM Clients
            WHERE LastName LIKE @LastName + '%'
            ORDER BY LastName";

            var parameter = new SqlParameter("@LastName", lastName);

            var dataTable = _dbManager.ExecuteReader(query, System.Data.CommandType.Text, parameter);

            var clients = new List<Client>();
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                var client = new Client
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                };
                clients.Add(client);
            }

            return clients;
        }
    }

}
