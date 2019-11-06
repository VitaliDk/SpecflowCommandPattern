using System;
using System.Collections.Generic;
using System.Text;
using ComponentLibrary.Actors;

namespace ComponentLibrary.Tasks
{
    public class NavigateTo :ITask
    {
        public string url;
        public NavigateTo()
        {

        }

        public void PerformAs(Actor actor)
        {
            //actor.driver.Url = this.url;
            actor.driver.Navigate().GoToUrl(this.url);
        }

        public static NavigateTo Google()
        {
            NavigateTo navigateTo = new NavigateTo();
            navigateTo.url = "https://www.google.co.uk";
            return navigateTo;
        }
        public static NavigateTo DMI()
        {
            NavigateTo navigateTo = new NavigateTo();
            navigateTo.url = "https://dmiqa2.calastonetest.com/dmi";
            return navigateTo;
        }
    }
}
