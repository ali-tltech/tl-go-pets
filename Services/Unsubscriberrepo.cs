using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TLCAREERSCORE.Models;
using System.Xml.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using TLgopetz.Services;

namespace TLCAREERSCORE.Services
{ 
    public class Unsubscriberrepo : IUnsubscribe
    {
        private readonly AppDbContext context;

        public Unsubscriberrepo(AppDbContext context)
        {
            this.context = context;
        }

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        public unsubcribemodel UnsubscribeApplication(unsubcribemodel unsubcribemodel)
        {
            SqlParameter[] @params =
            {


                new SqlParameter("@SubscriberEmail",unsubcribemodel.email),

            };

            try
            {
                context.Database.ExecuteSqlRaw("exec UnsubscribeSubscriber @SubscriberEmail", @params);
                //status = @params[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }


            return unsubcribemodel;
        }

        
    }


}

