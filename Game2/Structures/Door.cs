﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures 
{
    class Door : Structures
    {
        private Texture2D defaultDoor;
        private int level;


        public Door(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
          
        }
        public override void Load()
        {
            defaultDoor = GameHolder.Game.Content.Load<Texture2D>("Doors/closed_door");
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public bool removeRoom(List<GameObject> items)
        {
            foreach (GameObject item in items)
            {
                items.Remove(item);wd
            }
            return true;
        }


        public int levelUp(List<GameObject> allObjects)
        {
            int x;
            int y;
            Random random = new Random();
            x = random.Next(0, 400);
            y = random.Next(0, 400);
            
            HealthBoost ranHealthBoost = new HealthBoost(60,x,y);
            allObjects.Add(ranHealthBoost);
            
            return level++;
        }

        public override void intersects(GameObject Door)
        {
            if (Door is Player.Player)
            {
                Player.Player p = (Player.Player)Door;
                if (this.Y < unit)
                {
                    p.setX(this.X);
                    p.setY(480 - unit*2);
                }
                else
                {
                    p.setX(this.X);
                    p.setY(0 + unit);
                }
                //removeRoom(room.roomList);

                //Load new level
            }
            
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultDoor, hitbox, Color.White);

        }
    }
}
