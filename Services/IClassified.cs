using TLCAREERSCORE.Models;

namespace TLCAREERSCORE.Services
{
    public interface IClassified
    {
        public DataTableResult GetClassifiedRepositoryInfo(DataTableRequest dataTableRequest);

        public Classified GetClassified(string ClassifiedID);

        public void InsertClassified(Classified Classified, out string status);

        public void UpdateClassified(Classified Classified, out string status);

        public void DeleteClassified(string ClassifiedID, string UserID, out string status);

        public void ActiveInActiveClassified(string IsActive, string ClassifiedID, string UserID, out string status);

        public List<Classified> GetClassifiedList(string UserID);
    }
}
