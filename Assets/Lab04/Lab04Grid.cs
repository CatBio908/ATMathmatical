using UnityEngine;

public class Lab04Grid : DrawableGrid
{
    public override void SetupScenes()
    {
        int sceneIndex; 
        DrawableArrow newArrow; 
        DrawableObject newGraph;


        AddScene("Empty Scene, Use Tab To Switch Scenes");

        sceneIndex = AddScene("Diamond as is");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond at Scale of 20");
        newGraph = new DrawableDiamond();
        newGraph.Scale = (Vector3.one * 20);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond at Scale of 20,10");
        newGraph = new DrawableDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond at Scale of 20,10 Rotation of 45 Degrees");
        newGraph = new DrawableDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        newGraph.Rotation = 45 * Mathf.Deg2Rad;
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Rotating Diamond at Scale of 20,10");
        newGraph = new RotatingDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Facing Arrow at Scale of 2.5,2.5");
        newGraph = new FacingArrow();
        newGraph.Scale = new Vector3(2.5f, 2.5f, 1);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola 1: Y=X^2");
        newGraph = new Parabola1();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola 2: Y=X^2+2x+1");
        newGraph = new Parabola2();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola 3: Y=-2X^2+10x+12");
        newGraph = new Parabola3();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola 3: X=Y^3");
        newGraph = new Parabola4();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Arrow, As is");
        newArrow = new DrawableArrow();
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, Moved Forward");
        newArrow = new DrawableArrow();
        newArrow.Position = new Vector2(30, 0);
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, 50% size");
        newArrow = new DrawableArrow();
        newArrow.Scale = (Vector3.one * .5f); 
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, Moved Forward at 25% size");
        newArrow = new DrawableArrow();
        newArrow.Position = new Vector2(30, 0);
        newArrow.Scale = (Vector3.one * .25f);
        AddObjectToScene(sceneIndex, newArrow);
    }

    public override void Tick()
    {
        
        base.Tick();
    }
}
