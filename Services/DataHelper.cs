using System.Data.Common;
using System.Data;
using System.Reflection;

namespace TLCAREERSCORE.Services
{
    public static class DataHelper
    {
        public static List<T> DataTableToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        //pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], Nullable.GetUnderlyingType(pI.PropertyType) ?? pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
        public static T DataTableToModel<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            var objT = default(T);
            foreach (DataRow row in dt.Rows)
            {
                objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        //pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], Nullable.GetUnderlyingType(pI.PropertyType) ?? pI.PropertyType));
                    }
                }

            }
            return objT;

        }
        public static List<T> ReaderToList<T>(DbDataReader rdr)
        {
            List<T> ret = new List<T>();
            T entity;
            Type typ = typeof(T);
            PropertyInfo col;
            List<PropertyInfo> columns = new List<PropertyInfo>();
            // Get all the properties in Entity Class
            PropertyInfo[] props = typ.GetProperties();
            // Loop through one time to map columns to properties
            // NOTES:
            // Assumes your column names are the same name
            // as your class property names
            // Any properties not in the data reader column list are not set
            for (int index = 0; index < rdr.FieldCount; index++)
            {
                // See if column name maps directly to property name
                col = props.FirstOrDefault(c => c.Name == rdr.GetName(index));
                if (col != null)
                {
                    columns.Add(col);
                }
            }
            // Loop through all records
            while (rdr.Read())
            {
                // Create new instance of Entity
                entity = Activator.CreateInstance<T>();
                // Loop through columns to assign data
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].SetValue(entity, rdr[columns[i].Name] == DBNull.Value ? null : Convert.ChangeType(rdr[columns[i].Name], Nullable.GetUnderlyingType(columns[i].PropertyType) ?? columns[i].PropertyType));
                }
                ret.Add(entity);
            }
            return ret;
        }
        public static T ReaderToModel<T>(DbDataReader rdr)
        {
            T entity = default(T); ;
            Type typ = typeof(T);
            PropertyInfo col;
            List<PropertyInfo> columns = new List<PropertyInfo>();
            // Get all the properties in Entity Class
            PropertyInfo[] props = typ.GetProperties();
            // Loop through one time to map columns to properties
            // NOTES:
            // Assumes your column names are the same name
            // as your class property names
            // Any properties not in the data reader column list are not set
            for (int index = 0; index < rdr.FieldCount; index++)
            {
                // See if column name maps directly to property name
                col = props.FirstOrDefault(c => c.Name == rdr.GetName(index));
                if (col != null)
                {
                    columns.Add(col);
                }
            }
            // Loop through all records
            while (rdr.Read())
            {
                // Create new instance of Entity
                entity = Activator.CreateInstance<T>();
                // Loop through columns to assign data
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].SetValue(entity, rdr[columns[i].Name] == DBNull.Value ? null : Convert.ChangeType(rdr[columns[i].Name], Nullable.GetUnderlyingType(columns[i].PropertyType) ?? columns[i].PropertyType));
                }

            }
            return entity;
        }
    }
}
