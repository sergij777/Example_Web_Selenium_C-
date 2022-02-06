using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SushimasterTests
{    
    [TestClass]
    public class C22200_SuccessEnterDateAndTimeInCheckoutPageTypeDelivery : ITest
    {                
        [TestCategory("Smoke")]
        [Description("Ввод даты доставки на странице Checkout, проверка даты")]
        [DynamicDataCheckoutDeliveryAdressFixed]
        [DataTestMethod]
        public void EnterDateInCheckoutPageTypeDelivery(string street, string house)
        {
            //Arrange
            OpenSite();            
            Precondition.FirstVisitCheckoutPageChoosingDeliveryMethodDelivery();

            var pageCheckout = new POMCheckoutPage(Driver);
            pageCheckout.InputStreetInputTextClick(street);
            pageCheckout.InputHouseInputTextClick(house);  
            pageCheckout.CheckboxTimeCheck();         
            var expectedDate = pageCheckout.SelectDateDeliveryGetText();

            //Act
            pageCheckout.SelectDateDeliverySelectPosition(2);

            //Actual   
            var actualDate = pageCheckout.SelectDateDeliveryGetText();
            SuccessMessage = $"Текущая дата доставки выбирается, меняется и отображается.";
            ErrorSide = FRONT;
            ErrorMessage= $"При изменении текущей даты {expectedDate} на следующую в списке, отображается {actualDate} ."; 
            
            //Assert 
            Assert.AreNotEqual(expectedDate, actualDate, ErrorMessage);

        }
               
        [TestCategory("Smoke")]
        [Description("Выбор времени доставки на странице Checkout, проверка времени")]
        [DynamicDataCheckoutDeliveryAdressFixed]
        [DataTestMethod]
        public void EnterTimeInCheckoutPageTypeDelivery(string street, string house)
        {
            //Arrange
            OpenSite();           
            Precondition.FirstVisitCheckoutPageChoosingDeliveryMethodDelivery();

            var pageCheckout = new POMCheckoutPage(Driver);
            pageCheckout.InputStreetInputTextClick(street);
            pageCheckout.InputHouseInputTextClick(house);              
            pageCheckout.CheckboxTimeCheck(); 
            pageCheckout.SelectDateDeliverySelectPosition(2);
            pageCheckout.SelectTimeDeliverySelectPosition(1);
            var expectedTime = pageCheckout.SelectTimeDeliveryGetText();            

            //Act
            pageCheckout.SelectTimeDeliverySelectPosition(2);
            var nextTime = pageCheckout.SelectTimeDeliveryGetText();
            pageCheckout.SelectTimeDeliverySelectPosition();

            //Actual               
            var actualTime = pageCheckout.SelectTimeDeliveryGetText();
            SuccessMessage = $"Время доставки выбирается, меняется и отображается.";
            ErrorSide = FRONT;
            
            //Assert 
            ErrorMessage= $"При изменении текущего времени {expectedTime} на следующее в списке, отображается {nextTime} .";         
            Assert.AreNotEqual(expectedTime, nextTime, ErrorMessage);

            ErrorMessage= $"При изменении текущего времени {expectedTime} на следующее и опять на текущее отображается {actualTime} .";         
            Assert.AreEqual(expectedTime, actualTime, ErrorMessage);       

        }

        [ClassInitialize] 
        public static void ClassInit(TestContext testContext)
        {
            CaseId = "22200";
            TestClassInit(testContext);
        }
    }
}
