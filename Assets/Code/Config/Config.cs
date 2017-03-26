using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Configs
{
    public static class Config
    {
        public const string MenuSceneName = "Menu";

        public static readonly Dictionary<int, string> LevelNames =
            new Dictionary<int, string>()
        {
                {1, "Level1" },
                {2, "Level2" }
        };

        public const string PlayerProjectileLayerName = "PlayerProjectile";
        public const string EnemyProjectileLayerName = "EnemyProjectile";

        public const string HorizontalName = "Horizontal";
        public const string VerticalName = "Vertical";
        public const string ShootName = "Shoot";

        public const string Horizontal2Name = "Horizontal2";
        public const string Vertical2Name = "Vertical2";
        public const string Shoot2Name = "Shoot2";

        public const string GP_HorizontalName = "GP_Horizontal";
        public const string GP_VerticalName = "GP_Vertical";
        public const string GP_ShootName = "GP_Shoot";

        public const string GP_Horizontal2Name = "GP_Horizontal2";
        public const string GP_Vertical2Name = "GP_Vertical2";
        public const string GP_Shoot2Name = "GP_Shoot2";

        public const float DeadZone = 0.3f;

    }
}