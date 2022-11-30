using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace IntroductieProject
{
    class ConditionalSprite
    {
        private string assetName, newAssetName;
        private EnemyConditionalSprite enemyConditionalSprite;
        private PlayerConditionalSprite playerConditionalSprite;
        private string type;

        internal ConditionalSprite(string assetName)
        {
            this.assetName = assetName;
            newAssetName = assetName;
        }
        internal void update(GameTime time, EntityOrientation orientation = EntityOrientation.Down)
        {
            switch (type)
            {
                case "player":
                    playerConditionalSprite.update(time);
                    newAssetName = playerConditionalSprite.PlayerSprite(assetName, orientation);
                    break;
                case "enemy":
                    newAssetName = enemyConditionalSprite.EnemySprite(assetName, orientation);
                    break;
                default:
                    newAssetName = assetName;
                    break;
            }
        }

        public void AssignType(string assetName)
        {
            if(assetName.Contains("Player"))
            {
                type = "player";
                playerConditionalSprite = new PlayerConditionalSprite(assetName);
            }
            else if (assetName.Contains("Enemy"))
            {
                type = "enemy";
                enemyConditionalSprite = new EnemyConditionalSprite(assetName);
            }
        }

        public string AssetName { get { return newAssetName; } }
    }
}


