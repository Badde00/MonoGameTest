using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TryCatchSpel
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics; //Måste göra andra kostruktorer som spelares
        SpriteBatch spriteBatch;
        Player spelare;
        private Texture2D playerTex;
        private Texture2D e1Tex;
        private Texture2D e2Tex;
        private Texture2D bulletTex;
        private List<BaseEnemy> eList;
        private List<Bullet> bList;
        private Vector2 mittISkärmen;
        private Vector2 nyFloat;
        private double tid;
        private double mindreTid;
        private bool fiende1bool;
        private static Game1 game;
        private float bulletSpeed;
        private Random r;
        private int rndInt;

        public Texture2D BulletTex
        {
            get { return bulletTex; }
            //private set;
        }

        public float BulletSpeed
        {
            get;
            private set;
        }

        private void setBulletSpeed()
        {

        }

        public static Game1 Game
        {
            get {
                if (game == null)
                    game = new Game1();
                return game;
            }
            private set { game = value; }
        }


        public static Player Player
        {
            get;
            private set;
        }

        public Vector2 MittISkärmen()
        {
            mittISkärmen.X = GraphicsDevice.Viewport.X / 2;
            mittISkärmen.Y = GraphicsDevice.Viewport.Y / 2;
            return mittISkärmen;
        }

        public void AddBullet(Bullet b)
        {
            bList.Add(b);
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public int RandomInt(int max)
        {
            rndInt = r.Next(max);
            return rndInt;
        }

        public int RandomInt(int min, int max)
        {
            rndInt = r.Next(min, max);
            return rndInt;
        }

        
        protected override void Initialize()
        {
            base.Initialize();
            spelare = new Player(playerTex, MittISkärmen());
            Player = spelare;
            eList = new List<BaseEnemy>();
            bList = new List<Bullet>();
            tid = 0;
            mindreTid = 10;
            fiende1bool = true;
            game = this;
            r = new Random();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTex = Content.Load<Texture2D>("Spelare");
            e1Tex = Content.Load<Texture2D>("Fiende1");
            e2Tex = Content.Load<Texture2D>("Fiende2");
            bulletTex = Content.Load<Texture2D>("BulletTex");
        }

        
        protected override void UnloadContent()
        {
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            spelare.Update();
            tid += gameTime.ElapsedGameTime.TotalSeconds;
            if(tid >= mindreTid)
            {
                tid -= mindreTid;
                mindreTid -= 0.2;
                
                if(fiende1bool)
                {
                    eList.Add(new Enemy1(spelare, e1Tex, new Vector2(RandomInt(GraphicsDevice.Viewport.Width), 10), new Rectangle(rndInt, 10, e1Tex.Width, e1Tex.Height)));
                }
                else
                {
                    eList.Add(new Enemy2(spelare, e1Tex, new Vector2(RandomInt(GraphicsDevice.Viewport.Width), 10), new Rectangle(rndInt, 10, e1Tex.Width, e1Tex.Height)));
                }


                fiende1bool = !fiende1bool;
            }
            foreach (BaseEnemy e in eList)
            {
                e.Update();
            }
            foreach (Bullet b in bList)
            {
                b.Update();
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spelare.Draw(spriteBatch);

            foreach(BaseEnemy e in eList)
            {
                e.Draw(spriteBatch);
            }

            foreach (Bullet b in bList)
            {
                b.Draw(spriteBatch);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }


    }
}
