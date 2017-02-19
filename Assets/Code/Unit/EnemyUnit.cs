using System;
using UnityEngine;
using TAMKShooter.Configs;

namespace TAMKShooter
{
    public class EnemyUnit : UnitBase
    {
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

        public void Init(EnemyUnits enemyUnits)
        {
            EnemyUnits = enemyUnits;
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);
            base.Die();
            //TODO: Handle dying properly
        }
    }
}
