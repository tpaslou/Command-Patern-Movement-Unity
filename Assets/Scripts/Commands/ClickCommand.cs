using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCommand : ICommand
{
    private GameObject _cube;
    private Color _color,_previousColor;
    public ClickCommand(GameObject cube,Color color)
    {
        this._color = color;
        this._cube = cube;
    }
    public void Ececute()
    {
        _previousColor = _cube.GetComponent<MeshRenderer>().material.color;
        _cube.GetComponent<MeshRenderer>().material.color =
            _color;
    }

    public void Undue()
    {
        _cube.GetComponent<MeshRenderer>().material.color=_previousColor;
    }
}
