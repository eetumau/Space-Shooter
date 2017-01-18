using System;

namespace TAMKShooter
{
    public class HealthChangedEventArgs : EventArgs
    {
        // The property which contains the amount of health unit has.
        public int CurrentHealth { get; private set; }
        /// <summary>
        /// Constructor which takes the amount of unit's health as a parameter
        /// </summary>
        /// <param name="currentHealth"></param>
        public HealthChangedEventArgs(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }
    }

    public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

    public interface IHealth
    {
        int CurrentHealth { get; set; }
        /// <summary>
        /// Reduces health when called.
        /// </summary>
        /// <param name="damage">The amount of health reduced</param>
        /// <returns>True, if health reaches 0, false otherwise</returns>
        bool TakeDamage(int damage);

        //This event is fired every time the health changes.
        event HealthChangedDelegate HealthChanged;

    }
}
