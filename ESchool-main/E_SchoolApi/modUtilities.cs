using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic; 
using System.Data.SqlClient;
using System.Data;

static class modUtilities
{
    public static DataTable sqlDT = new DataTable();

 
   public const string Connection = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=schooleapp_ESchool;User ID=schooleapp_ESchool;Password=123456@aA";


    public static DataTable ExecuteSQLQuery(string SQLQuery,string CnString)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(CnString);
            SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
            SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);
            sqlDT.Reset();
            sqlDA.Fill(sqlDT);
        }
        catch (Exception ex)
        {
            
        }
        return sqlDT;
    }
    public static DataTable ExecuteSQLQueryExce(string SQLQuery, string CnString)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(CnString);
            SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlCon);
            SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);
            dt.Reset();
            sqlDA.Fill(dt);
        }
        catch (Exception ex)
        {
            
        }
        return dt;
    }
   

  
 
 

     
}
