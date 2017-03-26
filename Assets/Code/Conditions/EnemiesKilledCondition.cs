using System;
using UnityEngine;

namespace TAMKShooter.Level
{
    public class EnemiesKilledCondition : ConditionBase
    {
        [SerializeField]
        private int _enemyCount;

        private int _enemiesKilled = 0;

        protected override void Initialize()
        {
            LevelManager.EnemyUnits.EnemyDestroyed += HandleEnemyDestroyed;
        }

        private void HandleEnemyDestroyed(EnemyUnit enemy)
        {
            _enemiesKilled++;
            if(_enemiesKilled >= _enemyCount)
            {
                IsConditionMet = true;
                LevelManager.ConditionMet(this);
            }
        }
    }
}
