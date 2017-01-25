using UnityEngine;

namespace TAMKShooter
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private float _shootingSpeed;

        private float _shootingRate;
        private float _previouslyShot;
        private Weapon[] _weapons;

        //TODO: Add support for boosters
        #region Unity messages
        protected void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            _shootingRate = 1 / _shootingSpeed;
            _previouslyShot = _shootingRate;
        }

        protected void Update()
        {
            _previouslyShot += Time.deltaTime;
        }
        #endregion

        public void Shoot(int projectileLayer)
        {
            if(_previouslyShot >= _shootingRate)
            {
                _previouslyShot = 0;
                foreach(Weapon weapon in _weapons)
                {
                    weapon.Shoot(projectileLayer);
                }
            }
        }
    }

}
