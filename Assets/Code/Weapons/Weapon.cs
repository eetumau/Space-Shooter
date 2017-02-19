using UnityEngine;
using ProjectileType = TAMKShooter.Projectile.ProjectileType;
using TAMKShooter.Utility;
using TAMKShooter.Systems;
using System;

namespace TAMKShooter
{
    public class Weapon : MonoBehaviour, IShooter
    {
        [SerializeField]
        private ProjectileType _projectileType;

        public void ProjectileHit(Projectile projectile)
        {
            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if(pool != null)
            {
                pool.ReturnObjectToPool(projectile);
            }else
            {
                Destroy(projectile.gameObject);
            }
        }

        public void Shoot(int projectileLayer)
        {
            Projectile projectile = GetProjectile();

            if(projectile != null)
            {
                projectile.gameObject.SetActive(true);
                projectile.transform.position = transform.position;
                projectile.transform.forward = transform.forward;
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(this, transform.forward);
            }else
            {
                Debug.LogError("Could not get projectile!");
            }
        }

        private Projectile GetProjectile()
        {
            Projectile result = null;

            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if(pool != null)
            {
                result = pool.GetPooledObject();
            }

            return result;
        }

    }

}
