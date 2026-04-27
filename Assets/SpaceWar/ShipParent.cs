using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipParent : MovingObject
{
    public DrawableObject ship;
    public DrawableObject thrust;
    public float ShipMaxVelocity = 250;
    public float ShipThrust = 25f;
    public float ShipRotation = 120f;
    
    public bool isShipA = true;
    public bool IsDrawingLaser = false;

    public float MissleLaunchAt = 13f;
    public float MissileRadius = 2;

    public float LaserStart = 12f;
    public float LaserEnd = 100f;
    public float LaserShowTime = .5f;
    public float LaserShowCounter = 0f;



    public Missle missleObject;

    Line LaserObject;

    public void SetupA(DrawableGrid grid, int sceneIndex)
    {
        isShipA = true;
        ship = new ShipA();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipAThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity; 

        LaserObject = new Line();
        LaserObject.color = Color.yellow;
    }

    public void SetupB(DrawableGrid grid, int sceneIndex)
    {
        isShipA = false;
        ship = new ShipB();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipBThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity;

        LaserObject = new Line();
        LaserObject.color = Color.yellow;
    }

    public override void Tick()
    {
        base.Tick();
        UpdateSubObjects();
        UpdateLaser();
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
     
    public void UpdateLaser()
    {
        if (!IsDrawingLaser)
        {
            return;
        }
        LaserShowCounter -= Time.deltaTime;

        if (LaserShowCounter < 0)
        {
            IsDrawingLaser = false;
            return;
        }

        LaserObject.start = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), LaserStart);
        LaserObject.end = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), LaserEnd);

        SpaceWarGrid.self.DrawLine(LaserObject);
        LaserCollisionDetection();

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
       Rotation += (value * ShipRotation * Time.deltaTime * Mathf.Deg2Rad);
    }

    public void FireMissle(DrawableGrid grid, int sceneIndex)
    {
        missleObject = new Missle();
        missleObject.Position = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), MissleLaunchAt);
        //missleObject.SetRotationinDegrees(75);
        missleObject.CreateCollision(MissileRadius, grid, sceneIndex);
        missleObject.LaunchMissle(this.GetRotationinDegrees());
        grid.AddObjectToScene(sceneIndex, missleObject);
        SpaceWarGrid.self.MovingObjectlist.Add(missleObject);


    }

    public void FireLaser(DrawableGrid grid, int sceneIndex)
    {
        IsDrawingLaser = true;
        LaserShowCounter = LaserShowTime;
    }

    public void LaserCollisionDetection()
    {
        foreach (MovingObject mo in SpaceWarGrid.self.MovingObjectlist)
        {
            if (mo == this)
            {
                Debug.Log("We Found Ourselves");
            }

            if (CollisionTools.DoesLineIntersectCircle(LaserObject.start, LaserObject.end, mo.CollisionCircle.Position, mo.CollisionRadius))
            {
                Debug.Log("Found Hit With " + mo.ToString());

                if (mo is ShipParent)
                {
                    if (((ShipParent)mo).isShipA != this.isShipA)
                    {
                        SpaceWarGrid.self.RecordKill(isShipA);
                    }
                }

                if (mo is Missle)
                {
                    Missle missle = (Missle)mo;
                    missle.RemoveMissile();
                }
            }
        }
    }

}
