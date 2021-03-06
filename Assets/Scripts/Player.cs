﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ICommand moveUp, moveRight, moveLeft, moveDown;


    [SerializeField]
    private float _speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            //move up command
            moveUp = new MoveUpCommand(this.transform, _speed);
            moveUp.Execute();
            CommandManager.Instance.AddCommand(moveUp);
            
        }
        else if(Input.GetKey(KeyCode.S))
        {
            //move down
            moveDown = new MoveDownCommand(this.transform, _speed);
            moveDown.Execute();
            CommandManager.Instance.AddCommand(moveDown);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            //move left
            moveLeft = new MoveLeftCommand(this.transform, _speed);
            moveLeft.Execute();

            CommandManager.Instance.AddCommand(moveLeft);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //move right
            moveRight = new MoveRightCommand(this.transform, _speed);
            moveRight.Execute();

            CommandManager.Instance.AddCommand(moveRight);

        }


    }
}
