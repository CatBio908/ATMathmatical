using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
 
    public Vector3 ScreenSize;
    public Vector3 origin;

    public float OriginY;
    public float OriginX;

    public float GridSize = 10f;
    public float MinGridSize = 2f;

    public int DivisionCount = 5;
    public int MinDivisionCount = 2;

    public float OriginSize = .6f;

    public float TopPoint;
    public float RightPoint;
    public float BottomPoint;
    public float LeftPoint;

    public Color AxisColor = Color.white;
    public Color LineColor = Color.grey;
    public Color DivisionColor = Color.yellow;

    public bool isDrawingOrigin = false;
    public bool isDrawingAxis = true;
    public bool isDrawingDivisions = true;

    public bool isDrawing = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScreenSize = new Vector3(Screen.width, Screen.height);
        origin = new Vector3(Screen.width / 2, Screen.height / 2);

        OriginY = Screen.height / 2;
        OriginX = Screen.width / 2;
    }

    void Update()
    {
        DrawAxis();
        DrawOrigin();
        DrawDivision();
        DrawGrid();
        TopPoint = GridSize * OriginSize;
        RightPoint = GridSize * OriginSize;
        BottomPoint = GridSize * OriginSize;
        LeftPoint = GridSize * OriginSize;
    }

    public Vector3 GridtoScene(Vector3 gridSpace)
    {
        return Vector3.zero;
    } 
    
    public Vector3 ScenetoGrid(Vector3 screenSpace)
    {
        return Vector3.zero;
    }

    /// <summary>
    /// Draws the given line object. If you are creating new line object, use the overload that takes parameters instead.
    /// </summary>
    /// <param name="line"></param>
    public void DrawLine(Line line)
    {
        Glint.AddCommand(line);
    }
    /// <summary>
    /// Draws a line, This overload takes line parameters
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        Glint.AddCommand(new Line(start, end, color));
    }

    public void DrawOrigin()
    {
        if (isDrawingOrigin == true)
        {
            DrawLine(new Vector3(0, TopPoint, 0) + origin, new Vector3(RightPoint, 0, 0) + origin , LineColor);
            DrawLine(new Vector3(RightPoint, 0, 0) + origin, new Vector3(0, -BottomPoint, 0) + origin, LineColor);
            DrawLine(new Vector3(0, -BottomPoint, 0) + origin, new Vector3(-LeftPoint, 0, 0) + origin, LineColor);
            DrawLine(new Vector3(-LeftPoint, 0, 0) + origin, new Vector3(0, TopPoint, 0) + origin, LineColor);
        }
    }

    public void DrawAxis()
    {
        if (isDrawingAxis == true)
        {
            DrawLine(new Vector3(0, OriginY, 0), new Vector3(Screen.width, OriginY, 0), AxisColor);
            DrawLine(new Vector3(OriginX, 0, 0), new Vector3(OriginX, Screen.height, 0), AxisColor);
        }

    }

    public void DrawGrid()
    {
        Vector3 PosPoint;
        Vector3 NegPoint;

        //indexOffset = 0;

        while (isDrawing)
        {

        }
    }

    public void DrawDivision()
    {
        if (isDrawingDivisions == true)
        {
          /*  DrawLine(new Vector3(0, OriginY + DivisionCount, 0), new Vector3(Screen.width, OriginY + DivisionCount, 0), DivisionColor);
            DrawLine(new Vector3(0, OriginY - DivisionCount, 0), new Vector3(Screen.width, OriginY - DivisionCount, 0), DivisionColor);
            DrawLine(new Vector3(OriginX + DivisionCount, 0, 0), new Vector3(OriginX + DivisionCount, Screen.height, 0), DivisionColor);
            DrawLine(new Vector3(OriginX - DivisionCount, 0, 0), new Vector3(OriginX - DivisionCount, Screen.height, 0), DivisionColor); */
        }
    }


}
