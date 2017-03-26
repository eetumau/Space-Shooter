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

        //Homework 2
        [SerializeField]
        private Transform[] _spawnPoints;

        public void Init(params PlayerData[] players)
        {
            foreach(PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitPrefab(playerData.UnitType);
                if(unitPrefab != null)
                {
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    
                    //Homework 2
                    unit.transform.position = _spawnPoints[(int)playerData.Id -1].transform.position;

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

        //Homework 2
        public void InitRespawning(PlayerUnit playerUnit)
        {

            if(playerUnit.Data.Lives != 0)
            {
                playerUnit.Health.CurrentHealth = playerUnit.Health.MaxHealth;
                playerUnit.transform.position = _spawnPoints[(int)playerUnit.Data.Id - 1].transform.position;
                playerUnit.transform.rotation = Quaternion.identity;

                StartCoroutine(playerUnit.Respawn());
            }
        }

    }
}
