using System;
using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Data;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class LevelManager : SceneManager
    {

        public InputManager InputManager
        {
            get; private set;
        }
        
        public PlayerUnits PlayerUnits
        {
            get; private set;
        }

        public EnemyUnits EnemyUnits
        {
            get; private set;
        }

        public override GameStateType StateType
        {
            get
            {
                return GameStateType.InGameState;
            }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();
            InputManager = GetComponentInChildren<InputManager>();
            Global.Instance.LevelManager = this;

            EnemyUnits.Init();

            PlayerData playerData = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Heavy,
                ControllerType = InputManager.ControllerType.Keyboard1,
                Lives = 3
            };

            PlayerData playerData2 = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player2,
                UnitType = PlayerUnit.UnitType.Fast,
                ControllerType = InputManager.ControllerType.Gamepad,
                Lives = 3
            };

            PlayerData playerData3 = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player3,
                UnitType = PlayerUnit.UnitType.Balanced,
                ControllerType = InputManager.ControllerType.Keyboard2,
                Lives = 3
            };

            PlayerUnits.Init(playerData, playerData2, playerData3);
        }
    }
}