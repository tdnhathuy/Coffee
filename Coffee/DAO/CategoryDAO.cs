using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }

        public DataTable LoadCategory()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT ID, Name AS Tên FROM FoodCategory");
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }

        public bool AddCategory(string name)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("INSERT INTO FoodCategory VALUES(N'" + name + "')");
            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE FoodCategory WHERE ID = " + id);
            return result > 0;
        }

        public bool EditCategory(int id, string name)
        {
            string qr = string.Format("UPDATE FoodCategory SET Name=N'{0}' WHERE ID={1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(qr);
            return result > 0;
        }
    }
}
