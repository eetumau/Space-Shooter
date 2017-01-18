using UnityEngine;

namespace TAMKShooter
{
    public interface IMover
    {
        //Position of this object in world space
        Vector3 Position { get; set; }
        //Rotation of this object in world space
        Quaternion Rotation { get; set; }
        // The speed of this mover
        float Speed { get; }

        // Moves towards targetPosition
        void MoveTowardPosition(Vector3 targetPosition);
        // Moves to direction "direction"
        void MoveToDirection(Vector3 direction);
        // Rotates towards targetPosition
        void RotateTowardPosition(Vector3 targetPosition);
        
    }
}
