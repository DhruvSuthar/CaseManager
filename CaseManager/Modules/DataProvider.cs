using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CaseManager.Modules
{
    public class DataProvider
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public DataProvider()
        {
            conn = new SqlConnection(Strings.ConnectionString);
            conn.Open();
            cmd = new SqlCommand("", conn);
        }

        public void Insert(List<string> data, string Table)
        {
            try
            {
                cmd.CommandText = "INSERT INTO " + Table + " VALUES('";
                int i = 0;
                foreach (var item in data)
                {
                    i++;
                    cmd.CommandText += item;
                    if (i == data.Count) cmd.CommandText += "')";
                    else cmd.CommandText += "', '";
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }
        public List<string> SelectStarFromField(string table, string field, string where = "")
        {
            var ls = new List<string>();
            try
            {
                cmd.CommandText = "SELECT " + field + " FROM " + table;
                if (where != "") cmd.CommandText += " where " + where;
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    ls.Add(r.GetString(0));
                }
                r.Close();
            }
            catch (Exception) { }
            return ls;
        }
        public void DeleteFrom(string table, string where)
        {
            try
            {
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + where;
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }
        public void Update(string table, string set, string where)
        {
            try
            {
                cmd.CommandText = "UPDATE " + table + " SET " + set + " WHERE " + where;
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }
        public List<List<string>> Select(string table, string columns, string where = "")
        {
            var ls = new List<List<string>>();
            try
            {
                cmd.CommandText = "SELECT " + columns + " FROM " + table;
                if (where != "") cmd.CommandText += " WHERE " + where;
                var r = cmd.ExecuteReader();
                int c = 0;
                try
                {
                    c = columns.Split(',').Length;
                }
                catch (Exception) { }
                while (r.Read())
                {
                    var l = new List<string>();
                    for (int i = 0; i < c; i++)
                    {
                        try
                        {
                            l.Add(r.GetString(i));
                        }
                        catch (Exception)
                        {
                            l.Add(r.GetDateTime(i).ToString());
                        }
                    }
                    ls.Add(l);
                }
                r.Close();
            }
            catch (Exception) { }
            return ls;
        }
    }
}
