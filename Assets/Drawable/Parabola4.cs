using UnityEngine;

public class Parabola4 : DrawableObject
{

    public override void Initalize()
    {
        for (int i = -100; i < 100; i++)
        {
            AddLineToObject(GetPointAt(i), GetPointAt(i + 1), Color.magenta);
        }
    }


    public float GetYPointatYof(float yValue)
    {
        float xValue;

        xValue = -(Mathf.Pow(yValue, 3));


        return xValue;


    }

    public Vector3 GetPointAt(float yValue)
    {
        return new Vector3(GetYPointatYof(yValue), yValue, 0);
    }
}
