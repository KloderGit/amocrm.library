using amocrm.library.Configurations;
using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Field Phone() => this.GetField((int)ContactSystemFields.Phone);

        public void Phone(string value)
        {
            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Phone)
                .Values ?? new List<FieldValue>();

            var curentTypes = values.Select(x => x.Enum) ?? new List<int>();
            var allTypes = new List<int> { 114611, 114607, 114617, 114609, 114615, 114613 }.Except(curentTypes);
            var nextType = allTypes.FirstOrDefault();

            Phone(value, (PhoneTypeEnum)nextType);
        }

        public void Phone(string value, PhoneTypeEnum type)
        {
            if (String.IsNullOrEmpty(value)) return;

            this.Fields = this.Fields ?? new List<Field>();

            if (!this.Fields.Any(fl => fl.Id == (int)ContactSystemFields.Phone))
                this.Fields.Add(new Field { Id = (int)ContactSystemFields.Phone });

            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Phone)
                .Values ?? new List<FieldValue>();

            values.Add(new FieldValue { Enum = (int)type, Value = value });
        }


        public Field Email() => this.GetField((int)ContactSystemFields.Email);

        public void Email(string value)
        {
            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Email)
                .Values ?? new List<FieldValue>();

            var curentTypes = values.Select(x => x.Enum) ?? new List<int>();
            var allTypes = new List<int> { 114621, 114619, 114623 }.Except(curentTypes);
            var nextType = allTypes.Except(curentTypes).FirstOrDefault();

            Email(value, (EmailTypeEnum)nextType);
        }

        public void Email(string value, EmailTypeEnum type)
        {
            if (String.IsNullOrEmpty(value)) return;

            this.Fields = this.Fields ?? new List<Field>();

            if (!this.Fields.Any(fl => fl.Id == (int)ContactSystemFields.Email))
                this.Fields.Add(new Field { Id = (int)ContactSystemFields.Email });

            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Email)
                .Values ?? new List<FieldValue>();

            values.Add(new FieldValue { Enum = (int)type, Value = value });
        }


        public Field Position() => this.GetField((int)ContactSystemFields.Position);

        public void Position(string value)
        {
            if (String.IsNullOrEmpty(value)) return;

            this.Fields = this.Fields ?? new List<Field>();

            if (!this.Fields.Any(fl => fl.Id == (int)ContactSystemFields.Position))
                this.Fields.Add(new Field { Id = (int)ContactSystemFields.Position });

            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Position)
                .Values ?? new List<FieldValue>();

            values.Add(new FieldValue { Value = value });
        }


        public Field Messanger() => this.GetField((int)ContactSystemFields.Messanger);

        public void Messanger(string value, MessengerTypeEnum type)
        {
            if (String.IsNullOrEmpty(value) || type == default) return;

            this.Fields = this.Fields ?? new List<Field>();

            if (!this.Fields.Any(fl => fl.Id == (int)ContactSystemFields.Position))
                this.Fields.Add(new Field { Id = (int)ContactSystemFields.Position });

            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Position)
                .Values ?? new List<FieldValue>();

            values.Add(new FieldValue { Value = value, Enum = (int)type });
        }


        public Field Agreement() => GetField((int)ContactSystemFields.Agreement);

        public void Agreement(bool value)
        {
            this.Fields = Fields ?? new List<Field>();

            if (!this.Fields.Any(fl => fl.Id == (int)ContactSystemFields.Agreement))
                this.Fields.Add(new Field { Id = (int)ContactSystemFields.Agreement });

            var values = this.Fields.FirstOrDefault(fl => fl.Id == (int)ContactSystemFields.Agreement)
                .Values ?? new List<FieldValue>();

            values.Add(new FieldValue { Value = value ? "1" : null });
        }
    }
}