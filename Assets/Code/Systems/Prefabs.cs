using UnityEngine;
using System.Collections.Generic;
using UnitType = TAMKShooter.PlayerUnit.UnitType;

namespace TAMKShooter.Systems
{
    public class Prefabs : MonoBehaviour
    {

        [SerializeField]
        private PlayerUnit[] _playerUnitPrefabs;

        public PlayerUnit GetPlayerUnitPrefab(UnitType unitType)
        {
            PlayerUnit result = null;

            for(int i = 0; i < _playerUnitPrefabs.Length; i++)
            {
                if(_playerUnitPrefabs[i].Type == unitType)
                {
                    result = _playerUnitPrefabs[i];
                    break;
                }
            }

            return result;
        }
    }
}
