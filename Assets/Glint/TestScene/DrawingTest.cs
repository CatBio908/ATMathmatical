using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawingTest : MonoBehaviour
{

	public List<Line> SceneData;

    private void Start()
    {
        SceneData = new List<Line>();
    }

    void Update()
    {
		Vector3 mousePosition = Vector3.zero;

		Mouse mouse = Mouse.current; 
		if (mouse != null)
        {
			mousePosition = mouse.position.ReadValue(); 
        }

        SceneData.Add(new Line(new Vector3(0,			0,				0), mousePosition, Color.gray));
        SceneData.Add(new Line(new Vector3(Screen.width, 0,				0), mousePosition, Color.red));
        SceneData.Add(new Line(new Vector3(0,			Screen.height,	0), mousePosition, Color.green));
        SceneData.Add(new Line(new Vector3(Screen.width, Screen.height,	0), mousePosition, Color.blue));


		DrawScene();

	}

	public void DrawScene()
	{
		foreach (Line line in SceneData)
		{
			Glint.AddCommand(line);
		}

		SceneData.Clear();
	}
}
