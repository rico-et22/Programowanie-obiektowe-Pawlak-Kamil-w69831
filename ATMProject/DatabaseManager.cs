using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public interface IDataAccess
    {
        PaymentCard GetCardByNumber(string cardNumber);
        void UpdateCard(PaymentCard card);
        void InsertTransaction(Transaction transaction);
        List<Transaction> GetTransactions();

        // Obsługa ustawień administratora i konfiguracji bankomatu
        string GetSetting(string key);
        void UpdateSetting(string key, string value);

        // Obsługa ustawień dotyczących gotówki (nominały)
        Dictionary<int, int> GetCashReserveSettings();
        void UpdateCashReserveSetting(int denomination, int count);
    }

    public class DatabaseManager : IDataAccess
    {
        // Dostosuj connection string do swojej konfiguracji SQL Server.
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ATM_DB;Integrated Security=True;Encrypt=False";

        public PaymentCard GetCardByNumber(string cardNumber)
        {
            PaymentCard card = null;
            string query = "SELECT CardNumber, PIN, PaymentSystem, FailedAttempts, IsBlocked, Balance FROM PaymentCards WHERE CardNumber = @CardNumber";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string cardNum = reader["CardNumber"].ToString();
                        string pin = reader["PIN"].ToString();
                        string paymentSystemStr = reader["PaymentSystem"].ToString();
                        int failedAttempts = Convert.ToInt32(reader["FailedAttempts"]);
                        bool isBlocked = Convert.ToBoolean(reader["IsBlocked"]);
                        decimal balance = Convert.ToDecimal(reader["Balance"]);

                        Account account = new Account(balance);
                        PaymentSystem ps;
                        if (!Enum.TryParse(paymentSystemStr, out ps))
                        {
                            ps = PaymentSystem.Visa; // wartość domyślna
                        }
                        switch (ps)
                        {
                            case PaymentSystem.Visa:
                                card = new VisaCard(cardNum, pin, account);
                                break;
                            case PaymentSystem.AmericanExpress:
                                card = new AmexCard(cardNum, pin, account);
                                break;
                            case PaymentSystem.VisaElectron:
                                card = new VisaElectronCard(cardNum, pin, account);
                                break;
                            case PaymentSystem.Mastercard:
                                card = new Mastercard(cardNum, pin, account);
                                break;
                        }
                        card.FailedAttempts = failedAttempts;
                        card.IsBlocked = isBlocked;
                    }
                }
            }
            return card;
        }

        public void UpdateCard(PaymentCard card)
        {
            string query = "UPDATE PaymentCards SET FailedAttempts = @FailedAttempts, IsBlocked = @IsBlocked, Balance = @Balance WHERE CardNumber = @CardNumber";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FailedAttempts", card.FailedAttempts);
                cmd.Parameters.AddWithValue("@IsBlocked", card.IsBlocked);
                cmd.Parameters.AddWithValue("@Balance", card.Account.Balance);
                cmd.Parameters.AddWithValue("@CardNumber", card.CardNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertTransaction(Transaction transaction)
        {
            string query = "INSERT INTO Transactions (CardNumber, Amount, Date) VALUES (@CardNumber, @Amount, @Date)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CardNumber", transaction.CardNumber);
                cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@Date", transaction.Date);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            string query = "SELECT TransactionId, CardNumber, Amount, Date FROM Transactions";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int transactionId = Convert.ToInt32(reader["TransactionId"]);
                        string cardNumber = reader["CardNumber"].ToString();
                        decimal amount = Convert.ToDecimal(reader["Amount"]);
                        DateTime date = Convert.ToDateTime(reader["Date"]);

                        Transaction transaction = new Transaction(cardNumber, amount)
                        {
                            TransactionId = transactionId,
                            Date = date
                        };
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }

        // Metody obsługi ustawień w tabeli ATMSettings

        public string GetSetting(string key)
        {
            string value = null;
            string query = "SELECT SettingValue FROM ATMSettings WHERE SettingKey = @SettingKey";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SettingKey", key);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    value = result.ToString();
            }
            return value;
        }

        public void UpdateSetting(string key, string value)
        {
            string query = "UPDATE ATMSettings SET SettingValue = @SettingValue WHERE SettingKey = @SettingKey";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SettingKey", key);
                cmd.Parameters.AddWithValue("@SettingValue", value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<int, int> GetCashReserveSettings()
        {
            Dictionary<int, int> settings = new Dictionary<int, int>();
            string query = "SELECT SettingKey, SettingValue FROM ATMSettings WHERE SettingKey LIKE 'Note_%'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["SettingKey"].ToString(); // np. "Note_10"
                        string valueStr = reader["SettingValue"].ToString();
                        if (key.StartsWith("Note_") &&
                            int.TryParse(key.Substring(5), out int denomination) &&
                            int.TryParse(valueStr, out int count))
                        {
                            settings[denomination] = count;
                        }
                    }
                }
            }
            return settings;
        }

        public void UpdateCashReserveSetting(int denomination, int count)
        {
            string key = $"Note_{denomination}";
            UpdateSetting(key, count.ToString());
        }
    }
}
