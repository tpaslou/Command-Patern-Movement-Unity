using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ICommand moveUp, moveDown, moveLeft, moveRight;

    [SerializeField] private float _speed=2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //move Command
            moveUp=new MoveUpCommand(this.transform,_speed);
            moveUp.Ececute();
            MovementCommandManager.Instance.AddCommand(moveUp);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //down
            moveDown=new MoveDownCommand(this.transform,_speed);
            moveDown.Ececute();
            MovementCommandManager.Instance.AddCommand(moveDown);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //left
            moveLeft=new MoveLeftCommand(this.transform,_speed);
            moveLeft.Ececute();
            MovementCommandManager.Instance.AddCommand(moveLeft);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //right
            moveRight=new MoveRightCommand(this.transform,_speed);
            moveRight.Ececute();
            MovementCommandManager.Instance.AddCommand(moveRight);
        }
    }
}
