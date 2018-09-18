using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }


        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public DataTable LoadTable()
        {
            string qr = string.Format("SELECT id AS [ID], name AS [Tên bàn], status AS [Trạng thái] FROM TableFood");
            return DataProvider.Instance.ExecuteQuery(qr);
        }

        public void AddTable(string name, string status)
        {
            string qr = string.Format("INSERT INTO TableFood VALUES(N'{0}', N'{1}')", name, status);
            DataProvider.Instance.ExecuteNonQuery(qr);
        }

        public void DeleteTable(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("DELETE TableFood WHERE id = '" + id + "'");
        }

        public void UpdateTable(int id, string name, string status)
        {
            string qr = string.Format("UPDATE TableFood SET name = N'{0}', status = N'{1}' WHERE id = {2}", name, status, id);
            DataProvider.Instance.ExecuteNonQuery(qr);
        }
    }
}
