using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SushimasterTests
{    
    [TestClass]
    public class C22282_CheckingAdressAndPriceAndSkuInBack : ITest
    {        
        [TestCategory("Smoke")]
        [Description("Сравнение контактов, адреса, комментария, цен с 1С")]
        [DynamicDataCheckoutPageDefaultValueFixed]
        [DataTestMethod]
        public void CheckingContactsAndAdressAndPriceInBack(string name, string codeCountry, string codeOperator, string phone, string street, string house, string apartment, string intercom, string entrance, string floor, string comment)
        {
            //Arrange
            OpenSite();
            Precondition.FirstVisitCheckoutPageChoosingDeliveryMethodDelivery();

            var pageCheckout = new POMCheckoutPage(Driver);
            var pageSuccessOrder = new POMSuccessOrderPage(Driver);
            var phoneEnter = new SPhone(codeCountry, codeOperator, phone);

            pageCheckout.InputNameInputText(name);
            pageCheckout.InputPhoneInputText(phoneEnter.PhoneSiteEnter);
            pageCheckout.InputStreetInputTextClick(street);
            pageCheckout.InputHouseInputTextClick(house); 
            pageCheckout.InputApartmentInputText(apartment);
            pageCheckout.InputIntercomInputText(intercom);
            pageCheckout.InputEntranceInputText(entrance);
            pageCheckout.InputFloorInputText(floor);
            pageCheckout.InputCommentInputText(comment);   

            pageCheckout.ButtonGoToPaymentPageClick(); 
            pageCheckout.ButtonChoosingPaymentTypeCashClick();
            pageCheckout.InputShortChangeInputText("10000");  

            var expectedPhone = phoneEnter.Phone1C;
            var expectedDeliveryType = "DELIVERY";
            var expectedProductsPrice = pageCheckout.TextPriceAllSkuGetDouble();
            var expectedDeliveryPrice = pageCheckout.TextPriceDeliveryGetDouble();
            var expectedTotalPrice = pageCheckout.TextPriceTotalGetDouble();              
            
            SuccessMessage = $"Данные контактов, адреса, цены оплаты с сайта(страница оформления), совпадают с данными в 1С.";
            ErrorSide = FRONT;

            // Act               
            pageCheckout.ButtonSubmitOrderClick();

            // Actual             
            var expectedOrder = pageSuccessOrder.TextOrderNumberGetInt();

            var intSdk = new SmIntegrationSdk();
            COrder order = intSdk.GetOrderByNumber(expectedOrder.ToString());
            
            var actualDeliveryType = order.deliveryType;
            var actualProductsPrice = order.productsPrice;
            var actualDeliveryPrice = order.deliveryPrice;
            var actualTotalPrice = order.totalPrice;
            var actualComment = order.comment;
            
            var actualName = order.client.name;
            var actualPhone = order.client.phone;
            
            var actualStreet = order.address.street;
            var actualHouse = order.address.house;
            var actualApartment = order.address.apartment;
            var actualIntercom = order.address.intercom;
            var actualEntrance = order.address.entrance;
            var actualFloor = order.address.floor;

            bool dataIsGood = true;
            ErrorMessage= $"По номеру заказа на сайте: -{expectedOrder}- :";
            
            
            //Assert    
            if(name != actualName)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении имени {name} в 1С передается {actualName}.";
            }

            if(expectedPhone != actualPhone)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении телефона {expectedPhone} в 1С передается {actualPhone}.";
            }

            if(expectedDeliveryType != actualDeliveryType)
            {
                dataIsGood = false;
                ErrorMessage+= $" При типа доставки ДОСТАВКА в 1С передается {actualDeliveryType}.";
            }
            
            if(street != actualStreet)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении улицы {street}, в 1С передается {actualStreet}.";
            }  

            if(house != actualHouse)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении дома {house} , в 1С передается {actualHouse}.";
            } 

            if(apartment != actualApartment)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении квартиры {apartment} , в 1С передается {actualApartment}.";
            } 

            if(intercom != actualIntercom)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении домофона {intercom} , в 1С передается {actualIntercom}.";
            }  

            if(entrance != actualEntrance)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении подъезда {entrance} , в 1С передается {actualEntrance}.";
            }  

            if(floor != actualFloor)
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении этажа {floor} , в 1С передается {actualFloor}.";
            }  
            
            if(!actualComment.Contains(comment))
            {
                dataIsGood = false;
                ErrorMessage+= $" При введении комментария {comment} , в 1С передается {actualComment}.";
            } 

            if(expectedProductsPrice != actualProductsPrice)
            {
                dataIsGood = false;
                ErrorMessage+= $" На сайте(страница оформления) общая цена продуктов {expectedProductsPrice} , в 1С передается {actualProductsPrice}.";
            } 

            if(expectedDeliveryPrice != actualDeliveryPrice)
            {
                dataIsGood = false;
                ErrorMessage+= $" На сайте(страница оформления) цена доставки {expectedDeliveryPrice} , в 1С передается {actualDeliveryPrice}.";
            } 

            if(expectedTotalPrice != actualTotalPrice)
            {
                dataIsGood = false;
                ErrorMessage+= $" На сайте(страница оформления) общая цена заказа {expectedTotalPrice} , в 1С передается {actualTotalPrice}.";
            } 

            Assert.IsTrue(dataIsGood, ErrorMessage);
            
        }

        [TestCategory("Smoke")]
        [Description("Сравнение списка товаров на сайте с 1С")]
        [DynamicDataCheckoutPageDefaultValueFixed]
        [DataTestMethod]
        public void CheckingListSkuInBack(string name, string codeCountry, string codeOperator, string phone, string street, string house, string apartment, string intercom, string entrance, string floor, string comment)
        {
            //Arrange
            OpenSite();
            Precondition.FirstCartVisitSkuAddToCart();
            
            var pageCart = new POMCartPage(Driver);
            // pageCart.ButtonWantDopSkuClick();
            pageCart.ButtonWantPlusClick();
            pageCart.ButtonWantPlusClick();            

            // Корзина со списком товаров
            SCart sCart = new SCart();
            sCart = pageCart.GetObjectCart();             
            var expectedSkuCount = sCart.skuList.Count;            

            pageCart.ButtonCheckoutOrderClick();
            var pageCheckout = new POMCheckoutPage(Driver);
            var pickup = new POMCheckoutPageDeliveryTypeRestaurantSection(Driver);
            pageCheckout.ButtonChoosingDeliveryMethodClick();
            
            var pageSuccessOrder = new POMSuccessOrderPage(Driver);
            var phoneEnter = new SPhone(codeCountry, codeOperator, phone);

            pageCheckout.InputNameInputText(name);
            pageCheckout.InputPhoneInputText(phoneEnter.PhoneSiteEnter);
            pageCheckout.InputStreetInputTextClick(street);
            pageCheckout.InputHouseInputTextClick(house); 
            pageCheckout.InputCommentInputText(comment);  

            pageCheckout.ButtonGoToPaymentPageClick();                        
            pageCheckout.ButtonChoosingPaymentTypeCashClick();
            pageCheckout.InputShortChangeInputText("10000");  
            
            SuccessMessage = $"Данные контактов, адреса, цены оплаты с сайта(страница оформления), совпадают с данными в 1С.";
            ErrorSide = FRONT;

            // Act               
            pageCheckout.ButtonSubmitOrderClick();

            // Actual             
            var expectedOrder = pageSuccessOrder.TextOrderNumberGetInt();            

            var intSdk = new SmIntegrationSdk();
            COrder order = intSdk.GetOrderByNumber(expectedOrder.ToString());
            var actualListSku = order.products;
            var actualSkuCount = actualListSku.Count;

            bool skuListIsEqual = true;
            ErrorMessage= $"По номеру заказа на сайте: -{expectedOrder}- :";

            if(expectedSkuCount != actualSkuCount)
            {
                skuListIsEqual = false;
                ErrorMessage+= $" На сайте(в корзине) количество товаров {expectedSkuCount} , в 1С передается количество {actualSkuCount}.";
            } 

            // Сравнение каждого товара с сайта с каждым товаром в 1С и поиск одинаковых, сравнение параметров в них.
            foreach (var itemSite in sCart.skuList)
            {
                bool skuIsNotFoundIn1C = true;
                foreach (var item1C in actualListSku)
                {
                    if(itemSite.Name == item1C.productName)
                    {
                        skuIsNotFoundIn1C = false;
                        if(itemSite.Count != item1C.count)
                        {
                            skuListIsEqual = false;
                            ErrorMessage+= $" Для товара {itemSite.Name} количество товара на сайте {itemSite.Count} , в 1С передается количество {item1C.count}.";   
                        }

                        if(itemSite.Price != item1C.price)
                        {
                            skuListIsEqual = false;
                            ErrorMessage+= $" Для товара {itemSite.Name} цена товара на сайте {itemSite.Price} , в 1С передается цена {item1C.price}.";    
                        }
                        break;
                    }                    
                }
                
                if(skuIsNotFoundIn1C)
                {
                    skuListIsEqual = false;
                    ErrorMessage+= $" Товар на сайте {itemSite.Name} не передался в 1С."; 
                }                
            }
            
            //Assert    
            Assert.IsTrue(skuListIsEqual, ErrorMessage);
            
        }



        [ClassInitialize] 
        public static void ClassInit(TestContext testContext)
        {
            CaseId = "22282";
            TestClassInit(testContext);
        }
    }
}
