using UnityEngine;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class PlayerUnits : MonoBehaviour
    {

        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = 
           new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach(PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitPrefab(playerData.UnitType);
                if(unitPrefab != null)
                {
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = Vector3.zero;
                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(playerData);

                    _players.Add(playerData.Id, unit);
                }else
                {
                    Debug.LogError("Unit prefab with type " + playerData.UnitType + " could not be found!");
                }
            }
        }

        private void Update()
        {
           foreach(KeyValuePair<PlayerData.PlayerId, PlayerUnit> entry in _players)
            {
                Global.Instance.LevelManager.InputManager.ReadInput(entry.Value);
            }                        
        }


    }
}
