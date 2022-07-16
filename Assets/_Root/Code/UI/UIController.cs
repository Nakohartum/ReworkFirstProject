using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Code.Interfaces;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private IHealth _health;
    private float _horizontalSlider;

    public void Init(IHealth health)
    {
        _health = health;
    }
    
    private void OnGUI()
    {
        GUI.HorizontalScrollbar(new Rect(5f, Screen.height - 20f, 100f, 10f), _health.CurrentHealth,
            0f, 0, _health.MaxHealth);
    }

}
