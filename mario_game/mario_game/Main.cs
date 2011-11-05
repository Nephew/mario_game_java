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

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        levels.level1 premierNiveau;
        

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

            Window.Title = "Mario clone game";
<<<<<<< HEAD



            // Créations des objets de base.
            Charac1 = new charac(testPerso, new Vector2(10, height - 13), new Rectangle(8, 0, 15, 20));
            posChar = new Vector2(10, height - 84);
            spritPos = new Rectangle(8, 0, 15, 20);

            // Créations des objets de base.
            Charac1 = new charac(testPerso, posChar, spritPos, 0.5f);
            Charac1.Active = true;




            //Objet composant le décor
            ElementsCollision = new List<libraries.decor>();

            //On met tout le sol dans les éléments de collision
            for (int i = 0; i < (Math.Ceiling((decimal)graphics.PreferredBackBufferWidth / grassBackground.Width)); i++)
            {
           //     libraries.decor TileSol = new libraries.decor(grassBackground, (int)(i * 64), (int)(graphics.PreferredBackBufferHeight - grassBackground.Height), 64, 64);
              //  ElementsCollision.Add(TileSol);
            }
=======
            premierNiveau = new levels.level1(this,graphics, height);
            levelInPlay = 1;
>>>>>>> ddr/master
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
            premierNiveau.unloadLevel();
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
<<<<<<< HEAD
            if (keyStat.IsKeyDown(Keys.Right))
            {
                Charac1.MoveRight(ElementsCollision, 6, 9, 0, Window.ClientBounds.Width);
            }

            //Retourne à la frame de départ lors d'inactivité
            else if (keyStat.IsKeyUp(Keys.Right))
            {
                if (stop == 'r')
                    spritPos.X = 210;
            }

            if (keyStat.IsKeyDown(Keys.Left))
            {
                    Charac1.MoveLeft(ElementsCollision, 2, 3, 0, Window.ClientBounds.Width);

            }

                
            //Retour à la frame de départ lorsque le personne ne bouge plus
            else if (keyStat.IsKeyUp(Keys.Left))
            {
                if (stop == 'l')
                    spritPos.X = 170;
            }

            if (keyStat.IsKeyDown(Keys.Up))
            {
                Charac1.MoveUp(ElementsCollision);
            }

            if (keyStat.IsKeyDown(Keys.Down))
            {
                Charac1.MoveDown(ElementsCollision);
=======
            // Is the SPACE key down?
            if (keyStat.IsKeyDown(Keys.Space))
            {
                if (levelInPlay == 1)
                {
                    premierNiveau.jouerSonJump();
                }
>>>>>>> ddr/master
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
<<<<<<< HEAD

            const int CloudsSize = 512;
            for (int i = 0; i <= (Math.Ceiling((decimal)(graphics.PreferredBackBufferWidth / cloudsBackground.Width))); i++)
            {
                spriteBatch.Draw(cloudsBackground, new Vector2(i * CloudsSize, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);
            }
            const int grassSize = 64;

            for (int i = 0; i < (Math.Ceiling((decimal)graphics.PreferredBackBufferWidth / grassBackground.Width)); i++)
            {
                spriteBatch.Draw(grassBackground, new Vector2(i* grassSize, graphics.PreferredBackBufferHeight - grassBackground.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);
            }

            //On dessine le personnage
            Charac1.Draw(spriteBatch);

=======
            premierNiveau.draw(spriteBatch, graphics);
>>>>>>> ddr/master
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
