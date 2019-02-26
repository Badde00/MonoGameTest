using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchSpel
{
    class Enemy1 : BaseEnemy
    {
        public override void Update()
        {
            Vector2 direction = Game1.Player.Pos - pos;
            direction.Normalize();
        }

        public Enemy1(Player p, Texture2D tex, Vector2 pos, Rectangle hitBox) : base(tex, hitBox)
        {
            player = p;
        } 
    }
}
