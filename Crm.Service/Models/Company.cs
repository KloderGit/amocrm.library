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

        public virtual void Phone(string value)
        {
            IEnumerable<int> curentTypes = new List<int>();

            if (this.Fields?.FirstOrDefault(fl => fl.Id == (int)CompanySystemFields.Phone)?.Values != null)
                curentTypes = Fields.FirstOrDefault(fl => fl.Id == (int)CompanySystemFields.Phone)
                .Values.Select(x => x.Enum);

            var allTypes = new List<int> { 114611, 114607, 114609, 114615, 114613, 114617 }.Except(curentTypes);
            var nextType = allTypes.FirstOrDefault();

            Phone(value, (PhoneTypeEnum)nextType);
        }

        public virtual void Phone(string value, PhoneTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || CheckPhoneDouble(value)) return;
            SetField((int)CompanySystemFields.Phone, value, (int)type);
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

        public virtual void Email(string value)
        {
            IEnumerable<int> curentTypes = new List<int>();

            if (this.Fields?.FirstOrDefault(fl => fl.Id == (int)CompanySystemFields.Email)?.Values != null)
                curentTypes = Fields.FirstOrDefault(fl => fl.Id == (int)CompanySystemFields.Email)
                .Values.Select(x => x.Enum);

            var allTypes = new List<int> { 114621, 114619, 114623 }.Except(curentTypes);
            var nextType = allTypes.Except(curentTypes).FirstOrDefault();

            Email(value, (EmailTypeEnum)nextType);
        }

        public virtual void Email(string value, EmailTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || CheckEmailDouble(value)) return;
            SetField((int)CompanySystemFields.Email, value, (int)type);
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