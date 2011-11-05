using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace mario_game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        const int height = 600;
        const int width = 800;
        short levelInPlay;
        byte resultatMenu = 0;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Initialisation des pointeurs vers levels.
        levels.Menu menu;
        levels.level1 niveau1;
        

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
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

            base.Initialize();
            IsFixedTimeStep = false; // pour pas que ca coche au mouvement
            graphics.SynchronizeWithVerticalRetrace = false; // same
            Window.Title = "Mario clone game";
            menu = new levels.Menu(this, height, width);
            levelInPlay = 0;
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            // Deload de tout ! On s'en fou si c'est clean ou non.
                if (menu != null)
                    menu.unloadLevel();
                if (niveau1 != null)
                    niveau1.unloadLevel();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            KeyboardState keyStat = Keyboard.GetState();
            switch (levelInPlay)
            {
                case 0:
                   resultatMenu = menu.updateKeyboard(this, keyStat);
                    break;
                case 1:
                    niveau1.updateKeyboard(keyStat, graphics.PreferredBackBufferWidth);
                    break;
            }
            // Chargement Niveau 1
            if (resultatMenu == 1)
            {
                niveau1 = new levels.level1(this, graphics, height);
                levelInPlay = 1;
                resultatMenu = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color laCouleurBackground = new Color(0, 149, 218);

                GraphicsDevice.Clear(laCouleurBackground);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (levelInPlay)
            {
                case 0:
                    menu.draw(spriteBatch, graphics);
                break;
                case 1:
                    niveau1.draw(spriteBatch, graphics);
                break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
