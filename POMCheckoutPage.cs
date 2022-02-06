using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SushimasterTests
{
    
    /// <summary>
    /// Страница checkout
    /// </summary>
    public class POMCheckoutPage : IPOM
    {
        #region Selectors
        
        ///<summary>Вкладка Самовывоз</summary>
        private By buttonChossingPickupMethod = By.XPath("(//div[@class='delivery-type-switch__item__text'])[2]");

        ///<summary>Вкладка Доставка  курьером</summary>
        private By buttonChossingDeliveryMethod = By.XPath("(//div[@class='delivery-type-switch__item__text'])[1]");

        ///<summary>Имя пользователя</summary>
        private By inputName = By.CssSelector("input[name='name']");

        ///<summary>Телефон пользователя</summary>
        private By inputPhone = By.CssSelector("input[name='phone']");

        ///<summary>Улица</summary>
        private By inputStreet = By.CssSelector("input[name='street']");

        ///<summary>Дом</summary>
        private By inputHouse = By.CssSelector("input[name='house']");

        ///<summary>Квартира</summary>
        private By inputApartment = By.CssSelector("input[name='address.extInfo.apartment']");

        ///<summary>Домофон</summary>
        private By inputIntercom = By.CssSelector("input[name='address.extInfo.intercom']");

        ///<summary>Подъезд</summary>
        private By inputEntrance = By.CssSelector("input[name='address.extInfo.entrance']");

        ///<summary>Этаж</summary>
        private By inputFloor = By.CssSelector("input[name='address.extInfo.floor']");

        ///<summary>Позиция улицы или дома в выпадающем списке</summary>
        private By inputStreetAccept = By.CssSelector("div.address-dropdown__item");

        ///<summary>Кнопка возврата из оформления заказа в  корзину</summary>
        private By buttonBackToCart = By.ClassName("order-scene__head__button");

        ///<summary>Поле для ввода комментария</summary>
        private By inputComment = By.CssSelector("div.input-group textarea");

        ///<summary>Кнопка перехода (Дальше) на страницу выбора способа оплаты в адаптивной версии</summary>
        private By buttonGoToPaymentPage = By.ClassName("primary-button");

        ///<summary>Кнопка выбора способа оплаты "Картой онлайн" для РС (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCartOnlinePC = By.XPath("//div[contains(@class, 'switch-buttons__item')][1]");

        ///<summary>Кнопка выбора способа оплаты "Картой онлайн" для адаптивов (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCartOnlineAndroidIos = By.XPath("//div[contains(@class, 'switch-radio-buttons__item')][1]");

        ///<summary>Кнопка выбора способа оплаты "Наличными" для РС (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCashPC = By.XPath("//div[contains(@class, 'switch-buttons__item')][2]");

        ///<summary>Кнопка выбора способа оплаты "Наличными" для адаптивов (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCashAndroidIos = By.XPath("//div[contains(@class, 'switch-radio-buttons__item')][2]");

        ///<summary>Поле Input выбранного способа оплаты для адаптивов (для способа Доставка)</summary>
        private By inputRadiobuttonPaymentType = By.TagName("input");

        ///<summary>Кнопка выбора способа оплаты "Наличными" для способа Самовывоз</summary>
        private By buttonChoosingPaymentTypeCashPickup = By.XPath("//div[contains(@class, 'switch-buttons__item')][1]");

        ///<summary>Кнопка выбора способа оплаты "Картой при получении" для РС (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCartBoyPC = By.XPath("//div[contains(@class, 'switch-buttons__item')][3]");

        ///<summary>Кнопка выбора способа оплаты "Картой при получении" для адаптивов (для способа Доставка)</summary>
        private By buttonChoosingPaymentTypeCartBoyAndroidIos = By.XPath("//div[contains(@class, 'switch-radio-buttons__item')][3]");

        ///<summary>Поле "Сдача с"</summary>
        private By inputShortChange = By.CssSelector("input.order-inner-container_input");

        ///<summary>Цена товаров в корзине</summary>
        private By textPriceAllSku = By.XPath("//div[@class='order-inner-container__fields-holder'][1]/div[@class='order-inner-container__fields-holder__field'][2]");

        ///<summary>Цена доставки</summary>
        private By textPriceDelivery = By.XPath("//div[@class='order-inner-container__fields-holder'][2]/div[@class='order-inner-container__fields-holder__field'][2]");

        ///<summary>Цена скидки</summary>
        private By textPriceDiscount = By.XPath("//div[@class='order-inner-container__fields-holder'][3]/div[@class='order-inner-container__fields-holder__field'][2]");

        ///<summary>Общая цена заказа</summary>
        private By textPriceTotal = By.XPath("//div[@class='order-inner-container__fields-holder__field-bold'][2]");

        ///<summary>Кнопка оформления заказа</summary>
        private By buttonSubmitOrder = By.XPath("//div[@class='order-inner-container__submit-button ']");

        ///<summary>Поле выбора адреса ресторана</summary>
        private By inputRestaurantAddress = By.XPath("//input[@class='restaurant-selector']");

        ///<summary>Кнопка редактировать адрес ресторана</summary>
        private By buttonEditRestaurantAddress = By.XPath("//span[@class='edit-restaurant']");

        ///<summary>Чекбокс переключения времени с "Как можно скорее" на определённое</summary>        
        private By checkboxDefiniteTime = By.CssSelector(".order-scene__input-container.checkbox_container label");

        ///<summary>Поле даты доставки</summary>
        private By selectDateDelivery = By.XPath("//select[@class='date-picker'][1]");

        ///<summary>Поле времени доставки</summary>  
        private By selectTimeDelivery = By.XPath("//div[@class='input-group date-picker-group']//following::select[1]");


        #endregion

        #region Private variables, constructor
        private IWebDriver driver;

        ///<summary>Конструктор </summary>
        public POMCheckoutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Methods

        ///<summary>Переключения на вкладку Доставка курьером</summary>
        public void ButtonChoosingDeliveryMethodClick()
        {
            Click(buttonChossingDeliveryMethod);
        }

        ///<summary>Переключения на вкладку Самовывоз</summary>
        public void ButtonChoosingPickupMethodClick()
        {
            Click(buttonChossingPickupMethod);
        }

        ///<summary>Ввод имени в поле Имя</summary>
        public void InputNameInputText(string name)
        {
            var elem = driver.FindElement(inputName);
            InputText(inputName, name);
        }

        ///<summary>Ввод телефона в поле Телефон</summary>
        public void InputPhoneInputText(string phone)
        {
            InputText(inputPhone, phone);
        }

        ///<summary>Возвращает имя из поля ввода имени</summary>
        public string InpuNameGetText()
        {
            return GetAttributeText(inputName, "value");
        }

        ///<summary>Возвращает телефон из поля ввода телефона</summary>
        public string InputPhoneGetText()
        {
            return GetAttributeText(inputPhone, "value");
        }

        ///<summary>Ввод улицы в поле и выбор из выпадающего списка</summary>
        public void InputStreetInputTextClick(string street)
        {
            InputText(inputStreet, street);
            ScrollPageFixSize();
            Click(inputStreetAccept);
        }

        ///<summary>Ввод дома в поле и выбор из выпадающего списка</summary>
        public void InputHouseInputTextClick(string house)
        {
            InputText(inputHouse, house);
            ScrollPageFixSize();
            Click(inputStreetAccept);
        }

        ///<summary>Возвращает улицу из поля ввода улицы</summary>
        public string InputStreetGetText()
        {
            return GetAttributeText(inputStreet, "value");
        }

        ///<summary>Возвращает номер дома из поля ввода дома</summary>
        public string InputHouseGetText()
        {
            return GetAttributeText(inputHouse, "value");
        }

        ///<summary>Ввод квартиры в поле Квартира</summary>
        public void InputApartmentInputText(string apartment)
        {
            InputText(inputApartment, apartment);
        }

        ///<summary>Вохвращает номер квартиры из поля Квартира</summary>
        public string InputApartmentGetText(string apartment)
        {
            return GetAttributeText(inputApartment, "value");
        }

        ///<summary>Ввод домофона в поле Домофон</summary>
        public void InputIntercomInputText(string intercom)
        {
            InputText(inputIntercom, intercom);
        }

        ///<summary>Возвращает номер домофона из поля Домофон</summary>
        public string InputIntercomGetText(string intercom)
        {
            return GetAttributeText(inputIntercom, "value");
        }

        ///<summary>Ввод номера подъезда в поле Подъезд</summary>
        public void InputEntranceInputText(string entrance)
        {
            InputText(inputEntrance, entrance);
        }

        ///<summary>Возвращает номер подъезда из поля Подъезд</summary>
        public string InputEntranceGetText(string entrance)
        {
            return GetAttributeText(inputEntrance, "value");
        }

        ///<summary>Ввод номера этажа в поле Этаж</summary>
        public void InputFloorInputText(string floor)
        {
            InputText(inputFloor, floor);
        }

        ///<summary>Возвращает номер этажа из поля Этаж</summary>
        public string InputFloorGetText(string floor)
        {
            return GetAttributeText(inputFloor, "value");
        }

        ///<summary>Клик на поле даты доставки и клик на параметр даты
        /// По умолчанию выбирается первый доступный параметр
        ///</summary>
        public void SelectDateDeliverySelectPosition(int num = 1)
        {            
            if (Displayed(selectDateDelivery))
            {
                IWebElement selectBox = driver.FindElement(selectDateDelivery);
                SelectElement selectedValue = new SelectElement(selectBox);
                selectedValue.SelectByIndex(num);
            }
        }

        ///<summary>Возвращает дату из поля выбора даты</summary>
        public string SelectDateDeliveryGetText()
        {            
            if (Displayed(selectDateDelivery))
            {
                IWebElement selectBox = driver.FindElement(selectDateDelivery);
                SelectElement selectedValue = new SelectElement(selectBox);
                return selectedValue.SelectedOption.Text;
            }
            else return "";
        }

        ///<summary>Клик на поле времени доставки и клик на параметр времени
        /// По умолчанию выбирается первый доступный параметр
        ///</summary>
        public void SelectTimeDeliverySelectPosition(int num = 1)
        {            
            if (Displayed(selectTimeDelivery))
            {
                IWebElement selectBox = driver.FindElement(selectTimeDelivery);
                SelectElement selectedValue = new SelectElement(selectBox);
                selectedValue.SelectByIndex(num);
            }
        }

        ///<summary>Возвращает время из поля выбора времени</summary>
        public string SelectTimeDeliveryGetText()
        {            
            if (Displayed(selectTimeDelivery))
            {
                IWebElement selectBox = driver.FindElement(selectTimeDelivery);
                SelectElement selectedValue = new SelectElement(selectBox);
                return selectedValue.SelectedOption.Text;
            }
            else return "";
        }

        ///<summary>Клик на кнопку возврата из оформления заказа в  корзину</summary>
        public void ButtonBackToCartClick()
        {
            Click(buttonBackToCart);
        }

        ///<summary>Ввод комментария в поле Дополнительно</summary>
        public void InputCommentInputText(string comment)
        {
            InputText(inputComment, comment);
        }

        ///<summary>Возвращает комментарий из поля Дополнительно</summary>
        public string InputCommentGetText()
        {
            return GetAttributeText(inputComment, "value");
        }

        ///<summary>Клик на кнопку перехода (Дальше) на страницу выбора способа оплаты в адаптивной версии</summary>
        public void ButtonGoToPaymentPageClick()
        {
            WaitPageLoadJS();
            if (Config.Properties.TestPlanDeviceConfigName != "PC")
            {
                WaitForElementExists(buttonGoToPaymentPage);
                Click(buttonGoToPaymentPage);
            }
        }

        ///<summary>Клик на кнопку выбора способа оплаты "Картой онлайн"</summary>
        public void ButtonChoosingPaymentTypeCartOnlineClick()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                Click(buttonChoosingPaymentTypeCartOnlinePC);
            }
            else
            {
                Click(buttonChoosingPaymentTypeCartOnlineAndroidIos);
            }
        }

        ///<summary>Клик на кнопку выбора способа оплаты "Наличными" для способа Доставка</summary>
        public void ButtonChoosingPaymentTypeCashClick()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                Click(buttonChoosingPaymentTypeCashPC);
            }
            else
            {
                Click(buttonChoosingPaymentTypeCashAndroidIos);
            }
        }

        ///<summary>Клик на кнопку выбора способа оплаты "Наличными" для способа Самовывоз</summary>
        public void ButtonChoosingPaymentTypeCashPickupClick()
        {
            Click(buttonChoosingPaymentTypeCashPickup);
        }

        ///<summary>Клик на кнопку выбора способа оплаты "Картой курьеру" для способа Доставка</summary>
        public void ButtonChoosingPaymentTypeCartBoyClick()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                Click(buttonChoosingPaymentTypeCartBoyPC);
            }
            else
            {
                Click(buttonChoosingPaymentTypeCartBoyAndroidIos);
            }
        }

        ///<summary>Возвращает true, если выбран способ оплаты "Картой онлайн" для способа Доставка</summary>        
        public bool ButtonChoosingPaymentTypeCartOnlineGetBool()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                var className = GetAttributeText(buttonChoosingPaymentTypeCartOnlinePC, "class");
                return className.Contains("active");
            }
            else
            {
                if (driver.FindElement(buttonChoosingPaymentTypeCartOnlineAndroidIos).FindElement(inputRadiobuttonPaymentType).Selected)
                {
                    return true;
                }
                else return false;
            }
        }

        ///<summary>Возвращает true, если выбран способ оплаты "Наличными" для способа Доставка</summary>
        public bool ButtonChoosingPaymentTypeCashGetBool()
        {
            Pause();
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                var className = GetAttributeText(buttonChoosingPaymentTypeCashPC, "class");
                return className.Contains("active");
            }
            else
            {
                if (driver.FindElement(buttonChoosingPaymentTypeCashAndroidIos).FindElement(inputRadiobuttonPaymentType).Selected)
                {
                    return true;
                }
                else return false;
            }
        }

        ///<summary>Возвращает true, если выбран способ оплаты "Наличными" для метода Самовывоз</summary>
        public bool ButtonChoosingPaymentTypeCashPickupGetBool()
        {
            Pause();
            var className = GetAttributeText(buttonChoosingPaymentTypeCashPickup, "class");
            return className.Contains("active");
        }

        ///<summary>Возвращает true, если выбран способ оплаты "Картой курьеру" для способа Доставка</summary>
        public bool ButtonChoosingPaymentTypeCartBoyGetBool()
        {            
            if (Config.Properties.TestPlanDeviceConfigName == "PC")
            {
                var className = GetAttributeText(buttonChoosingPaymentTypeCartBoyPC, "class");
                return className.Contains("active");
            }
            else
            {
                if (driver.FindElement(buttonChoosingPaymentTypeCartBoyAndroidIos).FindElement(inputRadiobuttonPaymentType).Selected)
                {
                    return true;
                }
                else return false;
            }            
        }

        ///<summary>Ввод сдачи в поле "Сдача с"</summary>
        public void InputShortChangeInputText(string change)
        {
            InputText(inputShortChange, change);
        }

        ///<summary>Выводит цену всех товаров в корзине без доставки </summary>
        public double TextPriceAllSkuGetDouble()
        {
            var priceString = GetText(textPriceAllSku);
            return ConvertToDouble(priceString);
        }

        ///<summary>Выводит цену  доставки </summary>
        public double TextPriceDeliveryGetDouble()
        {
            var priceString = GetText(textPriceDelivery);
            return ConvertToDouble(priceString);
        }

        ///<summary>Выводит цену скидки</summary>
        public double TextPriceDiscountGetDouble()
        {
            var priceString = GetText(textPriceDiscount);
            return ConvertToDouble(priceString);
        }

        ///<summary>Выводит общую цену заказа</summary>
        public double TextPriceTotalGetDouble()
        {
            var priceString = GetText(textPriceTotal);
            return ConvertToDouble(priceString);
        }

        ///<summary>Клик на кнопку оформления заказа</summary>
        public void ButtonSubmitOrderClick()
        {            
            Click(buttonSubmitOrder);
        }

        ///<summary>Проверка отображения кнопки Заказать</summary>
        public bool ButtonSubmitOrderDisplayed()
        {
            return Displayed(buttonSubmitOrder);
        }

        ///<summary>Клик на поле "Выбрать адрес ресторана"</summary>
        public void inputRestaurantAddressClick()
        {
            Click(inputRestaurantAddress);
        }

        ///<summary>Проверка отображения кнопки "Редактировать" адрес ресторана</summary>
        public bool ButtonEditRestaurantAddressDisplayed()
        {
            return Displayed(buttonEditRestaurantAddress);
        }

        ///<summary>Возвращает адрес выбранного ресторана  в поле "Выбрать адрес ресторана"</summary>
        public string InputRestaurantAddressGetText()
        {
            return GetAttributeText(inputRestaurantAddress, "value");
        }

        ///<summary>Установка чекбокса "К определённому времени"</summary>
        public void CheckboxTimeCheck()
        {
            var checkboxes = GetListWebElements(checkboxDefiniteTime);
            Click(checkboxes[1]);
        }

        ///<summary>Установка чекбокса "Как можно скорее"</summary>
        public void CheckboxAsapCheck()
        {
            var checkboxes = GetListWebElements(checkboxDefiniteTime);
            Click(checkboxes[0]);
        }

        #endregion

    }
}
