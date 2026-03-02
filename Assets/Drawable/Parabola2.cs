using UnityEngine;

public class Parabola2 : DrawableObject
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
        float yValue;


        yValue = (Mathf.Pow(xValue, 2) + (2 * xValue) + 1);
        

        return yValue;

      
    }

    public Vector3 GetPointAt(float xValue)
    {
        return new Vector3(xValue, GetYPointatXof(xValue), 0);
    }
}
