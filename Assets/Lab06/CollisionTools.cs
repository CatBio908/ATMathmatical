using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Rect = System.Drawing.Rectangle;
public static class CollisionTools 
{
    public static void DrawTriangle(TriangleData data, Color color, DrawableGrid grid = null)
    {
        Line lineA = new Line(data.PointA, data.PointB, color);
        Line lineB = new Line(data.PointB, data.PointC, color);
        Line lineC = new Line(data.PointC, data.PointA, color);

        if (grid == null)
        {
            // Info is in Screen Space 
            Glint.AddCommand(lineA);
            Glint.AddCommand(lineB);
            Glint.AddCommand(lineC); 
        }
        else
        {
            grid.DrawLine(lineA);
            grid.DrawLine(lineB);
            grid.DrawLine(lineC);
        }
    }

    public static void SetColor(DrawableObject thing,  Color color)
    {
        for (int i = 0; i < thing.LineList.Count; i++)
        {
            Line item = thing.LineList[i];
            item.color = color;
            thing.LineList[i] = item;

            // C# is acting weird... 
            // won't let me use foreach
            // wont' let me do LineList[i].color = color; 
        }
    }

    public static bool IsPointInCircle(Vector3 Point, Vector3 Center, float Radius)
    {
        bool result = false;

        Vector3 DistanceVector = Point - Center;

        if (DistanceVector.magnitude < Radius)
        {
            result = true;
        }

        // stub code 
        return result; 
    }

    public static bool IsPointInRectangle(Vector3 Point, Rect Box)
    {
        // stub code 
        return (Point.x > Box.X) && (Point.x < (Box.X + Box.Width))
            && (Point.y > Box.Y) && (Point.y < (Box.Y + Box.Height));
    }
    public static bool IsPointInTriangle(Vector3 Point, TriangleData Triangle)
    {
        //Vector3 side1 = (Triangle.PointB - Triangle.PointA), (Point - Triangle.PointA);
        //Vector3 side2 = (Triangle.PointB - Triangle.PointA), (Point - Triangle.PointA);
        //Vector3.Cross(side1, side2);

        return false;
            

        // stub code 
       
    }
}
