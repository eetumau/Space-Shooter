using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.WaypointSystem
{
    public class PathUser : MonoBehaviour, IPathUser
    {
        #region Unity fields
        [SerializeField]
        private Direction _direction;
        [SerializeField]
        private float _arriveDistance = 0.1f;
        #endregion

        private IMover _mover;
        private Path _path;
        private bool _isInitialized = false;
        private float _sqrArriveDistance;

        public Waypoint CurrentwayPoint { get; private set; }

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public void Init(IMover mover, Path path)
        {
            _sqrArriveDistance = _arriveDistance * _arriveDistance;

            _mover = mover;
            _path = path;

            if(_path != null)
            {
                CurrentwayPoint = _path.GetClosestWaypoint(Position);
                _isInitialized = true;
            }
        }

        protected void Update()
        {
            if (!_isInitialized)
                return;

            CurrentwayPoint = GetWaypoint();

            if (CurrentwayPoint != null)
            {
                Vector3 direction = CurrentwayPoint.Position - Position;
                _mover.MoveToDirection(direction);
                _mover.RotateTowardPosition(CurrentwayPoint.Position);
            }
        }

        private Waypoint GetWaypoint()
        {
            Waypoint result = null;

            if (CurrentwayPoint != null)
            {
                Vector3 toWaypointVector = CurrentwayPoint.Position - Position;
                float waypointVectorSqrMagnitude = toWaypointVector.sqrMagnitude;

                if (waypointVectorSqrMagnitude <= _sqrArriveDistance)
                {
                    result = _path.GetNextWaypoint(CurrentwayPoint, ref _direction);
                }else
                {
                    result = CurrentwayPoint;
                }
            }

            return result;
        }

    }
}