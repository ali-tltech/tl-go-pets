using TLCAREERSCORE.Models;

namespace TLCAREERSCORE.Services
{
	public interface IPosition
	{
        public DataTableResult GetPositionRepositoryInfo(DataTableRequest dataTableRequest);

        public Position GetPosition(string PositionID);

        public void InsertPosition(Position Position, out string status);

        public void UpdatePosition(Position Position, out string status);

        public void DeletePosition(string PositionID, string UserID, out string status);

        public void ActiveInActivePosition(string IsActive, string PositionID, string UserID, out string status);

        public IList<Position> GetPositionList(string UserID);
        public IList<Position> GetSearchPosition(string position);
    }
}
