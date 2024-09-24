using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TLCAREERSCORE.Models;
using System.Xml.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace TLCAREERSCORE.Services
{
    public class ApplicationRepository :IApplication
    {
        private readonly AppDbContext context;

        public ApplicationRepository(AppDbContext context)
        {
            this.context = context;
        }

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        public Application InsertApplication(Application application)
        {
            SqlParameter[] @params =
            {
                
       
                new SqlParameter("@SubscriberEmail",application.email),

            };

            try
            {
                context.Database.ExecuteSqlRaw("exec InsertSubscriber @SubscriberEmail", @params);
                //status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }

        
            return application;
        }



    }
    

}
