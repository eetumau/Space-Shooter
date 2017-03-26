using UnityEngine;

namespace TAMKShooter.WaypointSystem
{
    public enum Direction
    {
        Forward,
        Backward
    }

    public enum PathType
    {
        Loop,
        Patrol,
        OneWay
    }

    public interface IPathUser
    {

        Waypoint CurrentwayPoint { get; }
        Direction Direction { get; set; }
        Vector3 Position { get; set; }

        void Init(IMover mover, Path path);

    }
}
