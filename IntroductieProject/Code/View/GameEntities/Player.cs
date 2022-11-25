using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace IntroductieProject
{
    internal class Player : GameEntity
    {
        Character player;
        List<Projectile> projectiles;
        public Player(Character character, Vector2 center, int width, int height, string assetName) : base (center, width, height, assetName)
        {
            player = character;
            projectiles = new List<Projectile>();
        }

        internal override void update(GameTime gameTime)
        {
            base.update(gameTime);
            if (InputManager.isKeyDown(Keys.Space))
            {
                Shoot();
            }
            foreach (Projectile p in projectiles)
                p.update(gameTime);

            Console.WriteLine("IS updating");
        }

        protected void Shoot()
        {
            projectiles.Add(new Projectile(centerPosition, 100, 100, new Vector2(InputManager.MouseState.Position.X, InputManager.MouseState.Position.Y), 10, 5));
        }
    }
}
