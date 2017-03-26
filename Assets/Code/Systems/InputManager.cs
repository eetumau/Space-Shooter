using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Configs;
using System;

namespace TAMKShooter.Systems
{
    public class InputManager : MonoBehaviour
    {

        private static readonly Dictionary<ControllerType, string> ControllerNames =
            new Dictionary<ControllerType, string>()
        {
            { ControllerType.Keyboard1, "Arrow keys" },
            { ControllerType.Keyboard2, "WASD keys" },
            { ControllerType.Gamepad, "Gamepad 1" },
            { ControllerType.Gamepad2, "Gamepad 2" }
        };
        
        public static string GetControllerName(ControllerType controllerType)
        {
            string result = null;

            if (ControllerNames.ContainsKey(controllerType))
            {
                result = ControllerNames[controllerType];
            }

            return result;
        }

        public static ControllerType GetControllerTypeByName(string controllerName)
        {
            ControllerType result = ControllerType.Error;

            foreach(var kvp in ControllerNames)
            {
                if(kvp.Value == controllerName)
                {
                    result = kvp.Key;
                }
            }

            return result;
        }
        public enum ControllerType
        {
            Error = 0,
            Keyboard1 = 1,
            Keyboard2 = 2,
            Gamepad = 3,
            Gamepad2 = 4
        }

        private float inputX;
        private float inputZ;
        private Vector3 input;

        protected void Update()
        {
            PollSave();
        }

        public void PollSave()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Global.Instance.SaveManager.Save(Global.Instance.CurrentGameData, DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"));
            }
        }
        public void ReadInput(PlayerUnit unit)
        {
            switch (unit.Data.ControllerType)
            {
                case ControllerType.Keyboard1:
                    inputX = Input.GetAxis(Config.HorizontalName);
                    inputZ = Input.GetAxis(Config.VerticalName);

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    bool shoot = Input.GetButton(Config.ShootName);
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Keyboard2:
                    inputX = Input.GetAxis(Config.Horizontal2Name);
                    inputZ = Input.GetAxis(Config.Vertical2Name);

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton(Config.Shoot2Name);
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Gamepad:
                    inputX = Input.GetAxis(Config.GP_HorizontalName);
                    inputZ = Input.GetAxis(Config.GP_VerticalName);

                    if (IsDeadZone(new Vector2(inputX, inputZ)))
                    {
                        inputX = 0;
                        inputZ = 0;
                    }

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton(Config.GP_ShootName);
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Gamepad2:
                    inputX = Input.GetAxis(Config.GP_Horizontal2Name);
                    inputZ = Input.GetAxis(Config.GP_Vertical2Name);

                    if (IsDeadZone(new Vector2(inputX, inputZ)))
                    {
                        inputX = 0;
                        inputZ = 0;
                    }

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton(Config.GP_Shoot2Name);
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;
            }
        }

        private bool IsDeadZone(Vector2 input)
        {
            return input.magnitude < Config.DeadZone;
        }
    }
}