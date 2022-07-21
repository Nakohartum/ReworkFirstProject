﻿using System;
using _Root.Code.Interfaces;
using UnityEngine;

namespace _Root.Code.InputControls
{
    public class JumpInputController : IInputController
    {
        public event Action<float> OnAxisChange = f => { };

        public void GetInput()
        {
            OnAxisChange.Invoke(Input.GetAxis("Jump"));
        }
    }
}