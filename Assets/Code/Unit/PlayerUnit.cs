using System;
using TAMKShooter.Data;
using UnityEngine;
using TAMKShooter.Configs;
using TAMKShooter.Systems;
using System.Collections.Generic;
using System.Collections;

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

        private float _invulnerabilityTime = 1;
        public bool _invulnerable;

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
            InitRequiredComponents();
            Data = playerData;
            //Homework 2
            Health.MaxHealth = Health.CurrentHealth;
        }

        protected override void Die()
        {
            //Homework 2
            if(Data.Lives == 0)
            {
                gameObject.SetActive(false);
                base.Die();
            }else
            {
                Global.Instance.LevelManager.PlayerUnits.InitRespawning(this);
                Data.Lives -= 1;
            }
        }

        //Homework 2
        public IEnumerator Respawn()
        {
            _invulnerable = true;
            StartCoroutine(Flash());

            yield return new WaitForSeconds(1);

            _invulnerable = false;
        }

        //Homework 2
        private IEnumerator Flash()
        {
            Renderer rend = GetComponent<Renderer>();

            while (_invulnerable)
            {

                rend.material.color = Color.clear;

                yield return new WaitForSeconds(0.1f);

                rend.material.color = Color.white;

                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}
