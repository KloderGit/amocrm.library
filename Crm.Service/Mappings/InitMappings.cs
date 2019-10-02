using System;
using System.Collections.Generic;
using System.Text;
using amocrm.library.Interfaces;
using amocrm.library.Models.Account;

namespace amocrm.library.Mappings
{
    internal class InitMappings
    {
        public InitMappings()
        {
            new CompanyMaps();
            new ContactMaps();
            new LeadtMaps();
            new NoteMaps();
            new TaskMaps();
        }

    }
}
