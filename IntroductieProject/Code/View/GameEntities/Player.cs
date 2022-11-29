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
using System.Security.Cryptography;

namespace IntroductieProject
{
    internal class Player : GameEntity
    {
        protected enum characterType
        {
            assassin, healer, warrior
        }
        protected characterType currentClass;

        List<Item> items;
        List<Projectile> projectiles;
        Item item;
        Item item2;
        public float FireRate { get; protected set; }
        List<Orbital> orbitals;

        //All variables for the normal ability
        float normalAbilityCooldownTimer;
        float normalAbilityCooldown;
        bool canNormalAbility;

        //All variables for the special ability
        float specialAbilityCooldownTimer;
        protected float specialAbilityCooldown;
        protected float specialAbilityDuration;
        float specialAbilityTimer;
        bool canSpecialAbility;
        bool specialAbilityActive;

        //All variables for the shooting function
        float shootCooldownTimer;
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

            //initializes the shooting rate and function
            shootCooldown = (1 / FireRate) * 1000;
            shootCooldownTimer = shootCooldown;
            canShoot = true;

            //initializes the normal ability. (The 10 stands for 10 seconds, the 1000 converts from seconds to milliseconds).
            normalAbilityCooldown = 10 * 1000;
            normalAbilityCooldownTimer = normalAbilityCooldown;
            canNormalAbility = true;
        }

        //Displays all player info on the console
        public void AllInfo()
        {
            Console.WriteLine("Class: " + currentClass + " MaxHealth: " + MaxHealth + " Health: " + Health + " DamageMultiplier: " + DamageMultiplier + " MoveSpeed: " + MoveSpeed + " IsAlive: " + IsAlive + " CanTakeDamage: " + CanTakeDamage);
            Console.WriteLine("ShootCooldown: " + shootCooldownTimer + " CanShoot: " + canShoot + " NormalAbilityCooldown: " + normalAbilityCooldownTimer + " CanNormalAbility: " + canNormalAbility + " SpecialAbilityCooldown: " + specialAbilityCooldownTimer + " CanSpecialAbility: " + canSpecialAbility + " SpecialAbilityDuration: " + specialAbilityTimer);
        }

        internal override void update(GameTime gameTime)
        {
            foreach (Orbital orbital in orbitals)
            {
                orbital.update(gameTime);
                orbital.updatePosition(centerPosition);
            }
            base.update(gameTime);

            //Update each projectile
            foreach (Projectile p in projectiles)
                p.update(gameTime);

            //Update the cooldown timers
            Cooldowns(gameTime);

            //Update the inputs
            InputHelper(gameTime);
        }

        protected void Shoot()
        {
            AllInfo();
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, 100, 100, new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), 10, 5));
                ChangeStats(item);
                shootCooldownTimer = shootCooldown;
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

            //Draw every projectile
            foreach (Projectile p in projectiles)
                p.draw(batch);
        }

        //Changes the player's stats when picking up an item
        public void ChangeStats(Item item)
        {
            this.Health += item.Health;
            this.DamageMultiplier += item.Damage; 
            this.MoveSpeed += item.MoveSpeed;
            this.MaxHealth += item.MaxHealth;
            //items.Add(item); bij de oncollision

            Debug.WriteLine(Health + " " + Damage + " " + MoveSpeed + " " + MaxHealth);
        }

        //Dash function for every character
        public virtual void NormalAbility()
        {
            AllInfo();
            if (canNormalAbility)
            {
                centerPosition += direction * 100;
                canNormalAbility = false;
                normalAbilityCooldownTimer = normalAbilityCooldown;
            }
        }

        //Virtual special ability for each individual character to be overridden
        public virtual void SpecialAbility()
        {
            specialAbilityActive = true;
            canSpecialAbility = false;
            specialAbilityCooldownTimer = specialAbilityCooldown;
            specialAbilityTimer = specialAbilityDuration;
            AllInfo();
        }

        //Updates the cooldown timers and handles the special ability duration
        private void Cooldowns(GameTime gameTime)
        {
            if (!canShoot)
            {
                shootCooldownTimer -= gameTime.ElapsedGameTime.Milliseconds;
                if (shootCooldownTimer <= 0)
                {
                    canShoot = true;
                }
            }

            if (!canNormalAbility)
            {
                normalAbilityCooldownTimer -= gameTime.ElapsedGameTime.Milliseconds;
                if (normalAbilityCooldownTimer <= 0)
                {
                    canNormalAbility = true;
                }
            }

            if (specialAbilityActive)
            {
                specialAbilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                if (specialAbilityTimer <= 0)
                {
                    ResetSpecialAbilities();
                }
            }

            if (!specialAbilityActive && !canSpecialAbility)
            {
                specialAbilityCooldownTimer -= gameTime.ElapsedGameTime.Milliseconds;
                if (specialAbilityCooldownTimer <= 0)
                    canSpecialAbility = true;
            }
        }

        //Resets the special abilities
        protected void ResetSpecialAbilities()
        {
            if (specialAbilityActive)
            {
                specialAbilityTimer = 0;
                specialAbilityCooldownTimer = specialAbilityCooldown;

                switch (currentClass)
                {
                    case characterType.assassin:
                        DamageMultiplier /= 2;
                        break;
                    case characterType.healer:
                        break;
                    case characterType.warrior:
                        CanTakeDamage = true;
                        break;
                }
                specialAbilityActive = false;
                AllInfo();
            }
        }

        //Helps with the inputs
        protected void InputHelper(GameTime gameTime)
        {
            if (InputManager.isKeyDown(Keys.Space))
            {
                Shoot();
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
            if (InputManager.isKeyDown(Keys.E))
                NormalAbility();
            if (InputManager.isKeyDown(Keys.Q))
                SpecialAbility();
        }

    }
}
