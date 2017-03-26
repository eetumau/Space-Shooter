using TAMKShooter.Systems.States;
using TAMKShooter.Data;
using TAMKShooter.Level;
using UnityEngine;
using System.Collections.Generic;

namespace TAMKShooter.Systems
{
    public class LevelManager : SceneManager
    {

        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;
        
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

        public void ConditionMet(ConditionBase condition)
        {
            bool areConditionsMet = true;
            foreach(ConditionBase c in _conditions)
            {
                if (!c.IsConditionMet)
                {
                    areConditionsMet = false;
                    break;
                }
            }

            if (areConditionsMet)
            {
                (AssociatedState as GameState).LevelCompleted();
            }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            DontDestroyOnLoad(gameObject);
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();
            InputManager = GetComponentInChildren<InputManager>();
            Global.Instance.LevelManager = this;

            EnemyUnits.Init();

            _enemySpawners = GetComponentsInChildren<EnemySpawner>();
            foreach(var enemySpawner in _enemySpawners)
            {
                enemySpawner.Init(EnemyUnits);
            }

#if UNITY_EDITOR
            if(Global.Instance.CurrentGameData == null)
            {
                Global.Instance.CurrentGameData = new GameData()
                {
                    level = 1,
                    PlayerDatas = new List<PlayerData>()
                    {
                        new PlayerData()
                        {
                            ControllerType = InputManager.ControllerType.Keyboard1,
                            Id = PlayerData.PlayerId.Player1,
                            Lives = 3,
                            UnitType = PlayerUnit.UnitType.Balanced
                        },

                        new PlayerData()
                        {
                            ControllerType = InputManager.ControllerType.Keyboard2,
                            Id = PlayerData.PlayerId.Player2,
                            Lives = 3,
                            UnitType = PlayerUnit.UnitType.Fast
                        }
                    }
                };
            }
#endif
            PlayerUnits.Init(Global.Instance.CurrentGameData.PlayerDatas.ToArray());

            _conditions = GetComponentsInChildren<ConditionBase>();
            foreach(var condition in _conditions)
            {
                condition.Init(this);
            }
        }
    }
}