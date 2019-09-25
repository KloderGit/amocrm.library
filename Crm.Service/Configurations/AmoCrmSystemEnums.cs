namespace amocrm.library.Configurations
{
    public enum FieldType
    {
        TEXT = 1,
        NUMERIC = 2,
        CHECKBOX = 3,
        SELECT = 4,
        MULTISELECT = 5,
        DATE = 6,
        URL = 7,
        MULTITEXT = 8,
        TEXTAREA = 9,
        RADIOBUTTON = 10,
        STREETADDRESS = 11,
        SMART_ADDRESS = 13,
        BIRTHDAY = 14,
        LEGAL_ENTITY = 15,
        ITEMS = 16,
        ORG_LEGAL_NAME = 17
    }


    public enum TaskType
    {
        Звонок = 1,
        Встреча = 2,
        Написать_письмо = 3
    }

    public enum ElementTypeEnum
    {
        Contact = 1,
        Lead = 2,
        Company = 3,
        Task = 4,
        Customer = 12
    }

    public enum NoteType
    {
        DEAL_CREATED = 1,
        CONTACT_CREATED = 2,
        DEAL_STATUS_CHANGED = 3,
        COMMON = 4,
        ATTACHMENT = 5,
        CALL_IN = 10,
        CALL_OUT = 11,
        COMPANY_CREATED = 12,
        TASK_RESULT = 13,
        SYSTEM = 25,
        SMS_IN = 102,
        SMS_OUT = 103
    }

    public enum ContactSystemFields
    {
        Phone = 54667,
        Position = 54665,
        Email = 54669,
        Messanger = 54673,
        Agreement = 573355
    }


    public enum PhoneTypeEnum
    {
        MOB = 114611,
        WORK = 114607,
        OTHER = 114617,
        WORKDD = 114609,
        HOME = 114615,
        FAX = 114613
    }

    public enum EmailTypeEnum
    {
        PRIV = 114621,
        WORK = 114619,
        OTHER = 114623
    }

    public enum MessengerTypeEnum
    {
        NotSet = 0,
        SKYPE = 114625,
        ICQ = 114627,
        JABBER = 114629,
        GTALK = 114631,
        MSN = 114633,
        OTHER = 114635
    }
}
