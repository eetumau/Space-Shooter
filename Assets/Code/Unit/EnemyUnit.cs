using System;
using UnityEngine;
using TAMKShooter.Configs;
using TAMKShooter.WaypointSystem;
using TAMKShooter.Utility;

namespace TAMKShooter
{
    public class EnemyUnit : UnitBase
    {
        private IPathUser _pathUser;

        public EnemyUnits EnemyUnits
        {
            get; private set;
        }

        public override int ProjectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.EnemyProjectileLayerName);
            }
        }

        public void Init(EnemyUnits enemyUnits, Path path)
        {
            InitRequiredComponents();
            EnemyUnits = enemyUnits;
            _pathUser = gameObject.GetOrAddComponent<PathUser>();
            _pathUser.Init(Mover, path);
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);
            base.Die();
            //TODO: Handle dying properly
        }

        //Homework 2
        private void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var unit = col.gameObject.GetComponent<PlayerUnit>();

                if (!unit._invulnerable)
                {
                    unit.Health.TakeDamage(100);
                }

                Health.TakeDamage(100);

            }
        }
    }
}
