using System;
using System.Collections.Generic;
using System.Text;
using ComponentLibrary.Actors;

namespace ComponentLibrary.Tasks
{
    public class Print :ITask
    {
        public string text;
        public Print(string text)
        {
            this.text = text;
        }
        // executes the task command using the current task object's data
        public void PerformAs(Actor actor) 
        {
            actor.text = this.text;
            Console.WriteLine(actor.text);
        }

        // Stores the necessary data for the tasks to be executed into a new task object
        public static Print ToTheScreen(string text)
        {
            Print print = new Print(text);

            return print;
        }
    }
}
