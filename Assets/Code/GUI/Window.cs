using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.GUI
{
    public class Window : MonoBehaviour
    {

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}