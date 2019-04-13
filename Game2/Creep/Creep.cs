using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Game2.gameLogic;
using Game2.Structures;


namespace Game2.Creep
{
    class Creep : GameObject, IMediator
    {

        private Texture2D creepPicture;
        public new Rectangle hitbox;

        int moveSpeed = 3; //the speed the Creeps moves
        int HEIGHT = 32;
        int WIDTH = 32;
        public int health = 100;
        private int x;
        private int y;



       public Creep(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.hitbox = new Rectangle(this.x, this.y, WIDTH, HEIGHT);

        }




        // method for future collision for our Creeps
        public virtual void intersects(GameObject other)
        {

        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public virtual void Load()
        {
            creepPicture = GameHolder.Game.Content.Load<Texture2D>("Creeps/First_Creep");
        }


        //what should be updated
        public virtual void Update(GameTime gameTime)
        {
            Debug.WriteLine(this.x);
            this.hitbox = new Rectangle(this.x, this.y, WIDTH, HEIGHT);

        }

        // what should be drawed
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(creepPicture, hitbox, Color.White);


        }









    }


}

