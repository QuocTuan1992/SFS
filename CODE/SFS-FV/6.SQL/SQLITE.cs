using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace SFS_FV.SQL
{
   public class SQLITE
    {
        public bool DeleteAll(String tableName)
        {
            Boolean returnCode = true;
            try
            {

                this.ExecuteNonQuery(String.Format("delete from {0};", tableName), G.sourceSQL);
            }
            catch (Exception ex)
            {
                returnCode = false;
            }
            return returnCode;
        }
        public int ExecuteNonQuery(string sql, string conn)
        {
            int rowsUpdated = 0;

            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {
                cnn.Open();
                using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                {
                    mycommand.CommandText = sql;
                    rowsUpdated = mycommand.ExecuteNonQuery();
                }

            }
            return rowsUpdated;
            
        }
        public string ExecuteScalar(string sql, string conn)
        {

            using (SQLiteConnection cnn = new SQLiteConnection(conn))
            {
                cnn.Open();
                using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                {
                    mycommand.CommandText = sql;
                    object value = mycommand.ExecuteScalar();
                    //   cnn.Close();
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            return "";
        }
        public bool Insert(String tableName, List<string> Values)
        {
            // String columns = "";

            String values = "";
            Boolean returnCode = true;

            foreach (string s in Values)
            {
                values += "'" + s + "'" + ",";

            }
            //columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO  {0}  VALUES ( {1});", tableName, values), G.sourceSQL);
                returnCode = true;
            }
            catch (Exception ex)
            {
                returnCode = false;
            }
            return returnCode;
        }
        public bool Update(String tableName, Dictionary<String, String> data, String where, String conn)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                if(where!="")
                this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where), conn);
                else
                    this.ExecuteNonQuery(String.Format("update {0} set {1} ;", tableName, vals), conn);
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }
        public bool Delete(String tableName, String where)
        {
            Boolean returnCode = true;
            try
            {

                this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where), G.sourceSQL);
            }
            catch (Exception ex)
            {
                returnCode = false;
            }
            return returnCode;
        }
        public bool CHECK(string Get, string Table, string Where)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(G.sourceSQL))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                    {
                        mycommand.CommandText = "SELECT " + Get + " FROM " + Table + " WHERE " + Where + " "; ;
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            dt.Load(reader);
                            reader.Close();
                        }
                    }

                    if (dt.Rows.Count == 0)
                        return false;
                    else
                    {
                        string[] array = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                        //   G.IDFil.Clear();
                        foreach (String arr in array)
                        {
                            //       G.IDFil.Add(arr);
                        }
                        return true;
                    }


                }
            }
            catch (Exception e)
            {

            }
            return false;
        }
        public DataTable SQL_Table(string Get, string Table, string Where)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(G.sourceSQL))
                {
                    cnn.Open();

                    using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                    {
                        if (Where != "")
                            mycommand.CommandText = "SELECT " + Get + " FROM " + Table + " WHERE " + Where + " ";
                        else
                            mycommand.CommandText = "SELECT " + Get + " FROM " + Table + "";
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            //  reader.StepCount
                            dt.Load(reader);

                            reader.Close();
                        }
                    }
                    //  cnn.Close();
                }
            }
            catch (Exception e)
            {
                //  MessageBox.Show("VUI LÒNG KI?M TRA K?T N?I M?NG V?I ? SHARE!");

            }
            return dt;
        }
        public void CoppySQL(string sourceFile, string destFile)
        {
            using (SQLiteConnection source = new SQLiteConnection(String.Format("Data Source = {0}", sourceFile)))
            using (SQLiteConnection destination = new SQLiteConnection(String.Format("Data Source = {0}", destFile)))
            {
                source.Open();
                destination.Open();
                source.BackupDatabase(destination, "main", "main", -1, null, -1);
            }
        }
        public List<String> SQL_List(int num, DataTable dt)
        {
            List<String> value = new List<String>();
            try
            {
                string[] array = dt.Rows.OfType<DataRow>().Select(k => k[num].ToString()).ToArray();

                foreach (String arr in array)
                {
                    value.Add(arr);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return value;
        }
        public bool New_table(String tableName, List<string> Column)
        {
            // String columns = "";
            String values = "";
            Boolean returnCode = true;

            foreach (string s in Column)
            {
                values += s + " nvachar(50)" + ",";

            }
            //columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {//CREATE TABLE TYPE (TYPE nvachar(50));"; //gancau lech cmd
                tableName = tableName.Replace('-', '_');
                this.ExecuteNonQuery(String.Format("CREATE TABLE  {0}   ( {1});", tableName, values), G.sourceSQL);
                returnCode = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("the same!");
            }
            return returnCode;
        }
        private int CountDrawing(string id, string table, string w1, string w2)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand cmd;
            sqlite_conn = new SQLiteConnection("");
            sqlite_conn.Open();
            cmd = sqlite_conn.CreateCommand();
            cmd.CommandText = "select count('" + id + "') from " + table + " where " + w1 + " = '" + w2 + "';";
            // cmd.CommandType = CommandType.Text;
            int RowCount = 0;

            RowCount = Convert.ToInt32(cmd.ExecuteScalar());

            return RowCount;
        }
        public bool ClearTable(String table, String conn)
        {
            try
            {

                this.ExecuteNonQuery(String.Format("delete from {0};", table), conn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Tuple<bool, String> CHECK_VAL(string sql, string conn)
        {
            DataTable dt = new DataTable();
            string value = "";
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                    {
                        mycommand.CommandText = sql;
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            dt.Load(reader);
                            reader.Close();

                        }
                    }


                    string[] array = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                    value = array[0];
                    if (dt.Rows.Count == 0) return Tuple.Create(false, "");


                }
            }
            catch (Exception e)
            {

            }
            return Tuple.Create(true, value);
        }   
        public Dictionary<int, List<String>> GetMulTiList(int num, DataTable dt)
        {
            Dictionary<int, List<String>> dic = new Dictionary<int, List<String>>();

            try
            {
                for (int i = 0; i < num; i++)
                {
                    string[] array = dt.Rows.OfType<DataRow>().Select(k => k[i].ToString()).ToArray();
                    List<String> value = new List<String>();
                    foreach (String arr in array)
                    {
                        value.Add(arr);
                    }
                    dic.Add(i, value);


                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return dic;
        }
    }
}
