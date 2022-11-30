using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace IntroductieProject
{
    internal class Weapon : GameEntity
    {
        public float weaponFireRate { get; protected set; }
        public float shotSpeed { get; protected set; }
        public float projectileSize { get; protected set; }
        public float gunRange { get; protected set; }
        public int spreadStrength { get; protected set; }

        public string spriteName { get; protected set; }

        public float shootCooldown;
        public bool canShoot;
        Random random;

        public float miniGunModifier = 1;


        public Weapon(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName)
        {
            canShoot = true;
            random = new Random();
            spriteName = bulletSpriteName;
        }
        public virtual void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(10 + 0.10 * projectileSize), (int)(10 + 0.10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, spriteName, gunRange));
                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }

        public Vector2 addSpread(Vector2 bulletDestination, int spreadStrength)
        {
            int rnd;
            rnd = random.Next(-spreadStrength, spreadStrength);
            bulletDestination.X = bulletDestination.X + rnd * spreadStrength;
            bulletDestination.Y = bulletDestination.Y + rnd * spreadStrength;
            return bulletDestination;
        }

        internal override void update(GameTime time)
        {

            if (InputManager.isKeyJustReleased(Keys.Space))
            {
                miniGunModifier = 0.5f;
            }

            shootCooldown -= time.ElapsedGameTime.Milliseconds;
            if (shootCooldown <= 0)
            {
                canShoot = true;
            }

            base.update(time);
        }

        internal void updatePosition(Vector2 position)
        {
            centerPosition = position;
        }

        internal override void draw(SpriteBatch batch)
        {
            base.draw(batch);
        }
    }
}
