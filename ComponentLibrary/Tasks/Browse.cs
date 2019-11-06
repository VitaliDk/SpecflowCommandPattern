using System;
using System.Collections.Generic;
using System.Text;
using ComponentLibrary.Actors;
using OpenQA.Selenium;

namespace ComponentLibrary.Tasks
{
    public class Browse : ITask
    {
        IWebDriver driver;
        public Browse()
        {

        }

        public void PerformAs(Actor actor)
        {
            actor.driver = this.driver;
        }
        
        public static Browse TheWeb(IWebDriver driver)
        {
            Browse browse = new Browse();
            browse.driver = driver;
            return browse;
        }
    }
}
