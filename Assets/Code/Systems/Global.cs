using System;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class Global : MonoBehaviour
    {

        private static Global _instance;

        public static Global Instance
        {
            get
            {
                if(_instance == null)
                {
                    GameObject globalObj = new GameObject(typeof(Global).Name);
                    _instance = globalObj.AddComponent<Global>();
                }

                return _instance;
            }
        }

        [SerializeField]
        private Prefabs _prefabs;

        public Prefabs Prefabs
        {
            get { return _prefabs; }
        }

        protected void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }

            if(_instance == this)
            {
                Init();
            }else
            {
                Destroy(this);
            }
        }

        private void Init()
        {
            if(_prefabs == null)
            {
                _prefabs = GetComponentInChildren<Prefabs>();
            }

        }
    }
}