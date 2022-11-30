using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace IntroductieProject
{
    internal class Weapon : GameObject
    {
        public List<Projectile> projectiles;
        public float weaponFireRate { get; protected set; }
        public float shotSpeed { get; protected set; }
        public float projectileSize { get; protected set; }
        public float gunRange { get; protected set; }
        public int spreadStrength { get; protected set; }

        public float shootCooldown;
        public bool canShoot;
        Random random;

        public Weapon(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            projectiles = new List<Projectile>();
            canShoot = true;
            random = new Random();
        }
        public virtual void Shoot(GameTime gameTime)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(10 + 0.10 * projectileSize), (int)(10 + 0.10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, "Bullet1", gunRange));
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

            shootCooldown -= time.ElapsedGameTime.Milliseconds;
            if (shootCooldown <= 0)
            {
                canShoot = true;
            }

            foreach (Projectile p in projectiles)
                p.update(time);

            base.update(time);
        }

        internal void updatePosition(Vector2 position)
        {
            centerPosition = position;
        }

        internal override void draw(SpriteBatch batch)
        {
            foreach (Projectile p in projectiles)
                p.draw(batch);
            base.draw(batch);
        }
    }

    class Pistol : Weapon
    {
        public Pistol(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            weaponFireRate = 5;
            shotSpeed = 10;
            projectileSize = 1;
            gunRange = 600;
            spreadStrength = 5;
        }
    }

    class Sniper : Weapon
    {
        public Sniper(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            weaponFireRate = 1;
            shotSpeed = 30;
            projectileSize = 2;
            gunRange = 5000;
            spreadStrength = 0;
        }
    }

    class Shotgun : Weapon
    {
        public Shotgun(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            weaponFireRate = 0.5f;
            shotSpeed = 20;
            projectileSize = 1.5f;
            gunRange = 300;
            spreadStrength = 8;
        }

        public override void Shoot(GameTime gameTime)
        {
            if (canShoot)
            {
                for(int i = 0; i < 10; i++)
                {
                    projectiles.Add(new Projectile(centerPosition, (int)(10 * projectileSize), (int)(10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, "Bullet1", gunRange));
                }
                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }
    }

    class Minigun : Weapon
    {
        float miniGunModifier = 1;
        public Minigun(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            weaponFireRate = 1f;
            shotSpeed = 15;
            projectileSize = 1f;
            gunRange = 900;
            spreadStrength = 6;
        }

        public override void Shoot(GameTime gameTime)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(10 * projectileSize), (int)(10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, "Bullet1", gunRange));
                shootCooldown = (1 / (miniGunModifier * weaponFireRate)) * 1000;
                miniGunModifier += 0.5f;
                canShoot = false;
            }
            
            if(miniGunModifier > 10)
                miniGunModifier = 10;

            if (InputManager.isKeyJustReleased(Keys.Space))
            {
                miniGunModifier = 0.5f;
            }
        }
    }
}
