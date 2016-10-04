using BankingSite.Models;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void ShouldPopulateIdOnCreateLoanApplication()
        {
            var sut = new Repository();
            var applicationToSave = new LoanApplication
            {
                FirstName = "Georgiana",
                LastName = "Stan",
                Age = 29,
                AnnualIncome = 12345.67m
            };

            sut.Create(applicationToSave);
            Assert.That(applicationToSave.ID, Is.Not.EqualTo(0));
        }
    }
}
