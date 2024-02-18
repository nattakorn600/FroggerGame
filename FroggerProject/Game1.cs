using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace FroggerProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int WinWidth = 800;
        public int WinHeight = 600;

        Texture2D Background;
        Texture2D Background1;
        Texture2D Background2;
        Texture2D WaterTexture;
        Texture2D WaterTexture2;
        Texture2D Frog;
        Texture2D Scene;
        Texture2D LoadPage;

        Texture2D PlayerAnimation;
        Player player;
        Vector2 playerPosition;
        Animation playerAnimation = new Animation();

        Texture2D PlayerAnimation2;
        Player player2;
        Vector2 playerPosition2;
        Animation playerAnimation2 = new Animation();

        Animation BarrierAnimaRiverRow1;
        Animation BarrierAnimaRiverRow2;
        Animation BarrierAnimaRiverRow3;
        Animation BarrierAnimaRiverRow4;
        Animation BarrierAnimaRoadRow1;
        Animation BarrierAnimaRoadRow2;
        Animation BarrierAnimaRoadRow3;
        Animation BarrierAnimaRoadRow4;

        Vector2 positionRiverRow1;
        Vector2 positionRiverRow2;
        Vector2 positionRiverRow3;
        Vector2 positionRiverRow4;
        Vector2 positionRoadRow1;
        Vector2 positionRoadRow2;
        Vector2 positionRoadRow3;
        Vector2 positionRoadRow4;
        Vector2 Waterposition1;
        Vector2 Waterposition2;
        Vector2 Waterposition3;
        Vector2 Waterposition4;
        Vector2 PositionScene;

        Barrier barrierRiverRow1;
        Barrier barrierRiverRow2;
        Barrier barrierRiverRow3;
        Barrier barrierRiverRow4;
        Barrier barrierRoadRow1;
        Barrier barrierRoadRow2;
        Barrier barrierRoadRow3;
        Barrier barrierRoadRow4;
        Barrier WaterRow1;
        Barrier WaterRow2;
        Barrier WaterRow3;
        Barrier WaterRow4;


        KeyboardState CkeyboardState;
        KeyboardState PkeyboardState;

        Texture2D BarrierTexture;
        Texture2D BarrierTexture1;
        Texture2D BarrierTexture2;

        List<Barrier> barriersRiver1;
        List<Barrier> barriersRiver2;
        List<Barrier> barriersRiver3;
        List<Barrier> barriersRiver4;
        List<Barrier> barriersRoad1;
        List<Barrier> barriersRoad2;
        List<Barrier> barriersRoad3;
        List<Barrier> barriersRoad4;
        List<Barrier> WaterList;

        List<Player> DeadList;

        Rectangle CheckPass1;
        Rectangle CheckPass2;
        Rectangle CheckPass3;
        Rectangle CheckPass4;
        Rectangle CheckPass5;
        Rectangle rectangle2;

        SoundEffect soundJump;
        SoundEffect soundDead;
        SoundEffect soundCheckPoint;
        SoundEffect soundGameEnd;
        SoundEffect soundShoot;
        SoundEffect soundGameOver;
        Song gameplayMusic;

        SpriteFont FontLoading;
        SpriteFont FontGameReady;

        float PlayerMoveSpeed;
        bool keydownP1;
        bool keydownP2;

        int CountCheckpoint;
        int CountPoint1;
        int CountPoint2;
        int CountPoint3;
        int CountPoint4;
        int CountPoint5;
        int Percent;
        int PhaseX;

        bool ResetStatus;
        bool VictoryGame;

        int GameLevel;

        // texture ต่างๆที่ใช้ในเกม
        Texture2D VictoryTexture;
        Texture2D DefeatTexture;
        Texture2D BackgroundLastBoos;
        Texture2D AllColorBossAnimation;
        Vector2 KnifeTexture;
        Vector2 BulletTexture; // เป็นตำแหน่งกราฟิกในภาพ AllColorBossAnimation

        // ตัวอักษร
        SpriteFont font;
        SpriteFont font2;

        // ตัวแปรการเก็บค่า player และ boss ไว้ในคลาสชื่อ player เนื่องจากคุณสมบัติเบื้องต้นไม่ต่างกัน
        Player boss1;
        Player boss2;
        Player boss3;
        Player boss4;
        Player boss5;

        // ตัวแปรการสร้าง animation ของ player และ boss
        Animation VioletBoss = new Animation(); // ม่วง
        Animation OrangeBoss = new Animation(); // ส้ม
        Animation BlueBoss = new Animation(); // ฟ้า
        Animation RedBoss = new Animation(); // แดง
        Animation GreenBoss = new Animation(); // เขียว

        // สร้างกระสุน
        Barrier BulletPlayer1;
        Barrier BulletPlayer2;
        Barrier BulletBoss1;
        Barrier BulletBoss2;
        Barrier BulletBoss3;
        Barrier BulletBoss4;
        Barrier BulletBoss5;
        Barrier BulletBoss9;

        List<Barrier> barriers;
        List<Barrier> bullet;

        // ตำแหน่งของ boss บนจอ
        int BossWidth;
        int BossHeight;
        Vector2 VioletBossPosition;
        Vector2 OrangeBossPosition;
        Vector2 BlueBossPosition;
        Vector2 RedBossPosition;
        Vector2 GreenBossPosition;

        // ตำแหน่งกราฟิกของ boss บนภาพ
        Vector2 violetB;
        Vector2 orangeB;
        Vector2 blueB;
        Vector2 redB;
        Vector2 greenB;

        // ตัวแปรของ player
        int playerWidth;
        int playerHeight;
        Vector2 graphicsVectorPlayerAnimation1;  // ขึ้นบน
        Vector2 graphicsVectorPlayerAnimation2;  // ลงล่าง
        Vector2 graphicsVectorPlayerAnimation3;  // ซ้าย
        Vector2 graphicsVectorPlayerAnimation4;  // ขวา

        Vector2 game3PositionP1 = new Vector2(40, 90);
        Vector2 game3PositionP2 = new Vector2(40, 520);

        // ฟิสิกส์
        float bossMoveSpeed;
        int bulletBossSpeed;

        // กำหนดค่าต่างๆของ player และ boss
        int health;
        int countRoundState;
        int bossLive;
        int countBoss;

        // กำหนดเงื่อนไขเกม
        TimeSpan BarrierSpawnTime;
        TimeSpan previousSpawnTime;

        bool start = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WinWidth;
            graphics.PreferredBackBufferHeight = WinHeight;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            player2 = new Player();
            PlayerMoveSpeed = 50;
            keydownP1 = true;
            keydownP2 = true;

            barriersRiver1 = new List<Barrier>();
            barriersRiver2 = new List<Barrier>();
            barriersRiver3 = new List<Barrier>();
            barriersRiver4 = new List<Barrier>();
            barriersRoad1 = new List<Barrier>();
            barriersRoad2 = new List<Barrier>();
            barriersRoad3 = new List<Barrier>();
            barriersRoad4 = new List<Barrier>();
            WaterList = new List<Barrier>();
            DeadList = new List<Player>();

            CountCheckpoint = 5;
            CountPoint1 = 0;
            CountPoint2 = 0;
            CountPoint3 = 0;
            CountPoint4 = 0;
            CountPoint5 = 0;

            ResetStatus = true;
            VictoryGame = false;

            GameLevel = 1;

            boss1 = new Player();
            boss2 = new Player();
            boss3 = new Player();
            boss4 = new Player();
            boss5 = new Player();

            // player
            playerWidth = 47;
            playerHeight = 44;
            graphicsVectorPlayerAnimation1 = new Vector2(0, 0);    // บน 
            graphicsVectorPlayerAnimation2 = new Vector2(0, 50);   // ล่าง
            graphicsVectorPlayerAnimation3 = new Vector2(0, 150);  // ซ้าย
            graphicsVectorPlayerAnimation4 = new Vector2(0, 100);  // ขวา

            // boss
            BossWidth = 52;
            BossHeight = 50;
            violetB = new Vector2(200, 0);
            orangeB = new Vector2(200, 100);
            blueB = new Vector2(200, 200);
            redB = new Vector2(200, 300);
            greenB = new Vector2(200, 400);

            // กำหนดค่าต่างๆ
            PlayerMoveSpeed = 50;
            bossMoveSpeed = 2;
            bulletBossSpeed = 10;
            health = 100;
            countRoundState = 0;
            bossLive = 1;
            countBoss = 5;

            barriers = new List<Barrier>();
            bullet = new List<Barrier>();

            previousSpawnTime = TimeSpan.Zero;
            BarrierSpawnTime = TimeSpan.FromSeconds(1.0f);



            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Background1 = Content.Load<Texture2D>("bg1");
            Background2 = Content.Load<Texture2D>("bg2");

            WaterTexture = Content.Load<Texture2D>("Water");
            WaterTexture2 = Content.Load<Texture2D>("Water2");
            Scene = Content.Load<Texture2D>("Scene");
            PositionScene = new Vector2(-Scene.Width, 0);
            LoadPage = Content.Load<Texture2D>("Loading");

            BarrierTexture1 = Content.Load<Texture2D>("objP1");
            BarrierTexture2 = Content.Load<Texture2D>("objP2");
            Frog = Content.Load<Texture2D>("frog1");

            PlayerAnimation = Content.Load<Texture2D>("PlaAni");
            playerAnimation.Initialize(PlayerAnimation, Vector2.Zero, playerWidth, playerHeight, 1, 50, Color.White, 1f, true, false);
            playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.TitleSafeArea.Width / 4, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height - 60);

            PlayerAnimation2 = Content.Load<Texture2D>("PlaAni2");
            playerAnimation2.Initialize(PlayerAnimation2, Vector2.Zero, playerWidth, playerHeight, 1, 50, Color.White, 1f, true, false);
            playerPosition2 = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.TitleSafeArea.Width * 3 / 4, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height - 60);


            player.Initialize(playerAnimation, playerPosition, 3, health);
            player2.Initialize(playerAnimation2, playerPosition2, 3, health);


            gameplayMusic = Content.Load<Song>("sound/MusicGame");
            soundJump = Content.Load<SoundEffect>("sound/Jump");
            soundDead = Content.Load<SoundEffect>("sound/Dead");
            soundCheckPoint = Content.Load<SoundEffect>("sound/GameCheckPoint");
            soundGameEnd = Content.Load<SoundEffect>("sound/GameEnd");

            soundShoot = Content.Load<SoundEffect>("sound/Shoot");
            soundGameOver = Content.Load<SoundEffect>("sound/GameOver");

            FontLoading = Content.Load<SpriteFont>("FontLoading");
            FontGameReady = Content.Load<SpriteFont>("FontGameReady");


            // ของกูววววววววววววววววววววววววววววววววววววววว
            VictoryTexture = Content.Load<Texture2D>("victory");
            DefeatTexture = Content.Load<Texture2D>("GameOver");
            font = Content.Load<SpriteFont>("gameFont");
            font2 = Content.Load<SpriteFont>("gameFont2");
            BackgroundLastBoos = Content.Load<Texture2D>("backgroundLastBoss");
            AllColorBossAnimation = Content.Load<Texture2D>("AllColorTank2");
            BulletTexture = new Vector2(400, 0);
            KnifeTexture = new Vector2(500, 0);


            VioletBoss.Initialize(AllColorBossAnimation, violetB, BossWidth, BossHeight, 1, 1, Color.White, 1f, true, true);
            VioletBossPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 30, GraphicsDevice.Viewport.TitleSafeArea.Y + 90);
            boss1.Initialize(VioletBoss, VioletBossPosition, bossLive, health);  // เลข 2 ตัวหลังกุเพิ่มชีวิตกับเลือด


            OrangeBoss.Initialize(AllColorBossAnimation, orangeB, BossWidth, BossHeight, 1, 1, Color.White, 1f, true, true);
            OrangeBossPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 160 + 30, GraphicsDevice.Viewport.TitleSafeArea.Y + 90);
            boss2.Initialize(OrangeBoss, OrangeBossPosition, bossLive, health);  // เลข 2 ตัวหลังกุเพิ่มชีวิตกับเลือด


            BlueBoss.Initialize(AllColorBossAnimation, blueB, BossWidth, BossHeight, 1, 1, Color.White, 1f, true, true);
            BlueBossPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 320 + 30, GraphicsDevice.Viewport.TitleSafeArea.Y + 90);
            boss3.Initialize(BlueBoss, BlueBossPosition, bossLive, health);  // เลข 2 ตัวหลังกุเพิ่มชีวิตกับเลือด


            RedBoss.Initialize(AllColorBossAnimation, redB, BossWidth, BossHeight, 1, 1, Color.White, 1f, true, true);
            RedBossPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 480 + 30, GraphicsDevice.Viewport.TitleSafeArea.Y + 90);
            boss4.Initialize(RedBoss, RedBossPosition, bossLive, health);  // เลข 2 ตัวหลังกุเพิ่มชีวิตกับเลือด

            GreenBoss.Initialize(AllColorBossAnimation, greenB, BossWidth, BossHeight, 1, 1, Color.White, 1f, true, true);
            GreenBossPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 640 + 30, GraphicsDevice.Viewport.TitleSafeArea.Y + 90);
            boss5.Initialize(GreenBoss, GreenBossPosition, bossLive, health);  // เลข 2 ตัวหลังกุเพิ่มชีวิตกับเลือด


            PlayMusic(gameplayMusic);
        }

        private void PlayMusic(Song song)
        {
            try
            {
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true;
            }
            catch { }
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            PkeyboardState = CkeyboardState;
            CkeyboardState = Keyboard.GetState();

            UpdateGameLevel();
            UpdatePlayer(gameTime);
            player.Update(gameTime);
            player2.Update(gameTime);
            if (GameLevel == 1 || GameLevel == 2)
            {
                UpdateCollision();
                UpdateBarriers(gameTime);
            }
            if (GameLevel == 3 && start)
            {

                boss1.Update(gameTime);
                boss2.Update(gameTime);
                boss3.Update(gameTime);
                boss4.Update(gameTime);
                boss5.Update(gameTime);

                UpdateMoveBoss(gameTime);
                UpdateBulletBoss(gameTime);
                PlayerBossBulletCrashed();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            if (GameLevel == 1 || GameLevel == 2)
            {
                for (int i = 0; i < WaterList.Count; i++)
                {
                    WaterList[i].Draw(spriteBatch);
                }

                for (int i = 0; i < barriersRiver1.Count; i++)
                {
                    barriersRiver1[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRiver2.Count; i++)
                {
                    barriersRiver2[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRiver3.Count; i++)
                {
                    barriersRiver3[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRiver4.Count; i++)
                {
                    barriersRiver4[i].Draw(spriteBatch);
                }

                for (int i = 0; i < barriersRoad1.Count; i++)
                {
                    barriersRoad1[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRoad2.Count; i++)
                {
                    barriersRoad2[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRoad3.Count; i++)
                {
                    barriersRoad3[i].Draw(spriteBatch);
                }
                for (int i = 0; i < barriersRoad4.Count; i++)
                {
                    barriersRoad4[i].Draw(spriteBatch);
                }
                for (int i = 0; i < DeadList.Count; i++)
                {
                    DeadList[i].Draw(spriteBatch);
                }
            }
            if (GameLevel == 3)
            {
                for (int i = 0; i < bullet.Count; i++) // วาดกระสุน
                {
                    bullet[i].Draw(spriteBatch);
                }
            }

            if (GameLevel == 1)  // วาดเวลาเข้าเช็กพ้อยต์
            {
                if (CountPoint1 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(32, 20), Color.White);
                }
                if (CountPoint2 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(204, 20), Color.White);
                }
                if (CountPoint3 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(377, 20), Color.White);
                }
                if (CountPoint4 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(548, 20), Color.White);
                }
                if (CountPoint5 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(719, 20), Color.White);
                }
            }
            if (GameLevel == 2)
            {
                if (CountPoint1 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(57, 22), Color.White);
                }
                if (CountPoint2 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(216, 22), Color.White);
                }
                if (CountPoint3 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(376, 22), Color.White);
                }
                if (CountPoint4 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(537, 22), Color.White);
                }
                if (CountPoint5 == 1)
                {
                    spriteBatch.Draw(Frog, new Vector2(697, 22), Color.White);
                }
            }
            if (GameLevel == 3)
            {
                boss1.Draw(spriteBatch);  // วาดภาพตรงนี้
                boss2.Draw(spriteBatch);  // วาดภาพตรงนี้
                boss3.Draw(spriteBatch);  // วาดภาพตรงนี้
                boss4.Draw(spriteBatch);  // วาดภาพตรงนี้
                boss5.Draw(spriteBatch);  // วาดภาพตรงนี้               
            }

            spriteBatch.DrawString(font2, "L1 : " + player.Live, new Vector2(5, 565), Color.White);
            spriteBatch.DrawString(font2, " H1 : " + player.Health, new Vector2(75, 565), Color.White);
            spriteBatch.DrawString(font2, "L2 : " + player2.Live, new Vector2(200, 565), Color.White);
            spriteBatch.DrawString(font2, "| H2 : " + player2.Health, new Vector2(275, 565), Color.White);
            spriteBatch.DrawString(font2, "Boss : " + countBoss, new Vector2(680, 565), Color.White);

            player.Draw(spriteBatch);
            player2.Draw(spriteBatch);

            if (ResetStatus)
            {
                if (countRoundState == 0)
                {
                    if (GameLevel == 1 || GameLevel == 2 || GameLevel == 3)
                    {
                        spriteBatch.Draw(Scene, PositionScene, Color.White);
                        spriteBatch.Draw(LoadPage, Vector2.Zero, Color.White);
                        if (Percent <= 100)
                        {
                            spriteBatch.DrawString(FontLoading, Percent + " %   Loading . . .", new Vector2(315, 420), Color.White);
                        }
                        if (Percent == 101)
                        {
                            spriteBatch.DrawString(FontGameReady, "Press Enter when you're ready.", new Vector2(265, 420), Color.White);
                        }
                    }
                }
                if (countRoundState == 1)
                {
                    if (GameLevel == 1 || GameLevel == 2 || GameLevel == 3)
                    {
                        spriteBatch.Draw(Scene, PositionScene, Color.White);
                        spriteBatch.Draw(DefeatTexture, Vector2.Zero, Color.White);
                        if (Percent <= 100)
                        {
                            spriteBatch.DrawString(FontLoading, Percent + " %   Loading . . .", new Vector2(315, 540), Color.White);
                        }
                        if (Percent == 101)
                        {
                            spriteBatch.DrawString(FontGameReady, "Press Enter when you're ready.", new Vector2(265, 540), Color.White);
                        }
                    }
                }
            }
            if (VictoryGame)
            {
                spriteBatch.Draw(LoadPage, Vector2.Zero, Color.White);
                spriteBatch.Draw(VictoryTexture, new Vector2(30, 30), Color.White);
                spriteBatch.DrawString(FontGameReady, "Press Enter when you want to play again.", new Vector2(265, 540), Color.White);
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void UpdateGameLevel()
        {
            if (CountCheckpoint <= 0)
            {
                GameLevel++;
                ResetStatus = true;
                countRoundState = 0;
                player.Active = true;
                player2.Active = true;
                player.Health = health;
                player.Live = 3;
                player2.Health = health;
                player2.Live = 3;
            }
            if (ResetStatus)
            {
                PositionScene.X++;
                PhaseX = (int)PositionScene.X++;
                if (PhaseX >= 0)
                {
                    Percent = (PhaseX / 8);
                }
                if (Percent > 100)
                {
                    Percent = 101;
                }
                CountCheckpoint = 5;
                CountPoint1 = 0;
                CountPoint2 = 0;
                CountPoint3 = 0;
                CountPoint3 = 0;
                CountPoint4 = 0;
                CountPoint5 = 0;
            }
            if (GameLevel == 1)
            {
                Background = Background1;
                BarrierTexture = BarrierTexture1;
            }
            else if (GameLevel == 2)
            {
                Background = Background2;
                WaterTexture = WaterTexture2;
                BarrierTexture = BarrierTexture2;
            }
            else if (GameLevel == 3)
            {
                Background = BackgroundLastBoos;
            }
        }
        private void UpdatePlayer(GameTime gameTime)
        {
            if (ResetStatus && Percent == 101)
            {
                if (CkeyboardState.IsKeyDown(Keys.Enter) || PkeyboardState.IsKeyDown(Keys.Enter))
                {
                    ResetStatus = false;
                    PositionScene.X = -Scene.Width;
                    PhaseX = 0;
                    Percent = 0;
                    if (GameLevel == 3)
                    {
                        start = true;
                    }
                }
            }
            if (VictoryGame)
            {
                if (CkeyboardState.IsKeyDown(Keys.Enter) || PkeyboardState.IsKeyDown(Keys.Enter))
                {
                    ResetStatus = false;
                }
            }
            if (ResetStatus == false)
            {
                if (GameLevel == 1 || GameLevel == 2)
                {
                    if (player.Active)
                    {
                        if (keydownP1)
                        {
                            if (CkeyboardState.IsKeyDown(Keys.A) && PkeyboardState.IsKeyDown(Keys.A))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.X -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.D) && PkeyboardState.IsKeyDown(Keys.D))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.X += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }

                            if (CkeyboardState.IsKeyDown(Keys.W) && PkeyboardState.IsKeyDown(Keys.W))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.Y -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.S) && PkeyboardState.IsKeyDown(Keys.S))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 50), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.Y += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }
                        }
                    }
                    if (player2.Active)
                    {
                        if (keydownP2)
                        {
                            if (CkeyboardState.IsKeyDown(Keys.Left) && PkeyboardState.IsKeyDown(Keys.Left))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.X -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.Right) && PkeyboardState.IsKeyDown(Keys.Right))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.X += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }

                            if (CkeyboardState.IsKeyDown(Keys.Up) && PkeyboardState.IsKeyDown(Keys.Up))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.Y -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.Down) && PkeyboardState.IsKeyDown(Keys.Down))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 50), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.Y += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }
                        }
                    }
                }
                if (GameLevel == 3)
                {
                    if (player.Active)
                    {
                        if (keydownP1)
                        {
                            if (CkeyboardState.IsKeyDown(Keys.A) && PkeyboardState.IsKeyDown(Keys.A))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.X -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.D) && PkeyboardState.IsKeyDown(Keys.D))
                            {
                                playerAnimation.Initialize(PlayerAnimation, new Vector2(50, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player.Position.X += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP1 = false;
                            }
                        }
                    }
                    if (player2.Active)
                    {
                        if (keydownP2)
                        {
                            if (CkeyboardState.IsKeyDown(Keys.Left) && PkeyboardState.IsKeyDown(Keys.Left))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.X -= PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }
                            if (CkeyboardState.IsKeyDown(Keys.Right) && PkeyboardState.IsKeyDown(Keys.Right))
                            {
                                playerAnimation2.Initialize(PlayerAnimation2, new Vector2(50, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                                player2.Position.X += PlayerMoveSpeed;
                                soundJump.Play();
                                keydownP2 = false;
                            }
                        }
                    }
                }
                if (GameLevel == 1 || GameLevel == 2)
                {
                    if (CkeyboardState.IsKeyUp(Keys.A) && PkeyboardState.IsKeyDown(Keys.A))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.D) && PkeyboardState.IsKeyDown(Keys.D))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }

                    if (CkeyboardState.IsKeyUp(Keys.W) && PkeyboardState.IsKeyDown(Keys.W))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.S) && PkeyboardState.IsKeyDown(Keys.S))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 50), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }

                    if (CkeyboardState.IsKeyUp(Keys.Left) && PkeyboardState.IsKeyDown(Keys.Left))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 150), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.Right) && PkeyboardState.IsKeyDown(Keys.Right))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 100), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }

                    if (CkeyboardState.IsKeyUp(Keys.Up) && PkeyboardState.IsKeyDown(Keys.Up))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.Down) && PkeyboardState.IsKeyDown(Keys.Down))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 50), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }
                }
                if (GameLevel == 3)
                {
                    if (CkeyboardState.IsKeyUp(Keys.A) && PkeyboardState.IsKeyDown(Keys.A))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.D) && PkeyboardState.IsKeyDown(Keys.D))
                    {
                        playerAnimation.Initialize(PlayerAnimation, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP1 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.Left) && PkeyboardState.IsKeyDown(Keys.Left))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }
                    if (CkeyboardState.IsKeyUp(Keys.Right) && PkeyboardState.IsKeyDown(Keys.Right))
                    {
                        playerAnimation2.Initialize(PlayerAnimation2, new Vector2(0, 0), 50, 50, 1, 5, Color.White, 1f, true, true);
                        keydownP2 = true;
                    }
                }
                player.Position.X = MathHelper.Clamp(player.Position.X, player.Width / 2, WinWidth - player.Width / 2);
                player.Position.Y = MathHelper.Clamp(player.Position.Y, player.Height / 2 + 15, WinHeight - player.Height / 2 - 35);
                player2.Position.X = MathHelper.Clamp(player2.Position.X, player2.Width / 2, WinWidth - player2.Width / 2);
                player2.Position.Y = MathHelper.Clamp(player2.Position.Y, player2.Height / 2 + 15, WinHeight - player2.Height / 2 - 35);
            }
        }

        private void RiverRow1()
        {
            BarrierAnimaRiverRow1 = new Animation();
            BarrierAnimaRiverRow2 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRiverRow1.Initialize(BarrierTexture, new Vector2(0, 150), 323, 50, 1, 1, Color.White, 1f, true, true);
                positionRiverRow1 = new Vector2(-BarrierAnimaRiverRow1.FrameWidth, 50 + 40);
                barrierRiverRow1 = new Barrier();
                barrierRiverRow1.Initialize(BarrierAnimaRiverRow1, positionRiverRow1, 2f, 0, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRiverRow1.Initialize(BarrierTexture, new Vector2(0, 250), 70, 50, 5, 30, Color.White, 1f, true, false);
                positionRiverRow1 = new Vector2(-BarrierAnimaRiverRow1.FrameWidth, 50 + 40);
                barrierRiverRow1 = new Barrier();
                barrierRiverRow1.Initialize(BarrierAnimaRiverRow1, positionRiverRow1, 3f, 0, 1);
            }
            barriersRiver1.Add(barrierRiverRow1);
        }
        private void RiverRow2()
        {
            BarrierAnimaRiverRow2 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRiverRow2.Initialize(BarrierTexture, new Vector2(0, 300), 52, 50, 2, 30, Color.White, 1f, true, false);
                positionRiverRow2 = new Vector2(800 + BarrierAnimaRiverRow2.FrameWidth / 2, 100 + 40);
                barrierRiverRow2 = new Barrier();
                barrierRiverRow2.Initialize(BarrierAnimaRiverRow2, positionRiverRow2, -3.5f, 0, 1);

            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRiverRow2.Initialize(BarrierTexture, new Vector2(0, 450), 160, 50, 1, 30, Color.White, 1f, true, true);
                positionRiverRow2 = new Vector2(800 + BarrierAnimaRiverRow2.FrameWidth / 2, 100 + 40);
                barrierRiverRow2 = new Barrier();
                barrierRiverRow2.Initialize(BarrierAnimaRiverRow2, positionRiverRow2, -6f, 0, 1);
            }
            barriersRiver2.Add(barrierRiverRow2);
        }
        private void RiverRow3()
        {
            BarrierAnimaRiverRow3 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRiverRow3.Initialize(BarrierTexture, new Vector2(301, 100), 156, 50, 1, 1, Color.White, 1f, true, true);
                positionRiverRow3 = new Vector2(-BarrierAnimaRiverRow3.FrameWidth, 150 + 40);
                barrierRiverRow3 = new Barrier();
                barrierRiverRow3.Initialize(BarrierAnimaRiverRow3, positionRiverRow3, 3f, 0, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRiverRow3.Initialize(BarrierTexture, new Vector2(0, 250), 70, 50, 5, 30, Color.White, 1f, true, false);
                positionRiverRow3 = new Vector2(-BarrierAnimaRiverRow3.FrameWidth, 150 + 40);
                barrierRiverRow3 = new Barrier();
                barrierRiverRow3.Initialize(BarrierAnimaRiverRow3, positionRiverRow3, 5f, 0, 1);
            }
            barriersRiver3.Add(barrierRiverRow3);
        }
        private void RiverRow4()
        {
            BarrierAnimaRiverRow4 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRiverRow4.Initialize(BarrierTexture, new Vector2(0, 300), 52, 50, 2, 30, Color.White, 1f, true, false);
                positionRiverRow4 = new Vector2(800 + BarrierAnimaRiverRow4.FrameWidth / 2, 200 + 40);
                barrierRiverRow4 = new Barrier();
                barrierRiverRow4.Initialize(BarrierAnimaRiverRow4, positionRiverRow4, -2f, 0, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRiverRow4.Initialize(BarrierTexture, new Vector2(0, 400), 220, 50, 1, 30, Color.White, 1f, true, true);
                positionRiverRow4 = new Vector2(800 + BarrierAnimaRiverRow4.FrameWidth / 2, 200 + 40);
                barrierRiverRow4 = new Barrier();
                barrierRiverRow4.Initialize(BarrierAnimaRiverRow4, positionRiverRow4, -4f, 0, 1);
            }
            barriersRiver4.Add(barrierRiverRow4);
        }
        private void RoadRow1()
        {
            BarrierAnimaRoadRow1 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRoadRow1.Initialize(BarrierTexture, new Vector2(135, 400), 217, 50, 1, 1, Color.White, 1f, true, true);
                positionRoadRow1 = new Vector2(800 + BarrierAnimaRoadRow1.FrameWidth / 2, 300 + 40);
                barrierRoadRow1 = new Barrier();
                barrierRoadRow1.Initialize(BarrierAnimaRoadRow1, positionRoadRow1, -2.2f, 20, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRoadRow1.Initialize(BarrierTexture, new Vector2(0, 0), 110, 50, 1, 30, Color.White, 1f, true, true);
                positionRoadRow1 = new Vector2(-BarrierAnimaRoadRow1.FrameWidth, 300 + 40);
                barrierRoadRow1 = new Barrier();
                barrierRoadRow1.Initialize(BarrierAnimaRoadRow1, positionRoadRow1, 7f, 20, 1);
            }
            barriersRoad1.Add(barrierRoadRow1);
        }     
        private void RoadRow2()
        {
            BarrierAnimaRoadRow2 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRoadRow2.Initialize(BarrierTexture, new Vector2(96 * 3, 0), 96, 50, 1, 1, Color.White, 1f, true, true);
                positionRoadRow2 = new Vector2(800 + BarrierAnimaRoadRow2.FrameWidth / 2, 350 + 40);
                barrierRoadRow2 = new Barrier();
                barrierRoadRow2.Initialize(BarrierAnimaRoadRow2, positionRoadRow2, -4.5f, 20, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRoadRow2.Initialize(BarrierTexture, new Vector2(0, 150), 270, 50, 1, 30, Color.White, 1f, true, true);
                positionRoadRow2 = new Vector2(800 + BarrierAnimaRoadRow2.FrameWidth / 2, 350 + 40);
                barrierRoadRow2 = new Barrier();
                barrierRoadRow2.Initialize(BarrierAnimaRoadRow2, positionRoadRow2, -2.5f, 20, 1);
            }
            barriersRoad2.Add(barrierRoadRow2);
        }
        private void RoadRow3()
        {
            BarrierAnimaRoadRow3 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRoadRow3.Initialize(BarrierTexture, new Vector2(96, 0), 96, 50, 10, 22, Color.White, 1f, true, true);
                positionRoadRow3 = new Vector2(-BarrierAnimaRoadRow3.FrameWidth, 400 + 40);
                barrierRoadRow3 = new Barrier();
                barrierRoadRow3.Initialize(BarrierAnimaRoadRow3, positionRoadRow3, 3.5f, 20, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRoadRow3.Initialize(BarrierTexture, new Vector2(220, 0), 110, 50, 1, 30, Color.White, 1f, true, true);
                positionRoadRow3 = new Vector2(-BarrierAnimaRoadRow3.FrameWidth, 400 + 40);
                barrierRoadRow3 = new Barrier();
                barrierRoadRow3.Initialize(BarrierAnimaRoadRow3, positionRoadRow3, 5f, 20, 1);
            }
            barriersRoad3.Add(barrierRoadRow3);
        }
        private void RoadRow4()
        {
            BarrierAnimaRoadRow4 = new Animation();
            if (GameLevel == 1)
            {
                BarrierAnimaRoadRow4.Initialize(BarrierTexture, new Vector2(0, 50), 96, 50, 1, 1, Color.White, 1f, true, true);
                positionRoadRow4 = new Vector2(-BarrierAnimaRoadRow4.FrameWidth, 450 + 40);
                barrierRoadRow4 = new Barrier();
                barrierRoadRow4.Initialize(BarrierAnimaRoadRow4, positionRoadRow4, 2.5f, 20, 1);
            }
            else if (GameLevel == 2)
            {
                BarrierAnimaRoadRow4.Initialize(BarrierTexture, new Vector2(270, 150), 100, 50, 1, 30, Color.White, 1f, true, true);
                positionRoadRow4 = new Vector2(800 + BarrierAnimaRoadRow4.FrameWidth, 450 + 40);
                barrierRoadRow4 = new Barrier();
                barrierRoadRow4.Initialize(BarrierAnimaRoadRow4, positionRoadRow4, -6f, 20, 1);
            }
            barriersRoad4.Add(barrierRoadRow4);
        }

        private void Water1()
        {

            Animation WaterAnimation = new Animation();
            WaterAnimation.Initialize(WaterTexture, new Vector2(0, 0), 1, 50, 1, 30, Color.White, 1f, true, true);
            Waterposition1 = new Vector2(0, 50 + 40);
            WaterRow1 = new Barrier();
            WaterRow1.Initialize(WaterAnimation, Waterposition1, barrierRiverRow1.BarrierMoveSpeed, 0, 1);
            WaterList.Add(WaterRow1);

        }
        private void Water2()
        {

            Animation WaterAnimation = new Animation();
            WaterAnimation.Initialize(WaterTexture, new Vector2(0, 0), 1, 50, 1, 40, Color.White, 1f, true, true);
            Waterposition2 = new Vector2(800, 100 + 40);
            WaterRow2 = new Barrier();
            WaterRow2.Initialize(WaterAnimation, Waterposition2, barrierRiverRow2.BarrierMoveSpeed, 0, 1);
            WaterList.Add(WaterRow2);

        }
        private void Water3()
        {

            Animation WaterAnimation = new Animation();
            WaterAnimation.Initialize(WaterTexture, new Vector2(0, 0), 1, 50, 1, 30, Color.White, 1f, true, true);
            Waterposition3 = new Vector2(0, 150 + 40);
            WaterRow3 = new Barrier();
            WaterRow3.Initialize(WaterAnimation, Waterposition3, barrierRiverRow3.BarrierMoveSpeed, 0, 1);
            WaterList.Add(WaterRow3);

        }
        private void Water4()
        {

            Animation WaterAnimation = new Animation();
            WaterAnimation.Initialize(WaterTexture, new Vector2(0, 0), 1, 50, 1, 30, Color.White, 1f, true, true);
            Waterposition4 = new Vector2(800, 200 + 40);
            WaterRow4 = new Barrier();
            WaterRow4.Initialize(WaterAnimation, Waterposition4, barrierRiverRow4.BarrierMoveSpeed, 0, 1);
            WaterList.Add(WaterRow4);
        }
        private void PlayerDead()
        {
            Animation DeadAnima = new Animation();
            DeadAnima.Initialize(BarrierTexture1, new Vector2(0, 450), 49, 50, 6, 20, Color.White, 1f, true, false);
            Vector2 PositionDead = new Vector2(player.Position.X, player.Position.Y);
            Player Dead = new Player();
            Dead.Initialize(DeadAnima, PositionDead, player.Live, player.Health);
            DeadList.Add(Dead);
        }
        private void PlayerDead2()
        {
            Animation DeadAnima = new Animation();
            DeadAnima.Initialize(BarrierTexture1, new Vector2(0, 450), 49, 50, 6, 20, Color.White, 1f, true, false);
            Vector2 PositionDead = new Vector2(player2.Position.X, player2.Position.Y);
            Player Dead = new Player();
            Dead.Initialize(DeadAnima, PositionDead, player2.Live, player2.Health);
            DeadList.Add(Dead);
        }

        private void UpdateBarriers(GameTime gameTime)
        {
            int SpawnTime = 0;
            SpawnTime += (int)gameTime.TotalGameTime.TotalMilliseconds;
            if (GameLevel == 1)
            {
                if (SpawnTime % 3500 == 0)
                {
                    RiverRow1();
                }
                if (SpawnTime % 3500 > 700 && SpawnTime % 3500 < 1750)
                {
                    Water1();
                }

                if (SpawnTime % 2000 == 0 || SpawnTime % 2000 == 250)
                {
                    RiverRow2();
                }
                if (SpawnTime % 2000 < 2000 && SpawnTime % 2000 > 700)
                {
                    Water2();
                }

                if (SpawnTime % 2000 == 0)
                {
                    RiverRow3();
                }
                if (SpawnTime % 2000 < 200 || SpawnTime % 2000 > 1450)
                {
                    Water3();
                }

                if (SpawnTime % 2500 == 0 || SpawnTime % 2500 == 400 || SpawnTime % 2500 == 800)
                {
                    RiverRow4();
                }
                if (SpawnTime % 2500 < 2400 && SpawnTime % 2500 > 1600)
                {
                    Water4();
                }

                if (SpawnTime % 4500 == 0)
                {
                    RoadRow1();
                }
                if (SpawnTime % 3000 == 0)
                {
                    RoadRow2();
                }
                if (SpawnTime % 2500 == 0)
                {
                    RoadRow3();
                }
                if (SpawnTime % 3500 == 0)
                {
                    RoadRow4();
                }
            }
            if (GameLevel == 2)
            {
                if (SpawnTime % 2500 == 0 || SpawnTime % 2500 == 400 || SpawnTime % 2500 == 800)
                {
                    RiverRow1();
                }
                if (SpawnTime % 2500 > 1400 && SpawnTime % 2500 <= 2350)
                {
                    Water1();
                }

                if (SpawnTime % 1100 == 0)
                {
                    RiverRow2();
                }
                if (SpawnTime % 1100 < 1100 && SpawnTime % 1100 > 550)
                {
                    Water2();
                }

                if (SpawnTime % 1500 == 0 || SpawnTime % 1500 == 250)
                {
                    RiverRow3();
                }
                if (SpawnTime % 1500 > 600 && SpawnTime % 1500 <= 1400)
                {
                    Water3();
                }

                if (SpawnTime % 1900 == 0)
                {
                    RiverRow4();
                }
                if (SpawnTime % 1900 > 1100 && SpawnTime % 1900 < 1900)
                {
                    Water4();
                }

                if (SpawnTime % 750 == 0)
                {
                    RoadRow1();
                }
                if (SpawnTime % 3500 == 0)
                {
                    RoadRow2();
                }
                if (SpawnTime % 1500 == 0)
                {
                    RoadRow3();
                }
                if (SpawnTime % 1000 == 0)
                {
                    RoadRow4();
                }
            }

            for (int i = barriersRiver1.Count - 1; i >= 0; i--)
            {
                barriersRiver1[i].Update(gameTime);
                if (barriersRiver1[i].Active == false)
                {
                    barriersRiver1.RemoveAt(i);
                }
            }
            for (int i = barriersRiver2.Count - 1; i >= 0; i--)
            {
                barriersRiver2[i].Update(gameTime);
                if (barriersRiver2[i].Active == false)
                {
                    barriersRiver2.RemoveAt(i);
                }
            }
            for (int i = barriersRiver3.Count - 1; i >= 0; i--)
            {
                barriersRiver3[i].Update(gameTime);
                if (barriersRiver3[i].Active == false)
                {
                    barriersRiver3.RemoveAt(i);
                }
            }
            for (int i = barriersRiver4.Count - 1; i >= 0; i--)
            {
                barriersRiver4[i].Update(gameTime);
                if (barriersRiver4[i].Active == false)
                {
                    barriersRiver4.RemoveAt(i);
                }
            }
            for (int i = barriersRoad1.Count - 1; i >= 0; i--)
            {
                barriersRoad1[i].Update(gameTime);
                if (barriersRoad1[i].Active == false)
                {
                    barriersRoad1.RemoveAt(i);
                }
            }
            for (int i = barriersRoad2.Count - 1; i >= 0; i--)
            {
                barriersRoad2[i].Update(gameTime);
                if (barriersRoad2[i].Active == false)
                {
                    barriersRoad2.RemoveAt(i);
                }
            }
            for (int i = barriersRoad3.Count - 1; i >= 0; i--)
            {
                barriersRoad3[i].Update(gameTime);
                if (barriersRoad3[i].Active == false)
                {
                    barriersRoad3.RemoveAt(i);
                }
            }
            for (int i = barriersRoad4.Count - 1; i >= 0; i--)
            {
                barriersRoad4[i].Update(gameTime);
                if (barriersRoad4[i].Active == false)
                {
                    barriersRoad4.RemoveAt(i);
                }
            }
            for (int i = WaterList.Count - 1; i >= 0; i--)
            {
                WaterList[i].Update(gameTime);

                if (WaterList[i].Active == false)
                {
                    WaterList.RemoveAt(i);
                }
            }
            for (int i = DeadList.Count - 1; i >= 0; i--)
            {
                DeadList[i].Update(gameTime);
                if (DeadList[i].PlayerAnimation.currentFrameWidth == DeadList[i].PlayerAnimation.frameCount - 1)
                {
                    DeadList[i].Active = false;
                }
                if (DeadList[i].Active == false)
                {
                    DeadList.RemoveAt(i);
                }
            }
        }
        private void UpdateCollision()
        {
            Rectangle rectangleP1;
            Rectangle rectangleP2;
            Rectangle CheckDead;

            rectangleP1 = new Rectangle((int)player.Position.X + 12, (int)player.Position.Y + 12, player.Width - 12, player.Height - 12);
            rectangleP2 = new Rectangle((int)player2.Position.X + 12, (int)player2.Position.Y + 12, player2.Width - 12, player2.Height - 12);
            if (GameLevel == 1)
            {
                CheckPass1 = new Rectangle(61, 0, 30, 65);
                CheckPass2 = new Rectangle(236, 0, 30, 65);
                CheckPass3 = new Rectangle(415, 0, 30, 65);
                CheckPass4 = new Rectangle(587, 0, 30, 65);
                CheckPass5 = new Rectangle(768, 0, 10, 65);
            }
            else if (GameLevel == 2)
            {
                CheckPass1 = new Rectangle(107, 0, 10, 65);
                CheckPass2 = new Rectangle(266, 0, 10, 65);
                CheckPass3 = new Rectangle(430, 0, 10, 65);
                CheckPass4 = new Rectangle(587, 0, 10, 65);
                CheckPass5 = new Rectangle(745, 0, 10, 65);
            }

            CheckDead = new Rectangle(0, 0, 800, 65);


            if (rectangleP1.Intersects(CheckPass1) || rectangleP2.Intersects(CheckPass1))
            {
                if (CountPoint1 <= 0)
                {
                    CountPoint1++;
                    CountCheckpoint--;
                    soundCheckPoint.Play();
                }
                else
                {
                    if (rectangleP1.Intersects(CheckPass1))
                    {
                        PlayerDead();
                        player.Health -= 25;

                    }
                    else if (rectangleP2.Intersects(CheckPass1))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                    }
                    soundDead.Play();
                }
                if (rectangleP1.Intersects(CheckPass1))
                {
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckPass1))
                {
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }
            else if (rectangleP1.Intersects(CheckPass2) || rectangleP2.Intersects(CheckPass2))
            {
                if (CountPoint2 <= 0)
                {
                    CountPoint2++;
                    CountCheckpoint--;
                    soundCheckPoint.Play();
                }
                else
                {
                    if (rectangleP1.Intersects(CheckPass2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                    }
                    else if (rectangleP2.Intersects(CheckPass2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                    }
                    soundDead.Play();
                }
                if (rectangleP1.Intersects(CheckPass2))
                {
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckPass2))
                {
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }
            else if (rectangleP1.Intersects(CheckPass3) || rectangleP2.Intersects(CheckPass3))
            {
                if (CountPoint3 <= 0)
                {
                    CountPoint3++;
                    CountCheckpoint--;
                    soundCheckPoint.Play();
                }
                else
                {
                    if (rectangleP1.Intersects(CheckPass3))
                    {
                        PlayerDead();
                        player.Health -= 25;
                    }
                    else if (rectangleP2.Intersects(CheckPass3))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                    }
                    soundDead.Play();
                }
                if (rectangleP1.Intersects(CheckPass3))
                {
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckPass3))
                {
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }
            else if (rectangleP1.Intersects(CheckPass4) || rectangleP2.Intersects(CheckPass4))
            {
                if (CountPoint4 <= 0)
                {
                    CountPoint4++;
                    CountCheckpoint--;
                    soundCheckPoint.Play();
                }
                else
                {
                    if (rectangleP1.Intersects(CheckPass4))
                    {
                        PlayerDead();
                        player.Health -= 25;
                    }
                    else if (rectangleP2.Intersects(CheckPass4))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                    }
                    soundDead.Play();
                }
                if (rectangleP1.Intersects(CheckPass4))
                {
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckPass4))
                {
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }
            else if (rectangleP1.Intersects(CheckPass5) || rectangleP2.Intersects(CheckPass5))
            {
                if (CountPoint5 <= 0)
                {
                    CountPoint5++;
                    CountCheckpoint--;
                    soundCheckPoint.Play();
                }
                else
                {
                    if (rectangleP1.Intersects(CheckPass5))
                    {
                        PlayerDead();
                        player.Health -= 25;
                    }
                    else if (rectangleP2.Intersects(CheckPass5))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                    }
                    soundDead.Play();
                }
                if (rectangleP1.Intersects(CheckPass5))
                {
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckPass5))
                {
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }
            else if (rectangleP1.Intersects(CheckDead) || rectangleP2.Intersects(CheckDead))
            {
                soundDead.Play();
                if (rectangleP1.Intersects(CheckDead))
                {
                    PlayerDead();
                    player.Health -= 25;
                    player.Position.X = playerPosition.X;
                    player.Position.Y = playerPosition.Y;
                }
                else if (rectangleP2.Intersects(CheckDead))
                {
                    PlayerDead2();
                    player2.Health -= 25;
                    player2.Position.X = playerPosition2.X;
                    player2.Position.Y = playerPosition2.Y;
                }
            }

            for (int i = 0; i < barriersRiver1.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRiver1[i].Position.X - barriersRiver1[i].Width / 3,
                (int)barriersRiver1[i].Position.Y, barriersRiver1[i].Width * 4 / 7, barriersRiver1[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRiver1[i].Position.X,
                (int)barriersRiver1[i].Position.Y, barriersRiver1[i].Width, barriersRiver1[i].Height);
                }

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        player.Position.X += barriersRiver1[i].BarrierMoveSpeed;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        player2.Position.X += barriersRiver1[i].BarrierMoveSpeed;
                    }
                }
            }
            for (int i = 0; i < barriersRiver2.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRiver2[i].Position.X + 15,
                (int)barriersRiver2[i].Position.Y, barriersRiver2[i].Width, barriersRiver2[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRiver2[i].Position.X - barrierRiverRow2.Width / 3,
                (int)barriersRiver2[i].Position.Y, barriersRiver2[i].Width, barriersRiver2[i].Height);
                }

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        player.Position.X += barriersRiver2[i].BarrierMoveSpeed;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        player2.Position.X += barriersRiver2[i].BarrierMoveSpeed;
                    }
                }
            }
            for (int i = 0; i < barriersRiver3.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRiver3[i].Position.X - barriersRiver3[i].Width / 4,
                (int)barriersRiver3[i].Position.Y, barriersRiver3[i].Width * 7 / 8, barriersRiver3[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRiver3[i].Position.X,
                (int)barriersRiver3[i].Position.Y, barriersRiver3[i].Width, barriersRiver3[i].Height);
                }


                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        player.Position.X += barriersRiver3[i].BarrierMoveSpeed;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        player2.Position.X += barriersRiver3[i].BarrierMoveSpeed;
                    }
                }
            }
            for (int i = 0; i < barriersRiver4.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRiver4[i].Position.X,
                (int)barriersRiver4[i].Position.Y, barriersRiver4[i].Width, barriersRiver4[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRiver4[i].Position.X - barrierRiverRow4.Width / 3,
                (int)barriersRiver4[i].Position.Y, barriersRiver4[i].Width - barrierRiverRow4.Width / 10, barriersRiver4[i].Height);
                }


                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        player.Position.X += barriersRiver4[i].BarrierMoveSpeed;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        player2.Position.X += barriersRiver4[i].BarrierMoveSpeed;
                    }
                }
            }
            for (int i = 0; i < barriersRoad1.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRoad1[i].Position.X - barriersRoad1[i].Width / 3,
                (int)barriersRoad1[i].Position.Y, barriersRoad1[i].Width * 6 / 7, barriersRoad1[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRoad1[i].Position.X - 10,
                (int)barriersRoad1[i].Position.Y, barriersRoad1[i].Width, barriersRoad1[i].Height);
                }


                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    soundDead.Play();
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                        player.Position.X = playerPosition.X;
                        player.Position.Y = playerPosition.Y;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                        player2.Position.X = playerPosition2.X;
                        player2.Position.Y = playerPosition2.Y;
                    }
                }

            }
            for (int i = 0; i < barriersRoad2.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRoad2[i].Position.X - 20,
                (int)barriersRoad2[i].Position.Y, barriersRoad2[i].Width - 5, barriersRoad2[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRoad2[i].Position.X - barrierRoadRow2.Width / 3 - 10,
                (int)barriersRoad2[i].Position.Y, barriersRoad2[i].Width - 5, barriersRoad2[i].Height);
                }

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    soundDead.Play();
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                        player.Position.X = playerPosition.X;
                        player.Position.Y = playerPosition.Y;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                        player2.Position.X = playerPosition2.X;
                        player2.Position.Y = playerPosition2.Y;
                    }
                }

            }
            for (int i = 0; i < barriersRoad3.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRoad3[i].Position.X - 5,
                (int)barriersRoad3[i].Position.Y, barriersRoad3[i].Width - 10, barriersRoad3[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRoad3[i].Position.X - 10,
                (int)barriersRoad3[i].Position.Y, barriersRoad3[i].Width - 10, barriersRoad3[i].Height);
                }

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    soundDead.Play();
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                        player.Position.X = playerPosition.X;
                        player.Position.Y = playerPosition.Y;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                        player2.Position.X = playerPosition2.X;
                        player2.Position.Y = playerPosition2.Y;
                    }
                }

            }
            for (int i = 0; i < barriersRoad4.Count; i++)
            {
                if (GameLevel == 1)
                {
                    rectangle2 = new Rectangle((int)barriersRoad4[i].Position.X - 5,
                (int)barriersRoad4[i].Position.Y, barriersRoad4[i].Width - 10, barriersRoad4[i].Height);
                }
                else if (GameLevel == 2)
                {
                    rectangle2 = new Rectangle((int)barriersRoad4[i].Position.X - 20,
                (int)barriersRoad4[i].Position.Y, barriersRoad4[i].Width - 10, barriersRoad4[i].Height);
                }

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    soundDead.Play();
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                        player.Position.X = playerPosition.X;
                        player.Position.Y = playerPosition.Y;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                        player2.Position.X = playerPosition2.X;
                        player2.Position.Y = playerPosition2.Y;
                    }
                }

            }
            for (int i = 0; i < WaterList.Count; i++)
            {
                rectangle2 = new Rectangle((int)WaterList[i].Position.X,
                (int)WaterList[i].Position.Y, WaterList[i].Width, WaterList[i].Height);

                if (rectangleP1.Intersects(rectangle2) || rectangleP2.Intersects(rectangle2))
                {
                    soundDead.Play();
                    if (rectangleP1.Intersects(rectangle2))
                    {
                        PlayerDead();
                        player.Health -= 25;
                        player.Position.X = playerPosition.X;
                        player.Position.Y = playerPosition.Y;
                    }
                    else if (rectangleP2.Intersects(rectangle2))
                    {
                        PlayerDead2();
                        player2.Health -= 25;
                        player2.Position.X = playerPosition2.X;
                        player2.Position.Y = playerPosition2.Y;
                    }
                }
            }

            ////////////////////////////////////
            if (player.Health <= 0)
            {
                player.Live--;
                player.Health = 100;
                if (player.Live < 0)
                {
                    player.Live = 0;
                    player.Health = 0;
                }
            }
            if (player2.Health <= 0)
            {
                player2.Live--;
                player2.Health = 100;
                if (player2.Live < 0)
                {
                    player2.Live = 0;
                    player2.Health = 0;
                }
            }
            if (player.Health <= 0 && player.Live <= 0)
            {
                player.Active = false;
            }
            if (player2.Health <= 0 && player2.Live <= 0)
            {
                player2.Active = false;
            }
            if (player.Health <= 0 && player.Live <= 0 && player2.Health <= 0 && player2.Live <= 0)
            {
                if (GameLevel == 1)
                {
                    GameLevel = 1;
                    ResetStatus = true;
                    player.Live = 3;
                    player.Health = health;
                    player2.Live = 3;
                    player2.Health = health;
                    player.Active = true;
                    player2.Active = true;
                    countRoundState = 1;
                }
                if (GameLevel == 2)
                {
                    GameLevel = 2;
                    ResetStatus = true;
                    player.Live = 3;
                    player.Health = health;
                    player2.Live = 3;
                    player2.Health = health;
                    player.Active = true;
                    player2.Active = true;
                    countRoundState = 1;
                }
            }
        }

        private void AddBulletPlayer()                    // การเพิ่มกระสุนเข้าไปในเกม ก็ต่อเมื่อบอสยังมีชีวิตอยู่
        {
            if (boss1.Active || boss2.Active || boss3.Active || boss4.Active || boss5.Active)
            {
                if (player.Active)
                {
                    Animation bulletPlayer1 = new Animation();
                    BulletPlayer1 = new Barrier();
                    bulletPlayer1.Initialize(AllColorBossAnimation, new Vector2(450, 0), 20, 15, 1, 30, Color.White, 1f, true, true);
                    Vector2 bulletPlayerPosition = new Vector2(player.Position.X + 25, player.Position.Y - 40);
                    BulletPlayer1.Initialize(bulletPlayer1, bulletPlayerPosition, 10f, 10, 2);
                    bullet.Add(BulletPlayer1);
                }
                if (player2.Active)
                {
                    Animation bulletPlayer2 = new Animation();
                    BulletPlayer2 = new Barrier();
                    bulletPlayer2.Initialize(AllColorBossAnimation, new Vector2(450, 100), 20, 15, 1, 30, Color.White, 1f, true, true);
                    Vector2 bulletPlayerPosition2 = new Vector2(player2.Position.X + 25, player2.Position.Y - 40);
                    BulletPlayer2.Initialize(bulletPlayer2, bulletPlayerPosition2, 10f, 10, 2);
                    bullet.Add(BulletPlayer2);
                }
            }
        }
        private void AddBulletBoss()                      // เพิ่มกระสุนเข้าไปในเกมและกำหนดตำแหน่งกระสุน       
        {
            Random ranBulletSpeed = new Random();
            Random BB1 = new Random();
            float resulRanBulletSpeed = ranBulletSpeed.Next(4, bulletBossSpeed + 1);

            if (boss1.Active)  // เช็กแบบนี้เพื่อลบบอสออกไปเลย ไม่ต้องเหลือตำแหน่งให้คิดคำณวนอีก
            {
                int exchange1 = BB1.Next(0, 99);
                if (exchange1 >= 0 && exchange1 <= 50 || exchange1 >= 80)
                {
                    Animation bulletBoss1 = new Animation(); // กระสุนสีม่วง
                    BulletBoss1 = new Barrier();
                    bulletBoss1.Initialize(AllColorBossAnimation, BulletTexture, 20, 20, 1, 1, Color.White, 1f, true, true);
                    Vector2 vioBossPosition = new Vector2(boss1.Position.X + 25, boss1.Position.Y + 60);
                    BulletBoss1.Initialize(bulletBoss1, vioBossPosition, -resulRanBulletSpeed, 10, 2);
                    bullet.Add(BulletBoss1);
                }
            }

            if (boss2.Active)
            {
                int exchange2 = BB1.Next(0, 99);
                if (exchange2 >= 30)
                {
                    Animation bulletBoss2 = new Animation(); // กระสุนสีส้ม
                    BulletBoss2 = new Barrier();
                    bulletBoss2.Initialize(AllColorBossAnimation, BulletTexture, 20, 20, 1, 1, Color.White, 1f, true, true);
                    Vector2 oraBossPosition = new Vector2(boss2.Position.X + 25, boss2.Position.Y + 60);
                    BulletBoss2.Initialize(bulletBoss2, oraBossPosition, -resulRanBulletSpeed, 10, 2);
                    bullet.Add(BulletBoss2);
                }
            }

            if (boss3.Active)
            {
                int exchange3 = BB1.Next(0, 99);
                if (exchange3 >= 30)
                {
                    Animation bulletBoss3 = new Animation(); // กระสุนสีฟ้า
                    BulletBoss3 = new Barrier();
                    bulletBoss3.Initialize(AllColorBossAnimation, BulletTexture, 20, 20, 1, 1, Color.White, 1f, true, true);
                    Vector2 bluBossPosition = new Vector2(boss3.Position.X + 25, boss3.Position.Y + 60);
                    BulletBoss3.Initialize(bulletBoss3, bluBossPosition, -resulRanBulletSpeed, 10, 2);
                    bullet.Add(BulletBoss3);
                }
            }

            if (boss4.Active)
            {
                int exchange4 = BB1.Next(0, 99);
                if (exchange4 >= 30)
                {
                    Animation bulletBoss4 = new Animation(); // กระสุนสีแดง
                    BulletBoss4 = new Barrier();
                    bulletBoss4.Initialize(AllColorBossAnimation, BulletTexture, 20, 20, 1, 1, Color.White, 1f, true, true);
                    Vector2 redBossPosition = new Vector2(boss4.Position.X + 25, boss4.Position.Y + 60);
                    BulletBoss4.Initialize(bulletBoss4, redBossPosition, -resulRanBulletSpeed, 10, 2);
                    bullet.Add(BulletBoss4);
                }
            }

            if (boss5.Active)
            {
                int exchange5 = BB1.Next(0, 100);
                if (exchange5 >= 50 && exchange5 < 100)
                {
                    Animation bulletBoss5 = new Animation(); // กระสุนสีเขียว
                    BulletBoss5 = new Barrier();
                    bulletBoss5.Initialize(AllColorBossAnimation, BulletTexture, 20, 20, 1, 1, Color.White, 1f, true, true);
                    Vector2 greBossPosition = new Vector2(boss5.Position.X + 25, boss5.Position.Y + 60);
                    BulletBoss5.Initialize(bulletBoss5, greBossPosition, -resulRanBulletSpeed, 10, 2);
                    bullet.Add(BulletBoss5);
                }
            }
        }
        private void AddKnife()
        {
            if (boss1.Active || boss2.Active || boss3.Active || boss4.Active || boss5.Active)  // เช็กแบบนี้เพื่อลบบอสออกไปเลย ไม่ต้องเหลือตำแหน่งให้คิดคำณวนอีก
            {
                Random kk = new Random();
                int pos = kk.Next(0, 640 );
                Animation bulletBoss9 = new Animation(); // มีด
                BulletBoss9 = new Barrier();
                bulletBoss9.Initialize(AllColorBossAnimation, new Vector2(500, 0), 200, 48, 1, 120, Color.White, 0, false, true);                     //////////////////
                Vector2 vioBossPosition = new Vector2(pos+20, boss1.Position.Y + 60);
                BulletBoss9.Initialize(bulletBoss9, vioBossPosition, -3, 25, 2);
                bullet.Add(BulletBoss9);
            }
        }
        private void UpdateBulletBoss(GameTime gameTime)  // ตำแหน่งสิ่งกีดขวาง
        {
            if (gameTime.TotalGameTime - previousSpawnTime > BarrierSpawnTime)
            {
                previousSpawnTime = gameTime.TotalGameTime;
                AddBulletBoss();
                AddBulletPlayer();
                AddKnife();
                soundShoot.Play();
            }
            for (int i = bullet.Count - 1; i >= 0; i--)
            {
                bullet[i].Update(gameTime);
                if (bullet[i].Active == false)
                {
                    bullet.RemoveAt(i);
                }
            }
        }
        private void UpdateMoveBoss(GameTime gameTime)    // ตำแหน่งการเคลื่อนที่ของบอส  
        {
            boss1.Position.X += bossMoveSpeed;
            boss2.Position.X += bossMoveSpeed;
            boss3.Position.X += bossMoveSpeed;
            boss4.Position.X += bossMoveSpeed;
            boss5.Position.X += bossMoveSpeed;

            if (boss1.Position.X <= 0 + 30 || boss1.Position.X >= 160 + 30 - boss1.Width)
            {
                if (boss1.Position.X == 160 + 30 - boss1.Width)
                {
                    bossMoveSpeed = -bossMoveSpeed;
                }
                else if (boss1.Position.X == 0 + 30)
                {
                    bossMoveSpeed = -bossMoveSpeed;
                }
            }
        }
        private void PlayerBossBulletCrashed()
        {
            Rectangle playerBoom1; // ตำแหน่งของ player ซึ่งตอนทำมี 1 ตัว
            Rectangle bulletPlayer1; // กระสุนของ player
            Rectangle playerBoom2; // ตำแหน่งของ player ซึ่งตอนทำมี 1 ตัว
            Rectangle bulletPlayer2; // กระสุนของ player
            Rectangle bossBoom1;
            Rectangle bossBoom2;
            Rectangle bossBoom3;  // ตำแหน่งของตัวบอส ซึ่งมี 5 ตัว
            Rectangle bossBoom4;
            Rectangle bossBoom5;
            Rectangle bulletBossBoom;  // กระสุนอยู่ใน list


            playerBoom1 = new Rectangle((int)player.Position.X, (int)player.Position.Y, player.Width, player.Height);
            bulletPlayer1 = new Rectangle((int)player.Position.X + 50, (int)player.Position.Y + 25, player.Width, player.Height);

            playerBoom2 = new Rectangle((int)player2.Position.X, (int)player2.Position.Y, player2.Width, player2.Height);
            bulletPlayer2 = new Rectangle((int)player2.Position.X + 50, (int)player2.Position.Y + 25, player2.Width, player2.Height);

            bossBoom1 = new Rectangle((int)boss1.Position.X, (int)boss1.Position.Y, boss1.Width, boss1.Height);
            bossBoom2 = new Rectangle((int)boss2.Position.X, (int)boss2.Position.Y, boss2.Width, boss2.Height);
            bossBoom3 = new Rectangle((int)boss3.Position.X, (int)boss3.Position.Y, boss3.Width, boss3.Height);
            bossBoom4 = new Rectangle((int)boss4.Position.X, (int)boss4.Position.Y, boss4.Width, boss4.Height);
            bossBoom5 = new Rectangle((int)boss5.Position.X, (int)boss5.Position.Y, boss5.Width, boss5.Height);


            for (int i = 0; i < bullet.Count; i++)
            {
                bulletBossBoom = new Rectangle((int)bullet[i].Position.X, (int)bullet[i].Position.Y, bullet[i].Width, bullet[i].Height);
                if (player.Active)
                {
                    if (playerBoom1.Intersects(bulletBossBoom))
                    {
                        player.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (player.Health <= 0)
                        {
                            player.Live -= 1;
                            player.Health = 100;
                            if (player.Live < 0)
                            {
                                soundDead.Play();
                                player.Active = false;
                                player.Live = 0;
                                player.Health = 0;
                            }
                        }
                    }
                }
                if (player2.Active)
                {
                    if (playerBoom2.Intersects(bulletBossBoom))
                    {
                        player2.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (player2.Health <= 0)
                        {
                            player2.Live -= 1;
                            player2.Health = 100;
                            if (player2.Live < 0)
                            {
                                soundDead.Play();
                                player2.Active = false;
                                player2.Live = 0;
                                player2.Health = 0;
                            }
                        }
                    }
                }

                if (boss1.Active)
                {
                    if (bossBoom1.Intersects(bulletBossBoom))
                    {
                        boss1.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (boss1.Health == 0)
                        {
                            soundCheckPoint.Play();
                            boss1.Active = false;
                            countBoss--;
                        }
                    }
                }
                if (boss2.Active)
                {
                    if (bossBoom2.Intersects(bulletBossBoom))
                    {
                        boss2.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (boss2.Health == 0)
                        {
                            soundCheckPoint.Play();
                            boss2.Active = false;
                            countBoss--;
                        }
                    }
                }
                if (boss3.Active)
                {
                    if (bossBoom3.Intersects(bulletBossBoom))
                    {
                        boss3.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (boss3.Health == 0)
                        {
                            soundCheckPoint.Play();
                            boss3.Active = false;
                            countBoss--;
                        }
                    }
                }
                if (boss4.Active)
                {
                    if (bossBoom4.Intersects(bulletBossBoom))
                    {
                        boss4.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (boss4.Health == 0)
                        {
                            soundCheckPoint.Play();
                            boss4.Active = false;
                            countBoss--;
                        }
                    }
                }
                if (boss5.Active)
                {
                    if (bossBoom5.Intersects(bulletBossBoom))
                    {
                        boss5.Health -= bullet[i].Damage;
                        bullet[i].Active = false;
                        if (boss5.Health == 0)
                        {
                            soundCheckPoint.Play();
                            boss5.Active = false;
                            countBoss--;
                        }
                    }
                }
                if (GameLevel == 3)
                {
                    if (player.Live == 0 && player.Health == 0 && player2.Live == 0 && player2.Health == 0)
                    {
                        GameLevel = 3;
                        ResetStatus = true;
                        player.Live = 3;
                        player.Health = health;
                        player2.Live = 3;
                        player2.Health = health;
                        player.Active = true;
                        player2.Active = true;
                        player.Position.X = playerPosition.X;
                        player2.Position.X = playerPosition2.X;
                        boss1.Active = true;
                        boss2.Active = true;
                        boss3.Active = true;
                        boss4.Active = true;
                        boss5.Active = true;
                        countBoss = 5;
                        countRoundState = 1;
                        start = false;
                    }
                    if (boss1.Active == false && boss2.Active == false && boss3.Active == false && boss4.Active == false && boss5.Active == false)
                    {
                        VictoryGame = true;
                        ResetStatus = false;
                    }
                }
            }
        }                     
    }
}
