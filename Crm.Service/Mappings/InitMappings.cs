using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Mappings
{
    public class InitMappings
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
