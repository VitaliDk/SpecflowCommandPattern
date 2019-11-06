using System;
using OpenQA.Selenium;
using ComponentLibrary.HelperFunctions;
using ComponentLibrary.Screens;
using ComponentLibrary.Actions;

namespace ComponentLibrary.Tasks
{
    public class DMICalendar
    {
        public static void NavigateToNextMonth(IWebDriver driver)
        {
            Click.Element(driver, DMICalendarScreen.ToggleRight);
        }

        public static void NavigateToPreviousMonth(IWebDriver driver)
        {
            Click.Element(driver, DMICalendarScreen.ToggleLeft);
        }
    }
}
