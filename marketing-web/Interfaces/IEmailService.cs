using marketing_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Contact contact);
    }
}
