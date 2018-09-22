using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;

namespace EPages
{
    public class ORM
    {
        public static DataTable ConvertToDataTable<T>(T objectmodel)
        {
            PropertyInfo[] Properties = objectmodel.GetType().GetProperties();
            DataTable dt = CreateDataTable(Properties);
            FillData<T>(Properties, dt, objectmodel);
            
            return dt; 
        }//end of converting model into datatable

        public static DataTable ConvertIntoTable<T>(List<T> list)
        {
            PropertyInfo[] Properties =list[0].GetType().GetProperties();
            DataTable dt = CreateDataTable(Properties);
            foreach (var item in list)
            {
                FillData<T>(Properties, dt, item);    
            }
            return dt;
        }

        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
               
                    dc.ColumnName = pi.Name;
                    dc.DataType = pi.PropertyType;
                    dt.Columns.Add(dc);      
            }//end of creating columns in table

            return dt;
        }//end of creating datatable from model properties

        private static void FillData <T> (PropertyInfo[] properties, DataTable dt,T objectmodel) 
        {
            DataRow dr = dt.NewRow();
            
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(objectmodel, null);
            }//end of creating Row

            dt.Rows.Add(dr);
        }//end of filling data into table

        public static List<T> ConvertTableIntolist <T> (DataTable dt)
        {
            List<T> list = new List<T>();
            Type tClass = typeof(T);
            
            PropertyInfo[] pClass = tClass.GetProperties();
            List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
            T cn;

            foreach (DataRow item in dt.Rows)
            {
                cn = (T)Activator.CreateInstance(tClass);
                foreach (PropertyInfo pc in pClass)
                {
                    DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                    if (d != null)
                        pc.SetValue(cn, item[pc.Name], null);
                }//end of inner loop for setting properties and its values to the generic class

                list.Add(cn);
            }//end of Outer loop

            return list;
        }//end of Converting table into generic list<T>


        public static List<string> ConvertTableIntolist(DataTable dt)
        {
            List<string> list = new List<string>();
            
            List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();

            foreach (DataRow item in dt.Rows)
            {
                list.Add(item["title"].ToString());
            }//end of Outer loop

            return list;
        }//end of Converting table into generic list<T>
    }
}