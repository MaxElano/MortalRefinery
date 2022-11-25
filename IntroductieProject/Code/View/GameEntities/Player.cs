using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace IntroductieProject
{
    internal class Player : GameEntity
    {
        List<Item> items;
        Character player;
        List<Projectile> projectiles;
        Item item;
        Item item2;
        public Player(Character character, Vector2 center, int width, int height, string assetName) : base (center, width, height, assetName)
        {
            player = character;
            projectiles = new List<Projectile>();
            items = new List<Item>();
            item = new damageUp(new Vector2(100,100), 32, 32, "damageUpSprite");
            item2 = new healthUp(new Vector2(200, 100), 32, 32, "damageUpSprite");
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
            projectiles.Add(new Projectile(centerPosition, 100, 100, new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), 10, 5));
            ChangeStats(item);
        }

        internal override void draw(SpriteBatch batch)
        {
            item.draw(batch);
            item2.draw(batch);
            base.draw(batch);

            foreach (Projectile p in projectiles)
                p.draw(batch);
        }
        public void ChangeStats(Item item)
        {
            player.Health += item.Health;
            this.Damage += item.Damage; 
            this.MoveSpeed += item.MoveSpeed;
            this.MaxHealth += item.MaxHealth;
            //items.Add(item); bij de oncollision
        }
    }
}
