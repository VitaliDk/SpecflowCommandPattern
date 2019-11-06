using System;
using System.Globalization;
using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using OpenQA.Selenium;
using ComponentLibrary.HelperFunctions;


namespace ComponentLibrary.Tasks.Orders
{
    public static class FilterOrdersBySubmittedDate
    {
        public static void FromDate(IWebDriver driver, int day, string month, string year)
        {
            var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
            var currentYear = DateTime.Today.Year.ToString();

            Click.Button(driver, OrdersPage.FromDateOpenCalendarSelector());
            Click.Element(driver, OrdersPage.FromDateMonthYearSelector($"{currentMonth} {currentYear}"));
            Click.Element(driver, OrdersPage.FromDateMonthYearSelector($"{currentYear}"));

            SelectYearFromDate(driver, year);
            SelectMonthFromDate(driver, month);
            SelectDayFromDate(driver, day);
        }

        public static void ToDate(IWebDriver driver, int day, string month, string year)
        {
            var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
            var currentYear = DateTime.Today.Year.ToString();

            Click.Button(driver, OrdersPage.ToDateOpenCalendarSelector());
            Click.Element(driver, OrdersPage.ToDateMonthYearSelector($"{currentMonth} {currentYear}"));
            Click.Element(driver, OrdersPage.ToDateMonthYearSelector($"{currentYear}"));

            SelectYearToDate(driver, year);
            SelectMonthToDate(driver, month);
            SelectDayToDate(driver, day);
        }

        static void SelectYearToDate(IWebDriver driver, string year)
        {
            Click.Element(driver, OrdersPage.ToDateMonthYearSelector(year)); // eg 2010
        }

        static void SelectMonthToDate(IWebDriver driver, string month)
        {
            Click.Element(driver, OrdersPage.ToDateMonthYearSelector(month));// eg Nov
        }

        static void SelectDayToDate(IWebDriver driver, int day)
        {
            Click.Element(driver, OrdersPage.ToDateDaySelector($"{day}")); // eg 9
        }

        static void SelectYearFromDate(IWebDriver driver, string year)
        {
            Click.Element(driver, OrdersPage.FromDateMonthYearSelector(year)); // eg 2010
        }

        static void SelectMonthFromDate(IWebDriver driver, string month)
        {
            Click.Element(driver, OrdersPage.FromDateMonthYearSelector(month)); // eg Nov 
        }

        static void SelectDayFromDate(IWebDriver driver, int day)
        {
            Click.Element(driver, OrdersPage.FromDateDaySelector($"{day}")); // eg 9
        }
    }
}
