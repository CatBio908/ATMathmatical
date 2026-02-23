
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

    public bool isDrawingOrigin = false;
    public bool isDrawingAxis = true;
    public bool isDrawingDivisions = true;
    public bool isDrawingObjects = true;

    public List<DrawingObject> lineObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScreenSize = new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height);
        origin = new Vector3(UnityEngine.Screen.width / 2, UnityEngine.Screen.height / 2);

        lineObjects = new List<DrawingObject>();
        lineObjects.Add(new Arrow());

    }

    void Update()
    {
        GetInput();

        DrawGrid();

        DrawObjects();

    }

    public Vector3 GridtoScene(Vector3 gridSpace)
    {

    
        return (origin + (gridSpace * GridSize));
    }

    public Vector3 ScenetoGrid(Vector3 screenSpace)
    {
        Vector3 result = screenSpace - origin;
        result /= GridSize;

        return result;

    }

    public static Vector3 RotatePoint(Vector3 Center, float angle, Vector3 pointIn)
    {
        return new Vector3();
    }

    void GetInput()
    {
        Mouse mouse = Mouse.current;
        Vector3 MousePos = Mouse.current.position.ReadValue();
        Keyboard kb = Keyboard.current;

        if ((kb == null) || (mouse == null))
        {
            Debug.LogError("Missing keyboard or mouse");
            return;
        }
        // If you reach here mouse and kb has valid references

        // Get Scroll Wheel and affect Grid Size 
        bool ControlKey = kb.ctrlKey.isPressed;
        Vector2 Scroll = mouse.scroll.ReadValue();
        if ((Scroll.y > 0) && !ControlKey)
        {
            GridSize++;
        }

        if ((Scroll.y < 0) && !ControlKey)
        {
            GridSize--;

            if (GridSize <= MinGridSize)
            { GridSize = MinGridSize; }
        }

        if ((Scroll.y > 0) && ControlKey)
        {
            DivisionCount++;
        }

        if ((Scroll.y < 0) && ControlKey)
        {
            DivisionCount--;

            if (DivisionCount <= MinDivisionCount)
            { DivisionCount = MinDivisionCount; }
        }


        if (kb.digit1Key.wasPressedThisFrame)
        {
            isDrawingOrigin = !isDrawingOrigin;
        }

        if (kb.digit2Key.wasPressedThisFrame)
        {
            isDrawingAxis = !isDrawingAxis;
        }

        if (kb.digit3Key.wasPressedThisFrame)
        {
            isDrawingDivisions = !isDrawingDivisions;
        }

        if (mouse.middleButton.isPressed)
        {
            origin = MousePos;
        }

    }
    public void DrawOrigin()
    {
        if (isDrawingOrigin)
        {

            Vector3 TopPoint = origin;
            TopPoint.y += GridSize * OriginSize;
            Vector3 RightPoint = origin;
            RightPoint.x += GridSize * OriginSize;
            Vector3 BottomPoint = origin;
            BottomPoint.y -= GridSize * OriginSize;
            Vector3 LeftPoint = origin;
            LeftPoint.x -= GridSize * OriginSize;




            DrawLine(TopPoint, RightPoint, AxisColor, false);
            DrawLine(RightPoint, BottomPoint, AxisColor, false);
            DrawLine(BottomPoint, LeftPoint, AxisColor, false);
            DrawLine(LeftPoint, TopPoint, AxisColor, false);

        }
    }



    public void DrawLineAtPoint(Vector3 point, Color drawingColor)
    {
        //consider creating local varaibles to pass into the draw line function

        // Points of line are ystart yend xstart xend
        DrawLine(new Vector3(0, point.y, 0), new Vector3(UnityEngine.Screen.width, point.y, 0), drawingColor, false);
        DrawLine(new Vector3(point.x, 0, 0), new Vector3(point.x, UnityEngine.Screen.height, 0), drawingColor, false);
    }
    public void DrawGrid()
    {
        

        bool isDrawing = true;
        Vector3 PosPoint = Vector3.zero;
        Vector3 NegPoint = Vector3.zero;
        Vector3 PointOffset = Vector3.zero;

        int indexOffset = 0;
        Color drawColor = LineColor;


        while (isDrawing)
        {
            //1. figure out what line to draw. 
            // Default color to standard line 
            drawColor = LineColor;

            // Check for divison line 
            if (isDrawingDivisions && ((indexOffset % DivisionCount) == 0))
            {
                drawColor = DivisionColor;
            }

            // Check for Axis 
            if (isDrawingAxis && (indexOffset == 0))
            {
                drawColor = AxisColor;
                DrawOrigin();
            }

            // 2. Figure out Points to draw on this go. 

            PointOffset = new Vector3(GridSize, GridSize, 0) * indexOffset;

            PosPoint = origin + PointOffset;
            NegPoint = origin - PointOffset;

            //3. Draw the points 

            DrawLineAtPoint(PosPoint, drawColor);
            DrawLineAtPoint(NegPoint, drawColor);




            // 4. figure out when to stop drawing. 
            indexOffset++;
            
            /* 
            if (indexOffset >= 10)
            {
                isDrawing = false;
            } 
            */

            if (IsOffScreen(PosPoint) && IsOffScreen(NegPoint))
            {
                isDrawing = false;
            }

            //test for x being off the screen on both sides
            //test for y being off the screen on both sides

        }
    }

    public void DrawObjects()
    {
        if (!isDrawingObjects) { return; }

        if (lineObjects.Count == 0)
        {
            Debug.Log("No objects to draw");
            return;
        }

        foreach (DrawingObject obj in lineObjects)
        {
            obj.Draw(this);
        }
    }

    public bool IsOffScreen(Vector3 point)
    {
        /// Can you tell me how to get to Seaseme Street
        bool vertical = ((point.y < 0) || (point.y > ScreenSize.y));
        bool horizontal = ((point.x < 0) || (point.x > ScreenSize.x));

        return (vertical && horizontal);
    }



    /// <summary>
    /// Draws the given line object. If you are creating new line object, use the overload that takes parameters instead.
    /// </summary>
    /// <param name="line"></param>
    public void DrawLine(Line line, bool drawOnGrid = true)
    {
        if (!drawOnGrid)
        {
            Glint.AddCommand(line);
            return;
        }
        DrawLine(line.start, line.end, line.color, drawOnGrid);
        
    }
    /// <summary>
    /// Draws a line, This overload takes line parameters
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public void DrawLine(Vector3 start, Vector3 end, Color color, bool drawOnGrid = true)
    {
        if (!drawOnGrid)
        {
            Glint.AddCommand(new Line(start,  end, color));
            return;
        }

        Glint.AddCommand(new Line(GridtoScene(start), GridtoScene(end), color));
    }

}
