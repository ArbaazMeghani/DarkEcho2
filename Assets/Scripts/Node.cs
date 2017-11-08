using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;
    private int gridSizeX;
    private int gridSizeY;

    public Node(int gridSizeX, int gridSizeY)
    {
        this.gridSizeX = gridSizeX;
        this.gridSizeY = gridSizeY;
    }

    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
    } // end of constructor

}
