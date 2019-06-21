using Abonnements.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserSignUp
    {
        public ValidatableObject<string> Mail;
        public ValidatableObject<string> Password;
        public ValidatableObject<string> FirstName;
        public ValidatableObject<string> LastName;
    }
}
