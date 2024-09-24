using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TLCAREERSCORE.Models;

namespace TLCAREERSCORE.Services
{
    public class ClassifiedRepository:IClassified
    {
        private readonly AppDbContext context;

        public ClassifiedRepository(AppDbContext context)
        {
            this.context = context;
        }

        Dictionary<string, object> parameters = new Dictionary<string, object>();

        public DataTableResult GetClassifiedRepositoryInfo(DataTableRequest dataTableRequest)
        {
            List<Classified> Classifieds = new List<Classified>();
            parameters.Clear();
            parameters.Add("DisplayLength", dataTableRequest.length);
            parameters.Add("DisplayStart", dataTableRequest.start);
            parameters.Add("SortCol", dataTableRequest.orders.ElementAt(0).column);
            parameters.Add("SortDir", dataTableRequest.orders.ElementAt(0).dir.ToLower());
            parameters.Add("Search", string.IsNullOrEmpty(dataTableRequest.search.value.ToUpper()) ? null : dataTableRequest.search.value.ToUpper());
            parameters.Add("UserID", dataTableRequest.UserID);
            parameters.Add("StartDate", string.IsNullOrEmpty(dataTableRequest.StartDate) ? "2019-01-01" : dataTableRequest.StartDate);
            parameters.Add("EndDate", string.IsNullOrEmpty(dataTableRequest.EndDate) ? "2025-12-01" : dataTableRequest.EndDate);

            using (DbDataReader rdr = DbOperation.GetData(context, "spGetClassified", parameters))
            {
                Classifieds = DataHelper.ReaderToList<Classified>(rdr);
                rdr.Close();

                DataTableResult dataTableResult = new DataTableResult();
                dataTableResult.Draw = dataTableRequest.draw;
                dataTableResult.Data = Classifieds;

                dataTableResult.RecordsTotal = Classifieds.Count == 0 ? 0 : Classifieds[0].TotalRecordCount;   //TotalRecordCount; //GetClassifiedCount(dataTableRequest);
                dataTableResult.RecordsFiltered = Classifieds.Count == 0 ? 0 : Classifieds[0].TotalCount;

                return dataTableResult;
            }
        }

        public Classified GetClassified(string ClassifiedID)
        {
            Classified ret = null;
            parameters.Clear();
            parameters.Add("@ClassifiedID", ClassifiedID);
            using (DbDataReader result = DbOperation.GetData(context, "SelectClassifiedWID", parameters))
            {
                ret = DataHelper.ReaderToModel<Classified>(result);
                result.Close();
            }
            return ret;
        }

        public void InsertClassified(Classified Classified, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@ClassifiedTitle",Classified.ClassifiedTitle),
                new SqlParameter("@ClassifiedDescription",Classified.ClassifiedDescription),
                new SqlParameter("@ClassifiedBy",Classified.ClassifiedBy),
                new SqlParameter("@ClassifiedImage",Classified.ClassifiedImage),
                new SqlParameter("@Flexfld1",Classified.Flexfld1),
                new SqlParameter("@Flexfld2",Classified.Flexfld2),
                new SqlParameter("@Flexfld3",Classified.Flexfld3),
                new SqlParameter("@Flexfld4",Classified.Flexfld4),
                new SqlParameter("@Flexfld5",Classified.Flexfld5),
                new SqlParameter("@UserID",  Classified.UserID)
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec InsertClassified @ClassifiedTitle,@ClassifiedDescription,@ClassifiedBy,@ClassifiedImage,@Flexfld1,@Flexfld2,@Flexfld3,@Flexfld4,@Flexfld5,@UserID,@status OUTPUT", @params);
                status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateClassified(Classified Classified, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@ClassifiedID",Classified.ClassifiedID),
                new SqlParameter("@ClassifiedTitle",Classified.ClassifiedTitle),
                new SqlParameter("@ClassifiedDescription",Classified.ClassifiedDescription),
                new SqlParameter("@ClassifiedBy",Classified.ClassifiedBy),
                new SqlParameter("@ClassifiedImage",Classified.ClassifiedImage),
                new SqlParameter("@Flexfld1",Classified.Flexfld1),
                new SqlParameter("@Flexfld2",Classified.Flexfld2),
                new SqlParameter("@Flexfld3",Classified.Flexfld3),
                new SqlParameter("@Flexfld4",Classified.Flexfld4),
                new SqlParameter("@Flexfld5",Classified.Flexfld5),
                new SqlParameter("@UserID",  Classified.UserID)
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec UpdateClassified @ClassifiedID,@ClassifiedTitle,@ClassifiedDescription,@ClassifiedBy,@ClassifiedImage,@Flexfld1,@Flexfld2,@Flexfld3,@Flexfld4,@Flexfld5,@UserID,@status OUTPUT", @params);

                status = @params[0].Value.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteClassified(string ClassifiedID, string UserID, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@ClassifiedID",ClassifiedID),
                new SqlParameter("@UserID", UserID),
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec DeleteClassified @ClassifiedID,@UserID,@status OUTPUT", @params);

                status = @params[0].Value.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActiveInActiveClassified(string IsActive, string ClassifiedID, string UserID, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@IsActive",IsActive),
                new SqlParameter("@ClassifiedID",ClassifiedID),
                new SqlParameter("@UserID", UserID),
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec ActiveInActiveClassified @ClassifiedID,@IsActive,@UserID,@status OUTPUT", @params);

                status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Classified> GetClassifiedList(string UserID)
        {
            try
            {
                List<Classified> ClassifiedList = new List<Classified>();
                parameters.Clear();
                parameters.Add("UserID", UserID);

                using (DbDataReader rdr = DbOperation.GetData(context, "API_Classified", parameters))
                {
                    ClassifiedList = DataHelper.ReaderToList<Classified>(rdr);
                    rdr.Close();
                    return ClassifiedList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
