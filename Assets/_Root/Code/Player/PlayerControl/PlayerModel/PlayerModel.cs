using System.Collections;
using System.Collections.Generic;
using _Root.Code.Interfaces;
using UnityEngine;

public class PlayerModel
{ 
    public IHealth Health { get; private set; }
    public float MovingSpeed { get; private set; }
    public float JumpPower  { get; private set; }

    public PlayerModel(IHealth health, float movingSpeed, float jumpPower)
    {
        Health = health;
        MovingSpeed = movingSpeed;
        JumpPower = jumpPower;
    }
}
