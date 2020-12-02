using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementCommandManager : MonoBehaviour
{
   private static MovementCommandManager _instance;

   public static MovementCommandManager Instance
   {
      get
      {
         if(_instance==null)
            Debug.LogError("Null command manager");
         return _instance;
      }
   }

   private List<ICommand> _commandBuffer =new List<ICommand>();

   private void Awake()
   {
      _instance = this;
   }

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
      Debug.Log("Rewinding...");
      foreach (var command in Enumerable.Reverse(_commandBuffer))
      {
         command.Undue();
         yield return new WaitForEndOfFrame();//smooth movement
      }
      Debug.Log("Finished...");
   }
   public void Play()
   {
      StartCoroutine(PlayRoutine());
   }

   IEnumerator PlayRoutine()
   {
      Debug.Log("Playing...");
      foreach (var command in _commandBuffer)
      {
         command.Ececute();
         yield return new WaitForEndOfFrame();//smooth movement
      }
      Debug.Log("Finished...");
   }
}
