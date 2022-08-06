using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlkemyChallenge.Application.Utils
{
    public interface ISendGrid
    {
        public Task SendMail(string email, string subject, string htmlContent);
    }
}
