using E_SchoolApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_SchoolApi.BLL
{
    public class Sch_Section
    {

        public string Name { get; set; }
        public int ID { get; set; }

        public List<Sch_Section> GetSections()
        {
            var lst = new List<Sch_Section>();
            var dt = modUtilities.ExecuteSQLQuery("Select  ID,Name from Section", modUtilities.Connection);
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new Sch_Section()
                {
                    Name = item["Name"].ToString(),
                    ID = item["ID"].ToInt()
                });
            }
            return lst;

        }


        public bool SetSections(string Name, int ID)
        {
            if (ID == 0)
                modUtilities.ExecuteSQLQuery("Insert into Section (Name)Values('" + Name + "')", modUtilities.Connection);
            else
                modUtilities.ExecuteSQLQuery("Update   Section set   Name='" + Name + "'  where ID = " + ID.ToExpressString(), modUtilities.Connection);
            return true;

        }



    }
}