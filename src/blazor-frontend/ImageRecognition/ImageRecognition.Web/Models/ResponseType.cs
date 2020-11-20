using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageRecognition.Web.Models
{
    public enum ResponseType
    {
        Unknown,
        Ok,
        PasswordChangeRequired,
        RegisterOk,
        NotAuthorized,
        Error,
        UserNotFound,
        UserNameAlreadyUsed,
        EmailAlreadyUsed,
        PasswordRequirementsFailed,
        NotConfirmed,
        Timeout,
        Offline
    }
}
