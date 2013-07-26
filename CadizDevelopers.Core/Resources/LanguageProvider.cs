using CadizDevelopers.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Resources
{
    public class LanguageProvider
    {
        public LanguageProvider()
        { }

        private static AppResources actualMessages;

        public static AppResources ActualMessages
        {
            get
            {
                if (actualMessages == null)
                {
                    actualMessages = new AppResources();
                }
                return actualMessages;
            }
        }
    }
}
