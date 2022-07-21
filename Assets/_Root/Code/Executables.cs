using System;
using System.Collections.Generic;
using _Root.Code.Interfaces;

namespace _Root.Code
{
    public class Executables : IExecutable
    {
        private List<IExecutable> _executables;

        public Executables()
        {
            _executables = new List<IExecutable>();
        }

       

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executables.Count; i++)
            {
                _executables[i].Execute(deltaTime);
            }
        }

        public void AddToExecutables(IExecutable executable)
        {
            _executables.Add(executable);
        }

        public void RemoveFromExecutables(IExecutable executable)
        {
            _executables.Remove(executable);
        }
    }
}