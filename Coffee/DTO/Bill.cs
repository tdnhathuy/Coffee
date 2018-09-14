using System;
using System.Data;

namespace DTO
{
    public class Bill
    {
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int tableID;
        private int status;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int TableID { get => tableID; set => tableID = value; }
        public int Status { get => status; set => status = value; }

        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut,int idTable, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.TableID = idTable;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "") { this.DateCheckOut = (DateTime?)dateCheckOutTemp; }

            this.TableID = (int)row["idTable"];
            this.Status = (int)row["status"];

        }

    }
}
