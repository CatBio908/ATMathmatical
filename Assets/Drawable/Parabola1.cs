using UnityEngine;

public class Parabola1 : DrawableObject
{

    public override void Initalize()
    {
        for (int i = -100; i < 100; i++)
        {
           AddLineToObject(GetPointAt(i), GetPointAt(i + 1), Color.magenta);
        }
    }

    
    public float GetYPointatXof(float xValue)
    {
        //float yValue;

        //yValue = MathF.Pow(xValue, 2);
        //yValue = xValue * xValue;

        //return yValue;

        return Mathf.Pow(xValue, 2);
    }

    public Vector3 GetPointAt(float xValue)
    {
        return new Vector3(xValue, GetYPointatXof(xValue), 0);
    }
    
}
