using E_SchoolApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_SchoolApi.BLL
{
    public class Sch_Class
    {
        const string sqlConn = "Data Source=DESKTOP-U770H9U;Initial Catalog=E_School;User ID=sa;Password=123";
        public string Name { get; set; }
        public int ID { get; set; }

        public List<Sch_Class> GetClasss()
        {
            var lst = new List<Sch_Class>();
            var dt = modUtilities.ExecuteSQLQuery("Select  ID,Name from Class", sqlConn);
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new Sch_Class()
                {
                    Name = item["Name"].ToString(),
                    ID = item["ID"].ToInt()
                });
            }
            return lst;

        }

        internal object SetClasss(string name, int iD)
        {
            if (ID == 0)
                modUtilities.ExecuteSQLQuery("Insert into Class (Name)Values('" + name + "')", modUtilities.Connection);
            else
                modUtilities.ExecuteSQLQuery("Update   Class set   Name='" + name + "'  where ID = " + iD.ToExpressString(), modUtilities.Connection);
            return true;

        }
    }
}