using System;
using OpenQA.Selenium;
using ComponentLibrary.Actions;

namespace ComponentLibrary.Tasks.Orders
{
    public class DMIOrderIdFilterBy
    {
        public static void Equals(IWebDriver driver, string value)
        {
            Enter.Into(driver, By.Id("dx-col-55"), "THIS IS A TEST");
        }
    }
}
