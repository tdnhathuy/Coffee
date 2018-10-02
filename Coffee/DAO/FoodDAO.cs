using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null)instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public DataTable LoadFood()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT a.ID, a.Name AS [Tên], b.Name AS [Danh mục], a.Price AS [Giá] FROM Food as a, FoodCategory as b WHERE a.idCategory = b.ID");
        }

        public DataTable SearchFoodByName(string name)
        {                     
            string query = string.Format("SELECT ID AS [ID], Name AS [Tên], Name AS [Danh mục], Price AS [Giá] FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            return (DataProvider.Instance.ExecuteQuery(query));
        }

        public bool InsertFood(string name, string nameCate, int price)
        {
            string query = string.Format("" +
                "INSERT INTO Food " +
                "VALUES (N'{0}', (SELECT ID FROM FoodCategory WHERE FoodCategory.name = N'{1}'), " +
                "{2})", name, nameCate, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(string name, string cate, int price,int id)
        {
            string query = string.Format("" +
                "UPDATE FOOD " +
                "SET name = N'{0}', " +
                "idCategory = (SELECT ID FROM FoodCategory WHERE FoodCategory.name = N'{1}'), " +
                "price = {2} " +
                "WHERE id = {3}",name, cate, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}",idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable GetListFoodSold(DateTime dateFrom, DateTime dateTo)
        {
            string qr = string.Format("SET DATEFORMAT dmy " +
                "SELECT c.name as [Tên món], SUM(b.count) as [Số lượng bán], FORMAT(c.price, '#,### VNĐ') as [Đơn giá], FORMAT(SUM(b.count) * c.price, '#,### VNĐ') as [Tổng tiền] " +
                "FROM Bill a, BillInfo b, Food c " +
                "WHERE a.id = b.idBill AND b.idFood = c.id AND DateCheckIn >= '{0} 00:00:01' AND DateCheckOut <= '{1} 23:59:59' " +
                "GROUP BY c.name, c.price " +
                "ORDER BY c.name", dateFrom.ToShortDateString(), dateTo.ToShortDateString());
            return DataProvider.Instance.ExecuteQuery(qr);
        }
    }
}
