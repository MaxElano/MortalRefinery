using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    internal class NormalAbilityCooldown_UI : GameEntity
    {
        Player player;
        public NormalAbilityCooldown_UI(Vector2 center, int width, int height, string assetName, Player player, bool draggable = false, bool visible = true) : base(center, width, height, assetName)
        {
            this.player = player;
        }

        internal override void update(GameTime time)
        {
            if (player.NormalAbilityCooldownTimer <= 0)
                this.visible = true;
            if (player.NormalAbilityCooldownTimer > 0)
                this.visible = false;
            base.update(time);
        }
    }
}
