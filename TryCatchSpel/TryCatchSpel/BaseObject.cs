using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchSpel
{
    public class BaseObject
    {
        protected Texture2D tex;
        protected Vector2 pos;
        protected Rectangle hitbox;
        protected Vector2 speed;

        public Texture2D Tex
        {
            get;
            private set;
        }

        public Vector2 Pos
        {
            get;
            private set;
        }

        public Rectangle Hitbox
        {
            get;
            private set;
        }

        public Vector2 Speed
        {
            get;
            private set;
        }

        public BaseObject (Texture2D tex)
        {
            this.tex = tex;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

        public virtual void Update() { }
    }
}
