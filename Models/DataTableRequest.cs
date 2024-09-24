using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;

namespace TLCAREERSCORE.Models
{
    [ModelBinder(BinderType = typeof(DTModelBinder))]

    public class DataTableRequest
    {
        public int draw { get; set; }

        public int start { get; set; }

        public int length { get; set; }

        public string UserID { get; set; }

        public List<Order> orders { get; set; }

        public List<Column> columns { get; set; }

        public Search search { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

    }

    public class Order
    {
        public int column { get; set; } 
        public string dir { get; set; } 
    }

    public class Column
    { 
        public string data { get; set; } 
        public string name { get; set; } 
        public bool searchable { get; set; }
        public bool orderable { get; set; } 
        public Search search { get; set; }

    }

    public class Search
    {
        public string value { get; set; }

        public bool regex { get; set; }
    }

    public class DTModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            var request = bindingContext.ActionContext.HttpContext.Request.Form;
            // Retrieve request data
            var draw = Convert.ToInt32(request["draw"]);

            var start = Convert.ToInt32(request["start"]);

            var UserID = Convert.ToString(request["UserID"]);

            var length = Convert.ToInt32(request["length"]);
            // Search
            var search = new Search
            {
                value = request["search[value]"],
                regex = Convert.ToBoolean(request["search[regex]"])
            };
            // Order
            var o = 0;
            var order = new List<Order>();
            while (!string.IsNullOrEmpty(request["order[" + o + "][column]"]))
            {
                order.Add(new Order
                {
                    column = Convert.ToInt32(request["order[" + o + "][column]"]),
                    dir = request["order[" + o + "][dir]"]
                });
                o++;
            }
            // Columns
            var c = 0;
            var columns = new List<Column>();
            while (!string.IsNullOrEmpty(request["columns[" + c + "][name]"]))
            {
                columns.Add(new Column
                {
                    data = request["columns[" + c + "][data]"],
                    name = request["columns[" + c + "][name]"],
                    orderable = Convert.ToBoolean(request["columns[" + c + "][orderable]"]),
                    searchable = Convert.ToBoolean(request["columns[" + c + "][searchable]"]),
                    search = new Search
                    {
                        value = request["columns[" + c + "][search][value]"],
                        regex = Convert.ToBoolean(request["columns[" + c + "][search][regex]"])
                    }
                });
                c++;
            }

            var result = new DataTableRequest
            {
                draw = draw,
                UserID = UserID,
                start = start,
                length = length,
                search = search,
                orders = order,
                columns = columns

            };

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }

    }

    public class DataTableResult
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }

        public IList Data { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

    }
}
