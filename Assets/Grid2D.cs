using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grid2D : MonoBehaviour
{

    public Vector3 ScreenSize;
    public Vector3 origin;

    public float GridSize = 10f;
    public float MinGridSize = 2f;

    public int DivisionCount = 5;
    public int MinDivisionCount = 2;

    public float OriginSize = .6f;

    public Color AxisColor = Color.white;
    public Color LineColor = Color.grey;
    public Color DivisionColor = Color.yellow;

    bool isDrawingOrigin = false;
    bool isDrawingAxis = true;
    bool isDrawingDivisions = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /*public Vector3 GridtoScene(Vector3)
    {
        return;
    } */
    
    /*public Vector3 ScenetoGrid(Vector3)
    {
        return;
    } */

    /*public void DrawLine(Line)
    {

    } */

    public void DrawOrigin()
    {

    }

}
