using UnityEngine;

using Rect = System.Drawing.Rectangle; 

public class lab05Grid : DrawableGrid
{
    
    Rect box;
    Rect boxOnGrid;

    Vector3 DrawTestPoint;

    Line circleRadiusLine;
    float circleRadius = 10;
    Line ellipseRadiusLine;
    Vector2 ellipseAxis;

    DrawableObject ellipseObject;

    float offset;

    public override void SetupScenes()
    {
        int sceneIndex;
        DrawableObject newObject;

        sceneIndex = AddScene("DrawingTools + Circle + Ellipse + Rectangles");
        newObject = DrawingTools.CreateCircleObject(Vector3.zero, 10, 360, Color.blue);
        newObject.Position.y = 15;
        AddObjectToScene(sceneIndex, newObject);
        newObject = DrawingTools.CreateEllipseObject(Vector3.zero, new Vector2(10, 20), 360, Color.blue);
        newObject.Position.x = 15;
        newObject.Position.x = 15;
        ellipseObject = newObject;
        AddObjectToScene(sceneIndex, newObject);


        ellipseAxis = new Vector2(20, 40);
        box = new Rect(140, 120, 140, 120);
        boxOnGrid = new Rect(2, 3, 20, 10);

        offset = 0;

        circleRadiusLine = new Line(Vector3.zero, Vector3.zero, Color.cyan);
        ellipseRadiusLine = new Line(Vector3.zero, Vector3.zero, Color.magenta);

        DrawTestPoint = origin;
        DrawTestPoint.x *= .5f;

        circleRadiusLine.start = ScreenToGrid(DrawTestPoint);

    }

    public override void Tick()
    {
        offset += Time.deltaTime;

        DrawingTools.DrawRectangle(box, Color.red);
        DrawingTools.DrawRectangle(boxOnGrid, Color.green, this);

        circleRadiusLine.end = DrawingTools.CircleRadiusPoint(ScreenToGrid(DrawTestPoint), offset * 365, circleRadius);
        DrawLine(circleRadiusLine);

        DrawingTools.DrawCircle(DrawTestPoint, circleRadius * gridSize, 360, Color.white);

        ellipseRadiusLine.end = DrawingTools.EllipseRadiusPoint(Vector3.zero, offset * 175, ellipseAxis);
        DrawLine(ellipseRadiusLine);

        DrawingTools.DrawEllipse(origin, ellipseAxis * gridSize, 360, Color.grey);

        ellipseObject.Rotation = offset * 15 * Mathf.Deg2Rad;

    }
}
