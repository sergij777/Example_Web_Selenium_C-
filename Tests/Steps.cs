using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace SushimasterTests
{
    public class Steps
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public Steps(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // First entrance, confirm city
        public void CityConfirm()
        {
            _driver.FindElement(By.ClassName("city-accept-block__actions__accept")).Click();
        }

        // Add product to cart from main page
        public void SkuAddFromMainPage()
        {
            var buttonToCard = By.CssSelector("div.cart-button__collapsed__cart_icon");
            _wait.Until(d => _driver.FindElement(buttonToCard).Displayed);
            _driver.FindElement(By.CssSelector("div.cart-button__collapsed__cart_icon")).Click();
        }

        // Click Cart
        public void BasketEnter()
        {
            _wait.Until(d => _driver.FindElement(By.ClassName("cart-block__icon__count")).Displayed);
            _driver.FindElement(By.ClassName("cart-block__icon")).Click();
        }        

        // First entrance, shipping and confirm address on first entrance to cart
        public void BasketFirstEnterSelectDelivery()
        {            
            // Click on the Delivery button
            _wait.Until(d => _driver.FindElement(By.XPath("//div/label[contains(@class, 'sc-')]")).Displayed);            
            _driver.FindElement(By.XPath("//div/label[contains(@class, 'sc-')]")).Click();            

            // Click on the address field
            _wait.Until(d => _driver.FindElement(By.CssSelector("div.input-group input")).Displayed);
            _driver.FindElement(By.CssSelector("div.input-group input")).Click();

            // Entering an address
            _driver.FindElement(By.CssSelector("div.input-group input")).SendKeys("Газовиков, 21");

            // select the address from the drop-down list and press Enter               
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _wait.Until(d => _driver.FindElement(By.ClassName("address-dropdown__item__region")).Displayed);            
            _driver.FindElement(By.ClassName("address-dropdown__item__region")).Click();    
            _driver.FindElement(By.CssSelector("div.input-group input")).SendKeys(Keys.Enter);
            
            // Click on the button Delivery
            var button = _driver.FindElements(By.CssSelector("label[for='delivery-variant']"))[1];
            // Move to center of button            
            Actions actionProvider = new Actions(_driver);
            actionProvider.MoveByOffset(100, 20).Build().Perform();
            button.Click();
        }

        // Click on the button Order
        public void CheckoutButton()
        {
            _wait.Until(d => _driver.FindElement(By.ClassName("order-inner-container__submit-button")).Displayed);
            _driver.FindElement(By.ClassName("order-inner-container__submit-button")).Click();
        }

        // Click on Method Delivery
        public void DeliveryTypeButtonDelivery()
        {
            _driver.FindElement(By.Id("radio-button-DELIVERY")).Click();
        }

        // Click on Method Pickup
        public void DeliveryTypeButtonPickup()
        {
            _driver.FindElement(By.Id("radio-button-RESTAURANT")).Click();
        }

        // Enter a name at checkout
        public void UserNameEnter()
        {
            _wait.Until(d => _driver.FindElement(By.Name("name")).Displayed);
            _driver.FindElement(By.Name("name")).SendKeys("Тестовый пользователь");
        }
        // Enter phone number at checkout
        public void UserPhoneEnter()
        {
            _driver.FindElement(By.Name("phone")).SendKeys("9999999999");
        }
        // Enter a comment
        public void CommentEnter()
        {
            _driver.FindElement(By.CssSelector("div.input-group textarea")).SendKeys("Тест, не оформлять");
        }

        // Select a payment method Cash
        public void PaymentMethodeDeliveryCash()
        {
            _driver.FindElements(By.XPath("//div[contains(@class, 'switch-buttons__item')]"))[0].Click();
        }

        // Select a payment method  Card to the courier
        public void PaymentMethodeDeliveryBoy()
        {
            _driver.FindElements(By.XPath("//div[contains(@class, 'switch-buttons__item')]"))[1].Click();
        }

        // Select a payment method Online
        public void PaymentMethodeDeliveryOnline()
        {
            _driver.FindElements(By.XPath("//div[contains(@class, 'switch-buttons__item')]"))[2].Click();
        }

        // Enter a Change
        public void PaymentMethodeDeliveryChangeEnter()
        {
            _driver.FindElement(By.ClassName("order-inner-container_input")).SendKeys("1000");
        }

        // Checkbox User agreement
        public void UserAgreementCheckBox()
        {
            _driver.FindElement(By.XPath("//div/label[contains(@class, 'rules-label')]")).Click();
        }

        // Click Pay
        public void ButtonOrder()
        {
            _driver.FindElement(By.ClassName("order-inner-container__submit-button")).Click();
        }

        public void ScrollBottom()
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor) _driver); 
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            
        }
        public void ScrollTop()
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor) _driver); 
            js.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
            
        }
    }
}
