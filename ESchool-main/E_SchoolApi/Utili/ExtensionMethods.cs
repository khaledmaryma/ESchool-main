using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
 
using System.Text;
using System.Web.UI.HtmlControls;

namespace E_SchoolApi.Common
{
    public static class ExtensionMethods
    {
        public static char[] Tashkeel = { '\u064B', '\u064C', '\u064D', '\u064E', '\u064F', '\u0650', '\u0651', '\u0652', '\u0653', '\u0657', '\u0658', '\u0659', '\u065A', '\u065B', '\u065D', '\u065E' };
       

        public static string RemoveTashkeel(this string Text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                if (!Tashkeel.Contains(c)) sb.Append(c);
            }
            return sb.ToString();
        }

        public static string ToStringOrEmpty(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return string.Empty;
                return Convert.ToString(str);
            }
            catch
            {
                throw;
            }
        }

        public static string ToExpressString(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return string.Empty;
                decimal Result = 0;
                if (decimal.TryParse(str.ToString(), out Result) && str.ToString().Contains(".")) return Result.ToString("0.########");
                if (str is DateTime) return ((DateTime)str).ToString("d/M/yyyy");
                return str.ToString();
            }
            catch
            {
                return str.ToString();
            }
        }

        public static int ToInt(this object str)
        {

            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                throw;
            }
        }

        public static int? ToNullableInt(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return null;
                return Convert.ToInt32(str);
            }
            catch
            {
                throw;
            }
        }

        public static int ToIntOrDefault(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return 0;
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }

        public static object ToIntOrDBNULL(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return DBNull.Value;
                return Convert.ToInt32(str);
            }
            catch
            {
                return DBNull.Value;
            }
        }

        public static bool ToBoolean(this object str)
        {

            try
            {
                return Convert.ToBoolean(str);
            }
            catch
            {
                throw;
            }
        }

        public static bool ToBooleanOrDefault(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return false;
                return Convert.ToBoolean(str);
            }
            catch
            {
                return false;
            }
        }

        public static byte ToByte(this object str)
        {
            try
            {
                return Convert.ToByte(str);
            }
            catch
            {
                throw;
            }
        }

        public static byte ToByteOrDefault(this object str)
        {
            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return 0;
                return Convert.ToByte(str);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime? ToDate(this object dateTime)
        {
            try
            {
                if (dateTime == "")
                {
                    return null;
                }

                if (dateTime is DateTime)
                {
                    return Convert.ToDateTime(dateTime);
                }
                else
                {
                    string[] date = dateTime.ToString().Split('/');
                    return new DateTime(int.Parse(date[2].ToString()), int.Parse(date[1].ToString()), int.Parse(date[0].ToString()));
                }
            }
            catch
            {
                return null;
            }
        }

        public static object ToDateOrDBNULL(this object dateTime)
        {
            try
            {
                if (dateTime == "")
                {
                    return DBNull.Value;
                }
                if (dateTime is DateTime)
                {
                    return Convert.ToDateTime(dateTime);
                }
                else
                {
                    string[] date = dateTime.ToString().Split('/');
                    return new DateTime(int.Parse(date[2].ToString()), int.Parse(date[1].ToString()), int.Parse(date[0].ToString()));
                }
            }
            catch
            {
                return DBNull.Value;
            }
        }

        public static decimal ToDecimal(this object str)
        {

            try
            {
                return Convert.ToDecimal(str);
            }
            catch
            {
                throw;
            }
        }

        public static decimal ToDecimalOrDefault(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return 0;
                return Convert.ToDecimal(str);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal? ToNullableDecimal(this object str)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return null;
                return Convert.ToDecimal(str);
            }
            catch
            {
                throw;
            }
        }

        public static TimeSpan? ToTimeSpan(this object str, string AMorPM)
        {

            try
            {
                if (str == null || str == DBNull.Value || str.ToString().Trim() == string.Empty) return null;
                str += " " + AMorPM;
                DateTime t = DateTime.ParseExact(str.ToString(), "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                return t.TimeOfDay;
            }
            catch
            {
                throw;
            }
        }

        public static int GetID(this DataTable dt, string columnName)
        {
            try
            {
                if ((from row in dt.AsEnumerable() where row.RowState != DataRowState.Deleted select row).Count() == 0) return 1;
                int ID = (from row in dt.AsEnumerable() where row.RowState != DataRowState.Deleted select row.Field<int>(columnName)).Max() + 1;
                return ID;
            }
            catch
            {
                return 0;
            }
        }
 

    }
}