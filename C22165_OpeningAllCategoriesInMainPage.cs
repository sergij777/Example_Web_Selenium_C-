using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SushimasterTests
{    
    [TestClass]
    public class C22165_OpeningAllCategoriesInMainPage : ITest
    {
        
        [TestCategory("Smoke")]
        [Description("Открытие категорий, проверка названия открытой категории")]
        [TestMethod]
        public void OpeningAllCategories()
        {            
            //Arrange
            OpenSite();       
            var pageMain = new POMMainPage(Driver);
            var pageProduct = new POMProductPage(Driver);
            var pageCategory = new POMCategoryPage(Driver);                           
            var popupAcceptCity = new POMCityAcceptPopUp(Driver);
            popupAcceptCity.ButtonAcceptCityClick(); 
            pageMain.ButtonCookiesWindowCloseClick();
            pageMain.ButtonCanсelSubscriptionClick();

            string expectedCategoryName;
            string actualCategoryName;
            bool categoriesEqual = true;

            //Act
            pageMain.LinkFirstCategoryClick();
            
            //Actual
            SuccessMessage = $"Все категории открываются, название каждой открытой категории совпадает.";
            ErrorSide = FRONT;            
            
            var categories = pageCategory.GetListCategories();  
            foreach (var item in categories)
            {
                expectedCategoryName = pageCategory.GetText(item).ToLower(); 
                pageCategory.HorizontalScrolToElement(item);                               
                pageCategory.Click(item);                
                actualCategoryName = pageCategory.TextCategoryTitleGetText().ToLower();

                if (expectedCategoryName != actualCategoryName)
                {
                    categoriesEqual = false;
                    ErrorMessage+= $" При клике на категорию {expectedCategoryName} открывается категория: {actualCategoryName}.";
                }
            }       

            //Assert 
            Assert.IsTrue(categoriesEqual, ErrorMessage);             
        }
        
        [ClassInitialize] 
        public static void ClassInit(TestContext testContext)
        {
            CaseId = "22165";
            TestClassInit(testContext);
        }
    }
}