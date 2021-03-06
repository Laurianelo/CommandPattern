﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;

    public static CommandManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The CommandManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }



    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

       
    IEnumerator RewindRoutine()
    {
        Debug.Log("Rewinding..");
        foreach(var command in Enumerable.Reverse(_commandBuffer) )
        {
            command.Undo();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finished..");
    }


    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }


    IEnumerator PlayRoutine()
    {
        Debug.Log(" play..");
        foreach (var command in _commandBuffer)
        {
            command.Execute();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finished play..");
    }

}
