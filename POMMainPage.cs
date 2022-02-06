using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SushimasterTests
{
    public class POMMainPage:IPOM
    {   

    #region Selectors

        ///<summary>Ссылка Акции</summary>
        private By linkActions = By.XPath("(//div[@class='header-info__menu_item'])[1]");

        ///<summary>Ссылка Доставка</summary>
        private By linkDelivery = By.XPath("(//div[@class='header-info__menu_item'])[2]");

        // Удалили  блок Бонусы, поэтому нарушился порядок
        ///<summary>Ссылка Бонуси</summary>
        private By linkBonus = By.XPath("(//div[@class='header-info__menu_item'])[3]");

        ///<summary>Ссылка О компании</summary>
        private By linkAboutCompany = By.XPath("(//div[@class='header-info__menu_item'])[3]");

        ///<summary>Ссылка Вакансии</summary>
        private By linkVacancy = By.XPath("(//div[@class='header-info__menu_item'])[4]");

        ///<summary>Ссылка Франшиза</summary>
        private By linkFranchise = By.XPath("(//div[@class='header-info__menu_item'])[5]");

        ///<summary>Кнопка Поиск</summary>
        private By buttonSearch = By.XPath("//button[@class='sc-EHOje kTaOcc']");

        ///<summary>Ссылка избранные товары</summary>
        private By linkFavorite = By.XPath("//div[@class='sc-kafWEX gCIOhh']");

        ///<summary>Счетчик количества товара на иконке корзины для PC</summary>
        private By buttonCartIconCounterPC = By.XPath("(//div[@class='cart-block__icon__count red'])[1]");
        
        ///<summary>Счетчик количества товара на иконке корзины для адаптивов</summary>
        private By buttonCartIconCounterAndroidIos = By.XPath("(//div[@class='cart-block__icon__count red'])[2]");
        
        ///<summary>Кнопка ХОЧУ</summary>
        private By buttonWant = By.CssSelector("div.cart-button__collapsed");
        
        ///<summary>Иконка корзины на товаре (хочу) </summary>
        private By buttonWantIconCart = By.ClassName("cart-button__collapsed__cart_icon");  

        ///<summary>Иконка корзины для PC</summary>
        private By buttonCartIconPC = By.XPath("(//div[@class='cart-block__icon '])[1]");

        ///<summary>Иконка корзины для адаптивов</summary>
        private By buttonCartIconAndroidIos = By.XPath("(//div[@class='cart-block__icon '])[2]");

        ///<summary>Контейнер отдельного продукта</summary>
        private By divProductBlock = By.ClassName("product");

        ///<summary>Название товара</summary>
        private By linkProductTitle = By.CssSelector("h2.product__title a");

        ///<summary>Цена отдельного продукта</summary>        
        private By textProductPrice = By.XPath("//div[@class='product__bottom_block__price']/span");

        ///<summary>Кнопка Войти</summary>
        private By buttonLogIn = By.XPath("//div[@class='header-absolute-container']//div[@class='profile-badge-block__login']");

        ///<summary>Иконка-кнопка профиля</summary>
        private By buttonUserProfile = By.XPath("//div[@class='header-absolute-container']//div[@class='profile-badge-block']");

        ///<summary>Иконка избранных товаров</summary>
        private By buttonFavouriteProdukts = By.XPath("//a[contains(@href,'favourite')]");

        ///<summary>Категория товара</summary>
        private By linkCategory = By.CssSelector("div.sticky-header__categories__item a");

        ///<summary>Счетчик товара на кнопке ХОЧУ</summary>
        private By buttonWantIconCounter = By.CssSelector("div.cart-button__expanded__count");

        ///<summary>Кнопка МИНУС на кнопке ХОЧУ</summary>
        private By buttonWantMinus = By.CssSelector("div.cart-button__expanded__minus");

        ///<summary>Кнопка ПЛЮС на кнопке ХОЧУ</summary>
        private By buttonWantPlus = By.CssSelector("div.cart-button__expanded__plus");

        ///<summary>Кнопка отмены подписки</summary>
        private By buttonCanсelSubscription = By.Id("p4s-confirm-block-button");

        ///<summary>Кнопка закрытия окна сообщения куки</summary>
        private By buttonCookiesWindowClose = By.CssSelector("button.cookies__close");

    #endregion

    #region Private variables, constructor

        private IWebDriver driver;

        ///<summary>Конструктор</summary>
        public POMMainPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

    #endregion

    #region Methods        


        ///<summary>Клик на кнопку Войти</summary>
        public void ButtonLogInClick()
        {   
            Click(buttonLogIn);
        }

        ///<summary>Клик на ссылку Акции</summary>
        public void LinkActionsClick()
        {
            Click(linkActions);
        }

         ///<summary>Клик на ссылку Доставка</summary>
        public void LinkDeliveryClick()
        {
            Click(linkDelivery);
        }

         ///<summary>Клик на ссылку О компании</summary>
        public void LinkAboutCompanyClick()
        {
            Click(linkAboutCompany);
        }

          ///<summary>Клик на иконку Профиля</summary>
        public void ButtonUserProfileClick()
        {
            Click(buttonUserProfile);
        }

         ///<summary>Клик на ссылку Вакансии</summary>
        public void LinkVacancyClick()
        {
            Click(linkVacancy);
        }

         ///<summary>Клик на ссылку Франшиза</summary>
        public void LinkFranchiseClick(string franchise)
        {
            ClickByText(franchise);
        }

           ///<summary>Клик на кнопку Поиск</summary>
        public void ButtonSearchClick()
        {
            Click(buttonSearch);
        }    

        ///<summary>Проверка видимости кнопки Войти</summary>
        public bool ButtonLogInDisplayed()
        {
            return Displayed(buttonLogIn); 
        }
        
        ///<summary>Проверка видимости кнопки избранные товары</summary>
        public bool ButtonFavouriteProduktsDisplayed()
        {
            return Displayed(buttonFavouriteProdukts); 
        }

        ///<summary>Клик на ссылку избранные товары</summary>
        public void LinkFavoriteClick()
        {
            Click(linkFavorite);
        }

        ///<summary>Клик на кнопку МИНУС на кнопке ХОЧУ</summary>
        public void ButtonWantMinusClick()
        {
            Click(buttonWantMinus);
        }

        ///<summary>Клик на кнопку ПЛЮС на кнопке ХОЧУ</summary>
        public void ButtonWantPlusClick()
        {
            Click(buttonWantPlus);
        }

        ///<summary>Возвращает количество первого товара на кнопке ХОЧУ в числовом виде. Если счетчика нет - возвращает 0</summary>
        public int ButtonWantIconCounterGetInt()
        {            
            WaitPageLoadJS();
            var counters = driver.FindElements(buttonWantIconCounter);
            if(counters.Count == 0)
            {
                return 0;
            }
            else if (Displayed(buttonWantIconCounter))
            {
                return ConvertToInt(GetText(buttonWantIconCounter));
            }
            else return 0;            
        }

        ///<summary>Возвращает количество товара на иконке корзины</summary>
        public int ButtonCartIconCounterGetInt()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                return ConvertToInt(GetText(buttonCartIconCounterPC));
            }
            else
            {
                return ConvertToInt(GetText(buttonCartIconCounterAndroidIos));
            }            
        }

        ///<summary>Возвращает название первого товара</summary>
        public string LinkProductTitleGetText()
        {            
            return GetText(linkProductTitle);
        }
        
        ///<summary>Клик на название первого товара</summary>
        public void LinkProductTitleClick()
        {
            Click(linkProductTitle);
        }

        ///<summary>Нажать на кнопку добавления в корзину (Хочу) </summary>
        // Производится проверка, чтобы кнопка не была  disabled
        public void ButtonAddSKUToCardClick()
        {      
            var collection = GetListWebElements(buttonWant);
            foreach (var item in collection)
            {
                WaitPageLoadJS();
                string name = item.GetAttribute("class").ToString();
                if (!name.Contains("cart-button__disabled"))
                {                    
                    Click(item);
                    break;
                }                
            }            
        }

        ///<summary>Клик на иконку корзины</summary>
        public void ButtonCartIconClick()
        {            
            WaitPageLoadJS();
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                Click(buttonCartIconPC);
            }
            else
            {
                Click(buttonCartIconAndroidIos);
            }    
        }

        public List<SSKU> GetSKUListOnPage()
        {
            List<SSKU> list = new List<SSKU>();
            var i = 0;
            var allProducts = driver.FindElements(divProductBlock);

            foreach (var item in allProducts)
            {
                SSKU product = new SSKU();
                var nested = item.FindElements(By.TagName("h2"));                
                list.Add(product);
                i++;
            }
            return list;
        }

        ///<summary>Клик на ссылку первой категории </summary>
        public void LinkFirstCategoryClick()
        {
            Click(linkCategory);
        }        

        ///<summary>Ожидание кнопки отмены подписки, потом клик на неё </summary>
        public void ButtonCanсelSubscriptionClick()
        {
            WaitForElementToBeClickable(buttonCanсelSubscription);
            Click(buttonCanсelSubscription);                        
        }

        ///<summary>Клик кнопку закрытия окна куки </summary>
        public void ButtonCookiesWindowCloseClick()
        {
            Click(buttonCookiesWindowClose);                       
        }

    #endregion


    }
}
