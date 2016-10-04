using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSite.IntegrationTests
{
    [SetUpFixture]
    public class TestFixtureLifecycle
    {
        public TestFixtureLifecycle()
        {
            EnsureDataDirectoryConnectionStringPlaceholderIsSet();
            EnsureNoExistingDatabaseFiles();
        }


        private static void EnsureDataDirectoryConnectionStringPlaceholderIsSet()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
        }

        private void EnsureNoExistingDatabaseFiles()
        {
            const string connectionStrings = "name=DefaultConnection";
            if(Database.Exists(connectionStrings))
            {
                Database.Delete(connectionStrings);
            }
        }
    }
}
