using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    private List<ICommand> _commandBuffer;
    
    public static CommandManager Instance
    {
        get
        {
            if(_instance==null)
                Debug.LogError("Command Manager is NULL");
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        _commandBuffer=new List<ICommand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Methods

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

    public void PlayCommands()
    {
        
        StartCoroutine(PlayCommandRoutine());
        
    }

    public void PlayCommandsReverse()
    {
        
        StartCoroutine(rewindCommand());
      
    }
    
    private IEnumerator PlayCommandRoutine()
    {
        foreach (ICommand i in _commandBuffer)
        {
            i.Ececute();
            yield return new WaitForSeconds(1.0f);
        }

    }

    private IEnumerator rewindCommand()
    {
        for (int i=_commandBuffer.Count-1;i >=0;i--)
        {
            _commandBuffer[i].Undue();
            yield return new WaitForSeconds(1.0f);
        }


    }

    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color=Color.white;
        }
        
    }
    public void Reset()
    {
        _commandBuffer.Clear();
    }

    #endregion
}