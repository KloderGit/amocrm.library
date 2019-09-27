using amocrm.library.Configurations;
using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace amocrm.library.Models
{
    public class Company : EntityMember, IValidate<Company>
    {
        public int UpdatedBy { get; set; }
        public IEnumerable<int> Leads { get; set; } = new List<int>();
        public IEnumerable<int> Contacts { get; set; } = new List<int>();
        public IEnumerable<int> Customers { get; set; } = new List<int>();

        public bool Validate(IValidateRules<Company> validateRules)
        {
            return validateRules.ValidateBool(this);
        }

        public virtual Field Phone() => this.GetField((int)CompanySystemFields.Phone);

        public virtual void Phone(string value, PhoneTypeEnum type = PhoneTypeEnum.MOB)
        {
            if (String.IsNullOrEmpty(value)) return;
            SetField((int)ContactSystemFields.Phone, value, (int)type);
        }

        public virtual void AddPhone(string value, PhoneTypeEnum type = PhoneTypeEnum.MOB)
        {
            if (String.IsNullOrEmpty(value) || CheckPhoneDouble(value)) return;
            SetField((int)ContactSystemFields.Phone, value, (int)type, add: true);
        }

        bool CheckPhoneDouble(string phone)
        {
            var phones = Phone();

            if (phones == null) return false;

            return phones.Values.Select(x => CutPhoneCode(x.Value)).Any(x => x == CutPhoneCode(phone));

            string CutPhoneCode(string item)
            {
                Regex regex = new Regex(@"[^0-9]");
                string str = regex.Replace(item, "");

                string substring = str.Length >= 10 ? str.Substring(str.Length - 10) : str;

                return substring;
            }
        }


        public virtual Field Email() => this.GetField((int)CompanySystemFields.Email);

        public virtual void Email(string value, EmailTypeEnum type = EmailTypeEnum.PRIV)
        {
            if (String.IsNullOrEmpty(value)) return;
            SetField((int)ContactSystemFields.Email, value, (int)type);
        }

        public virtual void AddEmail(string value, EmailTypeEnum type = EmailTypeEnum.PRIV)
        {
            if (String.IsNullOrEmpty(value) || CheckEmailDouble(value)) return;
            SetField((int)ContactSystemFields.Email, value, (int)type, add: true);
        }

        bool CheckEmailDouble(string email)
        {
            var emails = Email();

            if (emails == null) return false;

            var array = Email().Values.Select(x => x.Value.Replace(" ", String.Empty));
            return array.Any(x => x == email.Replace(" ", String.Empty));
        }

        public virtual Field Web() => this.GetField((int)CompanySystemFields.Web);
        public void Web(string value)
        {
            if (String.IsNullOrEmpty(value)) return;
            SetField((int)CompanySystemFields.Web, value);
        }

        public virtual Field Location() => this.GetField((int)CompanySystemFields.Location);
        public void Location(string value)
        {
            if (String.IsNullOrEmpty(value)) return;
            SetField((int)CompanySystemFields.Location, value);
        }
    }
}