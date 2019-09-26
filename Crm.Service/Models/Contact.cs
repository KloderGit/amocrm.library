using amocrm.library.Configurations;
using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace amocrm.library.Models
{
    public class Contact : EntityMember, IValidate<Contact>
    {
        public int UpdatedBy { get; set; }

        public IEnumerable<int> Leads { get; set; } = new List<int>();

        public SimpleObject Company { get; set; }

        public IEnumerable<int> Customers { get; set; } = new List<int>();

        public bool Validate(IValidateRules<Contact> validateRules)
        {
            return validateRules.ValidateBool(this);
        }

        public virtual Field Phone() => this.GetField((int)ContactSystemFields.Phone);

        public virtual void Phone(string value)
        {
            IEnumerable<int> curentTypes = new List<int>();

            if (this.Fields?.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Phone)?.Values != null)
                curentTypes = Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Phone)
                .Values.Select(x => x.Enum);

            var allTypes = new List<int> { 114611, 114607, 114617, 114609, 114615, 114613 }.Except(curentTypes);
            var nextType = allTypes.FirstOrDefault();

            Phone(value, (PhoneTypeEnum)nextType);
        }

        public virtual void Phone(string value, PhoneTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || CheckPhoneDouble(value)) return;
            SetField((int)ContactSystemFields.Phone, value, (int)type);
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

        public virtual Field Email() => this.GetField((int)ContactSystemFields.Email);

        public virtual void Email(string value)
        {
            IEnumerable<int> curentTypes = new List<int>();

            if (this.Fields?.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Email)?.Values != null)
                curentTypes = Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Email)
                .Values.Select(x => x.Enum);

            var allTypes = new List<int> { 114621, 114619, 114623 }.Except(curentTypes);
            var nextType = allTypes.Except(curentTypes).FirstOrDefault();

            Email(value, (EmailTypeEnum)nextType);
        }

        public virtual void Email(string value, EmailTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || CheckEmailDouble(value)) return;
            SetField((int)ContactSystemFields.Email, value, (int)type);
        }

        bool CheckEmailDouble(string email)
        {
            var emails = Email();

            if (emails == null) return false;

            var array = Email().Values.Select(x => x.Value.Replace(" ", String.Empty));
            return array.Any(x => x == email.Replace(" ", String.Empty));
        }


        public virtual Field Position() => this.GetField((int)ContactSystemFields.Position);
        public void Position(string value)
        {
            if (String.IsNullOrEmpty(value)) return;
            SetField((int)ContactSystemFields.Position, value);
        }

        public virtual Field Messenger() => this.GetField((int)ContactSystemFields.Messenger);

        public virtual void Messenger(string value, MessengerTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || type == default) return;
            SetField((int)ContactSystemFields.Messenger, value, (int)type);
        }

        public virtual Field Agreement() => GetField((int)ContactSystemFields.Agreement);
        public virtual void Agreement(bool value) => SetField((int)ContactSystemFields.Agreement, value ? "1" : null);

    }
}