using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;



class FacingArrow : DrawableObject
{

    public bool isMoving = true;
    public bool isFacingMouse = true;
    public float MoveSpeed = 5f;

    public override void Initalize()
    {
        AddLineToObject(new Vector2(0, 10), new Vector2(0, 20), Color.red);
        AddLineToObject(new Vector2(0, 20), new Vector2(20, 0), Color.red);
        AddLineToObject(new Vector2(20, 0), new Vector2(0, -20), Color.red);
        AddLineToObject(new Vector2(0, -20), new Vector2(0, -10), Color.red);
        AddLineToObject(new Vector2(0, -10), new Vector2(-20, -10), Color.red);
        AddLineToObject(new Vector2(-20, -10), new Vector2(-20, 10), Color.red);
        AddLineToObject(new Vector2(-20, 10), new Vector2(0, 10), Color.red);

    }

    public override void Tick()
    {
        if (isMoving)
        {
            Position.x += MoveSpeed * Time.deltaTime;
        }
        if (isFacingMouse)
        {
            // This works because they're in Screen Space
            //Vector3 screenPosition = DrawableGrid.Instance.origin;
            /*Vector3 screenPosition = DrawableGrid.Instance.GridToScreen(Position);
            Roattion = V3ToAngle(screenPosition,
            DrawableGrid.Instance.MousePosition);*/
        }
    }
}

