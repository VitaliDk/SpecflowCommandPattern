using System;
using OpenQA.Selenium;
using ComponentLibrary.Tasks;

namespace ComponentLibrary.Actors
{
    public class Actor
    {
        public IWebDriver driver;
        public string text;
        
        public Actor IsAbleTo(params ITask[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i].PerformAs(this);
            }

            return this;
        }
    }
}
