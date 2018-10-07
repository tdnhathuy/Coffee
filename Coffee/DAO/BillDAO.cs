using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }

        public void CheckOut(int idBill, int idTable, int totalPrice, string cashierName)
        {
            string qr = string.Format("" +
                "UPDATE Bill " +
                "SET dateCheckOut = GETDATE(), status = 1, totalPrice = {0}, cashier = N'{2}' " +
                "WHERE id = {1}", totalPrice, idBill, cashierName);
            string qr2 = "UPDATE TableFood SET status = N'Trống' WHERE id = " + idTable;
            DataProvider.Instance.ExecuteNonQuery(qr);
            DataProvider.Instance.ExecuteNonQuery(qr2);

        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("UPDATE TableFood SET status = N'Có người' WHERE id = " + id);
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }


        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT dmy " +
                "SELECT b.id AS [Số hóa đơn], b.DateCheckIn AS [Giờ vào], b.DateCheckOut AS [Giờ ra], t.Name AS [Bàn], b.totalPrice AS [Tổng tiền], a.DisplayName as [Thu ngân] " +
                "FROM Bill AS b, TableFood t, Account a " +
                "WHERE DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND b.idTable = t.ID AND b.status = 1 AND b.Cashier = a.UserName ";
            return DataProvider.Instance.ExecuteQuery(qr);
        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }


        public int GetAllInvoice(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT DMY " +
                    "SELECT COUNT(*) FROM BILL " +
                    "WHERE DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND status = 1";
            return (int)DataProvider.Instance.ExecuteScalar(qr);
        }
        public string GetMostValueInvoice(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT DMY " +
                "SELECT FORMAT(MAX(totalPrice), '#,### VNĐ') FROM BILL " +
                "WHERE DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND status = 1";
            return DataProvider.Instance.ExecuteScalar(qr).ToString();
        }
        public string GetLeastValueInvoice(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT DMY " +
                "SELECT FORMAT(MIN(totalPrice), '#,### VNĐ') FROM BILL " +
                "WHERE DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND status = 1";
            return DataProvider.Instance.ExecuteScalar(qr).ToString();
        }
        public int GetBigInvoice(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT DMY " +
                "SELECT COUNT(*) FROM BILL " +
                "WHERE totalPrice >= 200000 AND DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND status = 1";
            return (int)DataProvider.Instance.ExecuteScalar(qr);
        }
        public string GetRevenue(DateTime checkIn, DateTime checkOut)
        {
            string qr = "SET DATEFORMAT DMY " +
                "SELECT FORMAT(SUM(totalPrice), '#,### VNĐ') FROM BILL " +
                "WHERE DateCheckIn >= '" + checkIn.ToShortDateString() + " 00:00:01' AND DateCheckOut <= '" + checkOut.ToShortDateString() + " 23:59:59' AND status = 1";
            return DataProvider.Instance.ExecuteScalar(qr).ToString();
        }
    }
}
