using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchSpel
{
    public enum Direction
    {
        Left, Right, Up, Down
    }
    public class Bullet:BaseObject
    {
        private Vector2 dir = Vector2.Zero;

        public override void Update()
        {
            pos += speed;
        }

        public Bullet(Vector2 tpos, Vector2 tspeed, Direction direction, bool playerOwned) : base(Game1.Game.BulletTex)
        {
            tpos = pos;
            tspeed = speed;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, Game1.Game.BulletTex.Width, Game1.Game.BulletTex.Height);

            if (direction == Direction.Down)
                dir.Y = 1;
            if (direction == Direction.Left)
                dir.X = -1;
            if (direction == Direction.Right)
                dir.X = 1;
            if (direction == Direction.Up)
                dir.Y = -1;

            speed *= dir;
        }
    }
}
