using UnityEngine;

namespace TAMKShooter
{
    public class Projectile : MonoBehaviour
    {

        public enum ProjectileType
        {
            None = 0,
            Lazer = 1,
            Explosive = 2,
            Missile = 3
        }

        #region Unity fields
        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ProjectileType _projectileType;

        #endregion

        private IShooter _shooter;

        public Rigidbody Rigidbody { get; private set; }

        public ProjectileType Type
        {
            get { return _projectileType; }
        }


        #region Unity messages
        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();

            if(damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);

                //TODO: Instantiate effect & add sound effect
                _shooter.ProjectileHit(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if(other.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                _shooter.ProjectileHit(this);
            }
        }
        #endregion

        public void Shoot(IShooter shooter, Vector3 direction)
        {
            _shooter = shooter;
            Rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}