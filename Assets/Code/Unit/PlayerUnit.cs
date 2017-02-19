using System;
using TAMKShooter.Data;
using UnityEngine;
using TAMKShooter.Configs;

namespace TAMKShooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 2,
            Heavy = 3
        }

        [SerializeField]
        private UnitType _type;

        public UnitType Type
        {
            get { return _type; }
        }
        public PlayerData Data
        {
            get; private set;
        }

        public override int ProjectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.PlayerProjectileLayerName);
            }
        }

        public void Init(PlayerData playerData)
        {
            Data = playerData;
        }

        protected override void Die()
        {
            //TODO: Handle dying properly!
            gameObject.SetActive(false);
            base.Die();
        }

    }
}
