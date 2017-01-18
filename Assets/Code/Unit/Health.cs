using System;
using UnityEngine;

namespace TAMKShooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private int _health;

        public int CurrentHealth
        {
            get
            {
                return _health;
            }

            set
            {
                _health = Mathf.Clamp(value, 0, value);
                if(HealthChanged != null)
                {
                    HealthChanged(this, new HealthChangedEventArgs(_health));
                }
            }
        }

        public event HealthChangedDelegate HealthChanged;

        public bool TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            return CurrentHealth == 0;
        }
    }
}
