using OpenQA.Selenium;
using System.IO;

namespace ComponentLibrary.HelperFunctions
{
    public class TakeScreenshot
    {
        public static void SaveAs(IWebDriver driver, string filePath, string fileName)
        {
            var ssdriver = driver as ITakesScreenshot;
            var screenshot = ssdriver.GetScreenshot();
            var location = filePath + "\\" + fileName + ".Png";

            if (File.Exists(location))
            { // To be rewritten properly -  functions needs to increment filenamd
                var locationIncremented = filePath + "\\" + fileName + "2" + ".Png";
                screenshot.SaveAsFile(locationIncremented, ScreenshotImageFormat.Png);
            }
            else
            {
                screenshot.SaveAsFile(location, ScreenshotImageFormat.Png);
            }
        }
    }
}
