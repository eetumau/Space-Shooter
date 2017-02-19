using System;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class MenuManager : SceneManager
    {
        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        public void StartGame()
        {
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
