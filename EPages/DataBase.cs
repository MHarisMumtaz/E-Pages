using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPages
{
    public class DataBase
    {

        public static List<T> SelectFromDB<T>(string StoredProcedure)
        {
            SqlCommand sc = new SqlCommand(StoredProcedure,ConnectionString.Connect());
            sc.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<T> list = ORM.ConvertTableIntolist<T>(dt);
            return list;
        }

        public static int SelectFromDB(string StoredProcedure,SqlParameter[] paramters)
        {
            SqlCommand sc = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in paramters)
            {
                sc.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            object id = sc.ExecuteScalar();
            return Convert.ToInt32(id);
        }

        public static List<T> SelectFromDB<T>(string StoredProcedure,SqlParameter[] parameters)
        {
            SqlCommand sc = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in parameters)
            {
                sc.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<T> list = ORM.ConvertTableIntolist<T>(dt);
            return list;
        }

        public static List<string> SelectFromDb(string StoredProcedure, SqlParameter[] parameters)
        {
            SqlCommand sc = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in parameters)
            {
                sc.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<string> list = ORM.ConvertTableIntolist(dt);
            return list;
        }

        public static void InsertIntoDB(string StoredProcedure, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter item in parameters)
            {
                cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            cmd.ExecuteNonQuery();
        }

        public static bool InsertIntoDB(string StoredProcedure, DataTable dt,string tablename)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param = cmd.Parameters.AddWithValue(tablename, dt);
            Param.SqlDbType = SqlDbType.Structured;
           int chk = cmd.ExecuteNonQuery();
           if (chk == 1)
               return true;
           else
               return false;
        }

        public static int InsertIntoDB(string StoredProcedure, DataTable dt, string tablename, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter item in parameters)
            {
                cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            SqlParameter Param = cmd.Parameters.AddWithValue(tablename, dt);
            Param.SqlDbType = SqlDbType.Structured;
            object chk = cmd.ExecuteScalar();
            try
            {
                return Convert.ToInt32(chk + "");
            }
            catch
            {
                return -1;
            }
        }

        public static int InsertInto(string StoredProcedure, DataTable dt, string tablename)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param = cmd.Parameters.AddWithValue(tablename, dt);
            Param.SqlDbType = SqlDbType.Structured;
            object chk = cmd.ExecuteScalar();
            try
            {
                return Convert.ToInt32(chk + "");
            }
            catch
            {
                return -1;
            }
        }

        public static int InsertIntoDBAndGetID(string StoredProcedure, DataTable dt, string tablename)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param = cmd.Parameters.AddWithValue(tablename, dt);
            Param.SqlDbType = SqlDbType.Structured;
            object chk = cmd.ExecuteNonQuery();
            try
            {
                int id = Convert.ToInt16(chk.ToString());
                return id;
            }
            catch
            {
                return -1;
            }
            
        }

        public static void UpdateTable(string StoredProcedure, DataTable dt, string tablename)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Param = cmd.Parameters.AddWithValue(tablename, dt);
            Param.SqlDbType = SqlDbType.Structured;
           cmd.ExecuteNonQuery();
        }

        public static void UpdateTable(string StoredProcedure,SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter item in param)
            {
                cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            cmd.ExecuteNonQuery();
        }

        public static void DeleteRecord(string StoredProcedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, ConnectionString.Connect());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter item in param)
            {
                cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
            }
            cmd.ExecuteNonQuery();
        }
    }
}