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

        private Rigidbody _rigidbody;

        public ProjectileType Type
        {
            get { return _projectileType; }
        }

        #region Unity messages
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();

            if(damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);

                //TODO: Instantiate effect & add sound effect
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if(other.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
        #endregion

        public void Shoot(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}