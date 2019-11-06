using System;
using System.Collections.Generic;
using System.Text;
using ComponentLibrary.Actors;

namespace ComponentLibrary.Tasks
{
    public interface ITask
    {
         void PerformAs(Actor actor);
    }
}
