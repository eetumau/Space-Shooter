using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class InputManager : MonoBehaviour
    {
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

        public void ReadInput(PlayerUnit unit)
        {
            switch (unit.Data.ControllerType)
            {
                case ControllerType.Keyboard1:
                    inputX = Input.GetAxis("Horizontal");
                    inputZ = Input.GetAxis("Vertical");

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    bool shoot = Input.GetButton("Shoot");
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Keyboard2:
                    inputX = Input.GetAxis("Horizontal2");
                    inputZ = Input.GetAxis("Vertical2");

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton("Shoot2");
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Gamepad:
                    inputX = Input.GetAxis("GP_Horizontal");
                    inputZ = Input.GetAxis("GP_Vertical");

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton("GP_Shoot");
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;

                case ControllerType.Gamepad2:
                    inputX = Input.GetAxis("GP_Horizontal2");
                    inputZ = Input.GetAxis("GP_Vertical2");

                    input = new Vector3(inputX, 0, inputZ);

                    unit.Mover.MoveToDirection(input);

                    shoot = Input.GetButton("GP_Shoot2");
                    if (shoot)
                    {
                        unit.Weapons.Shoot(unit.ProjectileLayer);
                    }
                    break;
            }
        }
    }
}