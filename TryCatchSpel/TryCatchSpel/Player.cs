using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchSpel
{
    public class Player:BaseObject
    {
        KeyboardState state;
        private float speedIncreaseFloat = 3f;
        private int lives = 3;


        public override void Update()
        {
            state = Keyboard.GetState();
            if (!state.IsKeyDown(Keys.W) && !state.IsKeyDown(Keys.S) && !state.IsKeyDown(Keys.A) && !state.IsKeyDown(Keys.D))
            {
                speed *= 0.7f;
            }
            if (state.IsKeyDown(Keys.W)) 
            {
                speedIncrease(true, -1);
            }
            if (state.IsKeyDown(Keys.S))
            {
                speedIncrease(true, 1);
            }
            if (state.IsKeyDown(Keys.A))
            {
                speedIncrease(false, -1);
            }
            if (state.IsKeyDown(Keys.D))
            {
                speedIncrease(false, 1);
            }

            if(state.IsKeyDown(Keys.Up))
            {
                Game1.Game.AddBullet(new Bullet( pos, new Vector2(1, 1), Direction.Up, true)); //Gör resten
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                Game1.Game.AddBullet(new Bullet( pos, new Vector2(Game1.Game.BulletSpeed, 0), true));
            }
            else if(state.IsKeyDown(Keys.Down))
            {
                Game1.Game.AddBullet(new Bullet( pos, new Vector2(0, Game1.Game.BulletSpeed), true));
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                Game1.Game.AddBullet(new Bullet( pos, new Vector2(Game1.Game.BulletSpeed * -1, 0), new Rectangle((int)pos.X, (int)pos.Y, Game1.Game.BulletTex.Width, Game1.Game.BulletTex.Height), true));
            }
                pos += speed;
        }


        private void speedIncrease(bool isY, float multiplier)
        {
            if(isY == true)
            {
                speed.Y += speedIncreaseFloat * multiplier;
            }
            else
            {
                speed.X += speedIncreaseFloat * multiplier;
            }
        }

        public Player(Texture2D tex, Vector2 pos) : base(tex)
        {
            
        }
    }
}
