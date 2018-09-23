using DAO;
using DTO;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public string CryptoPassword(string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, CryptoPassword(passWord)});

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string passWord, int type)
        {
            string qr = string.Format("" +
                "UPDATE Account " +
                "SET Displayname = N'{0}', Password = N'{1}' , Type = {3} " +
                "WHERE Username = N'{2}' ", displayName, CryptoPassword(passWord), userName, type);

            int result = DataProvider.Instance.ExecuteNonQuery(qr);

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            string qr = "SELECT Account.UserName as [Tài khoản], Account.DisplayName as [Tên hiển thị], " +
                "(CASE Account.Type " +
                "WHEN '01' THEN N'Quản lý' " +
                "ELSE N'Nhân viên'END) AS[Loại tài khoản] " +
                "FROM Account ";
            return DataProvider.Instance.ExecuteQuery(qr);
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string displayName,string passWord, int type)
        {

            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type, password )VALUES  ( N'{0}', N'{1}', {2}, N'{3}')", name, displayName, type, CryptoPassword(passWord));
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public string GetTypeAccount(string name)
        {
            string qr = string.Format("" +
                "SELECT Type FROM Account WHERE Username = N'{0}'", name);
            return (DataProvider.Instance.ExecuteScalar(qr)).ToString();
        }
    }
}
