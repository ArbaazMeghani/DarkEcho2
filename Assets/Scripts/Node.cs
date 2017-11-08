using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;
    private int gridSizeX;
    private int gridSizeY;

    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;

    public Node parent;

    public Node(int gridSizeX, int gridSizeY)
    {
        this.gridSizeX = gridSizeX;
        this.gridSizeY = gridSizeY;
    }

    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    } // end of constructor

    public int fCost { 
        get{ 
        return gCost + hCost;

        }

    }

}
