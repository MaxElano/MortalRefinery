using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Authentication;
using IntroductieProject.Code.View.GameEntities;
using System.Web;
using System.Diagnostics;

namespace IntroductieProject
{
    internal class Player : GameEntity
    {
        List<Item> items;
        List<Projectile> projectiles;
        Item item;
        Item item2;
        public float FireRate { get; protected set; }
        List<Orbital> orbitals;

        float shootCooldown;
        bool canShoot;

        public Player(Vector2 center, int width, int height, string assetName) : base (center, width, height, assetName)
        {
            projectiles = new List<Projectile>();
            items = new List<Item>();
            orbitals = new List<Orbital>();
            item = new damageUp(new Vector2(100,100), 32, 32, "damageUpSprite");
            item2 = new healthUp(new Vector2(200, 100), 32, 32, "damageUpSprite");
            orbitals.Add(new Orbital(200,new Vector2(center.X + 100, center.Y), 32, 32, 1, 10, "damageUpSprite"));
            orbitals.Add(new Orbital(300, new Vector2(center.X + 100, center.Y), 32, 32, 1, 10, "damageUpSprite"));
            orbitals.Add(new Orbital(100, new Vector2(center.X + 100, center.Y), 32, 32, 1, 10, "damageUpSprite"));
            shootCooldown = (1 / FireRate) * 1000;
            canShoot = true;
        }

        internal override void update(GameTime gameTime)
        {
            foreach (Orbital orbital in orbitals)
            {
                orbital.update(gameTime);
                orbital.updatePosition(centerPosition);
            }
            base.update(gameTime);
            
            foreach (Projectile p in projectiles)
                p.update(gameTime);
            
            shootCooldown -= gameTime.ElapsedGameTime.Milliseconds;
            if (shootCooldown <= 0)
            {
                canShoot = true;
            }

            InputHelper(gameTime);

            InputHelper();
        }

        protected void Shoot(GameTime gameTime)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, 100, 100, new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), 10, 5));
                ChangeStats(item);
                shootCooldown = (1 / FireRate) * 1000;
                canShoot = false;
            }
        }

        internal override void draw(SpriteBatch batch)
        {
            item.draw(batch);
            item2.draw(batch);
            foreach(Orbital huts in orbitals)
                huts.draw(batch);
            
            base.draw(batch);

            foreach (Projectile p in projectiles)
                p.draw(batch);
        }
        public void ChangeStats(Item item)
        {
            this.Health += item.Health;
            this.Damage += item.Damage; 
            this.MoveSpeed += item.MoveSpeed;
            this.MaxHealth += item.MaxHealth;
            //items.Add(item); bij de oncollision

            Debug.WriteLine(Health + " " + Damage + " " + MoveSpeed + " " + MaxHealth);
        }
        protected void InputHelper(GameTime gameTime)
        {
            if (InputManager.isKeyDown(Keys.Space))
            {
                Shoot(gameTime);
            }

            if (InputManager.isKeyDown(Keys.E))
            {
                orbitals.Add(new Orbital(200, new Vector2(centerPosition.X + 100, centerPosition.Y), 32, 32, 1, 10, "damageUpSprite"));
            }

            if (InputManager.isKeyDown(Keys.R))
            {
                ChangeStats(item);
            }

            if (InputManager.isKeyDown(Keys.T))
            {
                ChangeStats(item2);
            }

            if (InputManager.isKeyDown(Keys.A))
            {
                direction = new Vector2(-1, 0);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.D))
            {
                direction = new Vector2(1, 0);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.W))
            {
                direction = new Vector2(0, -1);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.S))
            {
                direction = new Vector2(0, 1);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.A) && InputManager.isKeyDown(Keys.S))
            {
                direction = new Vector2(-1, 1);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.W) && InputManager.isKeyDown(Keys.A))
            {
                direction = new Vector2(-1, -1);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.S) && InputManager.isKeyDown(Keys.D))
            {
                direction = new Vector2(1, 1);
                if (velocity == 0)
                    startMoving();
            }
            if (InputManager.isKeyDown(Keys.D) && InputManager.isKeyDown(Keys.W))
            {
                direction = new Vector2(1, -1);
                if (velocity == 0)
                    startMoving();
            }
            if (!InputManager.isKeyDown(Keys.A) && !InputManager.isKeyDown(Keys.W) && !InputManager.isKeyDown(Keys.S) && !InputManager.isKeyDown(Keys.D))
                stopMoving();
        }

    }
}
