namespace amocrm.library.Configurations
{
    public enum TaskType
    {
        Звонок = 1,
        Встреча = 2,
        Написать_письмо = 3
    }

    public enum ElementTypeEnum
    {
        Контакт = 1,
        Сделка = 2,
        Компания = 3,
        Задача = 4,
    }
    public enum ElementTypesEnum
    {
        Contact = 1,
        Lead = 2,
        Company = 3,
        Task = 4,
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

    public enum PhoneTypeEnum
    {
        NotSet = 0,
        MOB = 114611,
        WORK = 114607,
        OTHER = 114617,
        WORKDD = 114609,
        HOME = 114615,
        FAX = 114613
    }

    public enum EmailTypeEnum
    {
        NotSet = 0,
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
