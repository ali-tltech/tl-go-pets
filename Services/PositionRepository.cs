using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.Common;
using System.Data;
using TLCAREERSCORE.Models;
using System.Xml.Linq;
using System.Runtime.Intrinsics.Arm;

namespace TLCAREERSCORE.Services
{
	public class PositionRepository: IPosition
    {
        private readonly AppDbContext context;

        public PositionRepository(AppDbContext context)
        {
            this.context = context;
        }

        Dictionary<string, object> parameters = new Dictionary<string, object>();

        public DataTableResult GetPositionRepositoryInfo(DataTableRequest dataTableRequest)
        {
            List<Position> Positions = new List<Position>();
            parameters.Clear();
            parameters.Add("DisplayLength", dataTableRequest.length);
            parameters.Add("DisplayStart", dataTableRequest.start);
            parameters.Add("SortCol", dataTableRequest.orders.ElementAt(0).column);
            parameters.Add("SortDir", dataTableRequest.orders.ElementAt(0).dir.ToLower());
            parameters.Add("Search", string.IsNullOrEmpty(dataTableRequest.search.value.ToUpper()) ? null : dataTableRequest.search.value.ToUpper());
            parameters.Add("UserID", dataTableRequest.UserID);
            parameters.Add("StartDate", string.IsNullOrEmpty(dataTableRequest.StartDate) ? "2019-01-01" : dataTableRequest.StartDate);
            parameters.Add("EndDate", string.IsNullOrEmpty(dataTableRequest.EndDate) ? "2025-12-01" : dataTableRequest.EndDate);

            using (DbDataReader rdr = DbOperation.GetData(context, "spGetPosition", parameters))
            {
                Positions = DataHelper.ReaderToList<Position>(rdr);
                rdr.Close();

                DataTableResult dataTableResult = new DataTableResult();
                dataTableResult.Draw = dataTableRequest.draw;
                dataTableResult.Data = Positions;

                dataTableResult.RecordsTotal = Positions.Count == 0 ? 0 : Positions[0].TotalRecordCount;   //TotalRecordCount; //GetPositionCount(dataTableRequest);
                dataTableResult.RecordsFiltered = Positions.Count == 0 ? 0 : Positions[0].TotalCount;

                return dataTableResult;
            }
        }

        public Position GetPosition(string PositionID)
        {
            Position ret = null;
            parameters.Clear();
            parameters.Add("@PositionID", PositionID);
            using (DbDataReader result = DbOperation.GetData(context, "SelectPositionWID", parameters))
            {
                ret = DataHelper.ReaderToModel<Position>(result);
                result.Close();
            }
            return ret;
        }

        public void InsertPosition(Position Position, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@PositionTitle",Position.PositionTitle),
                new SqlParameter("@PositionDescription",Position.PositionDescription),
                //new SqlParameter("@WorkLocation",Position.WorkLocation),
                new SqlParameter("@WorkLocation", Position.WorkLocation == null ?DBNull.Value:Position.WorkLocation),
                new SqlParameter("@Salary",Position.Salary),
                new SqlParameter("@Flexfld1",Position.Flexfld1),
                new SqlParameter("@Flexfld2",Position.Flexfld2),
                new SqlParameter("@Flexfld3",Position.Flexfld3),
                new SqlParameter("@Flexfld4",Position.Flexfld4),
                new SqlParameter("@Flexfld5",Position.Flexfld5),
              //  new SqlParameter("@UserID",  Position.UserID)
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec InsertPosition @PositionTitle,@PositionDescription,@WorkLocation,@Salary,@Flexfld1,@Flexfld2,@Flexfld3,@Flexfld4,@Flexfld5,@status OUTPUT", @params);
                status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePosition(Position Position, out string status)
        {
            SqlParameter[] @params =
            {

                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@PositionID",Position.PositionID),
                new SqlParameter("@PositionTitle",Position.PositionTitle),
                new SqlParameter("@PositionDescription",Position.PositionDescription),
                new SqlParameter("@WorkLocation", Position.WorkLocation == null ?DBNull.Value:Position.WorkLocation),
                new SqlParameter("@Salary",Position.Salary),
                new SqlParameter("@Flexfld1",Position.Flexfld1),
                new SqlParameter("@Flexfld2",Position.Flexfld2),
                new SqlParameter("@Flexfld3",Position.Flexfld3),
                new SqlParameter("@Flexfld4",Position.Flexfld4),
                new SqlParameter("@Flexfld5",Position.Flexfld5),
             //   new SqlParameter("@UserID",  Position.UserID)
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec UpdatePosition @PositionID,@PositionTitle,@PositionDescription,@WorkLocation,@Salary,@Flexfld1,@Flexfld2,@Flexfld3,@Flexfld4,@Flexfld5,@status OUTPUT", @params);

                status = @params[0].Value.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePosition(string PositionID, string UserID, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@PositionID",PositionID),
                new SqlParameter("@UserID", UserID),
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec DeletePosition @PositionID,@UserID,@status OUTPUT", @params);

                status = @params[0].Value.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActiveInActivePosition(string IsActive, string PositionID, string UserID, out string status)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@status", SqlDbType.VarChar,100) {Direction = ParameterDirection.Output},
                new SqlParameter("@IsActive",IsActive),
                new SqlParameter("@PositionID",PositionID),
                new SqlParameter("@UserID", UserID),
            };

            try
            {
                context.Database.ExecuteSqlRaw("exec ActiveInActivePosition @PositionID,@IsActive,@UserID,@status OUTPUT", @params);

                status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Position> GetPositionList(string UserID)
        {
            try
            {
                List<Position> PositionList = new List<Position>();
                parameters.Clear();
                parameters.Add("UserID", UserID);

                using (DbDataReader rdr = DbOperation.GetData(context, "API_Position", parameters))
                {
                    PositionList = DataHelper.ReaderToList<Position>(rdr);
                    rdr.Close();
                    return PositionList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<Position> GetSearchPosition(string position)
        {
            List<Position> PositionList = new List<Position>();
            parameters.Clear();
            parameters.Add("@position", position);
            using (DbDataReader result = DbOperation.GetData(context, "SelectSearchPositionID", parameters))
            {
                PositionList = DataHelper.ReaderToList<Position>(result);
                result.Close();
                return PositionList;
            }
        }
      
    }
}
