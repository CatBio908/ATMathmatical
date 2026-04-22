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

    public static bool DoesLineIntersectCircle(Vector3 LineStart, Vector3 LineEnd, Vector3 CircleCenter, float CircleRadius)
    {
        List<Vector3> result = IntersectionPoint(LineStart, LineEnd, CircleCenter, CircleRadius);
        if (result.Count == 0)
        {
            return false;
        }

        return true;
    }

    public static bool DoesLineIntersectCircle(Vector3 LineStart, Vector3 LineEnd, Vector3 CircleCenter, float CircleRadius, DrawableObject Intersect1, DrawableObject Intersect2)
    {

        List<Vector3> result = IntersectionPoint(LineStart, LineEnd, CircleCenter, CircleRadius);
        if (result.Count == 0)
        {
            Intersect1.PerformDraw = false;
            Intersect2.PerformDraw = false;
            return false;
        }

        if (result.Count == 1)
        {
            Intersect1.PerformDraw = true;
            Intersect1.Position = result[0];
            Intersect2.PerformDraw = false;
            return true;
        }

        Intersect1.PerformDraw = true;
        Intersect1.Position = result[0];
        Intersect2.PerformDraw = true;
        Intersect1.Position = result[0];

        return true;

    }

    public static List<Vector3> IntersectionPoint(Vector3 p1, Vector3 p2, Vector3 center, float radius)
    {
        List<Vector3> result = new List<Vector3>();



        Vector3 dp = new Vector3();
        Vector3[] sect;
        float a, b, c;
        float bb4ac;
        float mu1;
        float mu2;
        // get the distance between X and Z on the segment
        dp.x = p2.x - p1.x;
        dp.y = p2.y - p1.y;
        // I don't get the math here
        a = dp.x * dp.x + dp.y * dp.y;
        b = 2 * (dp.x * (p1.x - center.x) + dp.y * (p1.y - center.y));
        c = center.x * center.x + center.y * center.y;
        c += p1.x * p1.x + p1.y * p1.y;
        c -= 2 * (center.x * p1.x + center.y * p1.y);
        c -= radius * radius;
        bb4ac = b * b - 4 * a * c;
        if (Mathf.Abs(a) < float.Epsilon || bb4ac < 0)
        {
            // line does not intersect
            return result;
        }
        mu1 = (-b + Mathf.Sqrt(bb4ac)) / (2 * a);
        mu2 = (-b - Mathf.Sqrt(bb4ac)) / (2 * a);
        sect = new Vector3[2];
        sect[0] = new Vector3(p1.x + mu1 * (p2.x - p1.x), p1.y + mu1 *
        (p2.y - p1.y), 0);
        sect[1] = new Vector3(p1.x + mu2 * (p2.x - p1.x), p1.y + mu2 *
        (p2.y - p1.y), 0);

        if (IsInLineSegment(sect[0], p1, p2))
        {
            result.Add(sect[0]);
        }

        if (IsInLineSegment(sect[1], p1, p2))
        {
            result.Add(sect[1]);
        }
        
        return result;
    }

    public static bool IsInLineSegment(Vector3 point, Vector3 start, Vector3
    end)
    {
        // Stub Code
        return (
            (Mathf.Min(start.x, end.x) <= point.x) &&
            (point.x <= Mathf.Max(start.x, end.x)) &&
            (Mathf.Min(start.y, end.y) <= point.y) &&
            (point.y <= Mathf.Max(start.y, end.y))
            );
    }


}
