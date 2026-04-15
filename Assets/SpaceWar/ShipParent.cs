using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipParent : MovingObject
{
    public DrawableObject ship;
    public DrawableObject thrust;
    public float ShipMaxVelocity = 250;
    public float ShipThrust = 25f;

    public Missle missleObject;

    public void SetupA(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipA();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipAThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity; 
    }

    public void SetupB(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipB();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipBThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity;
    }

    public override void Tick()
    {
        base.Tick();
        UpdateSubObjects();
    }

    public void UpdateSubObjects()
    {
        ship.Position = this.Position;
        thrust.Position = this.Position;

        ship.Rotation = this.Rotation;
        thrust.Rotation = this.Rotation;

        ship.Scale = this.Scale;
        thrust.Scale = this.Scale;
    }
     

    public void AddThrust()
    {
        thrust.PerformDraw = true;

        Velocity += DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), 1) * ShipThrust * Time.deltaTime;
    }

    public void NoThrust()
    {
        thrust.PerformDraw = false; 
    }

    public void RotateShip(float value)
    { 
       Rotation += (value * Time.deltaTime * Mathf.Deg2Rad);
    }

    public void FireMissle(DrawableGrid grid, int sceneIndex)
    {
        missleObject = new Missle();
        missleObject.Position = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), 13);
        //missleObject.SetRotationinDegrees(75);
        missleObject.CreateCollision(2, grid, sceneIndex);
        missleObject.LaunchMissle(this.GetRotationinDegrees());
        grid.AddObjectToScene(sceneIndex, missleObject);
        SpaceWarGrid.self.MovingObjectlist.Add(missleObject);


    }

    public void FireLaser(DrawableGrid grid, int sceneIndex)
    {

    }
}
