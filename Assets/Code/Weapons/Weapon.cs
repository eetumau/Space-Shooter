using UnityEngine;
using ProjectileType = TAMKShooter.Projectile.ProjectileType;
using TAMKShooter.Utility;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ProjectileType _projectileType;

        public void Shoot(int projectileLayer)
        {
            Projectile projectile = GetProjectile();

            if(projectile != null)
            {
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(transform.forward);
            }
        }

        private Projectile GetProjectile()
        {
            Projectile projectilePrefab = Global.Instance.Prefabs.GetProjectilePrefabByType(_projectileType);

            if(projectilePrefab != null)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

                return projectile;
            }

            return null;
        }

    }

}
