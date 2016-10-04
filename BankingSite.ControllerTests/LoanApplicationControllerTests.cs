
using BankingSite.Controllers;
using BankingSite.Models;
using FizzWare.NBuilder;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class LoanApplicationControllerTests
    {
        [Test]
        public void ShouldRenederDefaultView()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
        }

        [Test]
        public void ShouldRenederToAcceptedViewOnSuccessfulApplication()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var acceptedApplication = new LoanApplication
            {
                IsAccepted = true
            };

            //sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
        }

        [Test]
        public void ShouldRenederToAcceptedViewOnSuccessfulApplication1()
        {
            var fakeRepository = new Mock<IRepository>();
            
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();
           

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);
            var acceptedApplication =
                Builder<LoanApplication>.CreateNew()
                .With(x => x.IsAccepted = true)
                .Build();



            ActionResult result = sut.Apply(acceptedApplication);
            //Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Accepted");


            // sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
           

            //HomeController homeController = new HomeController();
            //ActionResult result = homeController.Index(10);
            //Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            //RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            //Assert.AreEqual(routeResult.RouteValues["action"], "asd");

        }
    }
}
