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
using mario_game.libraries;

namespace mario_game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        const int height = 600;
        const int width = 800;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D cloudsBackground;
        Texture2D grassBackground;
        Texture2D testPerso;
        List<libraries.decor> ElementsCollision;

        //Variable charactère. Initialisation dans le Initialise()
        Vector2 posChar;
        charac Charac1;
        Rectangle spritPos;

        //Animation
        int compteur = 0;
        char stop = ' ';

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


            // Créations des objets de base.
            Charac1 = new charac(testPerso, height - 84, 10, 15, 20);
            posChar = new Vector2(10, height - 84);
            spritPos = new Rectangle(210, 0, 15, 20);


            //Objet composant le décor
            ElementsCollision = new List<libraries.decor>();

            //On met tout le sol dans les éléments de collision
            for (int i = 0; i < (Math.Ceiling((decimal)graphics.PreferredBackBufferWidth / grassBackground.Width)); i++)
            {
                libraries.decor TileSol = new libraries.decor(grassBackground, (int)(i * 64), (int)(graphics.PreferredBackBufferHeight - grassBackground.Height), 64, 64);
                ElementsCollision.Add(TileSol);
            }
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


            // Chargement des textures
            cloudsBackground = Content.Load<Texture2D>(@"textures/cloud");
            grassBackground = Content.Load<Texture2D>(@"textures/ground");
            testPerso = Content.Load<Texture2D>(@"textures/smw_mario_sheet");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            cloudsBackground.Dispose();
            grassBackground.Dispose();
            testPerso.Dispose();
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
            if (keyStat.IsKeyDown(Keys.Right))
            {
                //Compteur de Frames
                compteur++;

                //Vérifie la position du sprite
                if (compteur % 7 == 0)
                {
                    if (spritPos.X == 210)
                        spritPos.X = 330;

                    else
                        spritPos.X = 210;
                }

                //Mises à jour des positions
                if (posChar.X < width - 10)
                    Charac1.MoveRight(ElementsCollision);

                posChar.X = Charac1.X;
                stop = 'r';
            }

            //Retourne à la frame de départ lors d'inactivité
            else if (keyStat.IsKeyUp(Keys.Right))
            {
                if (stop == 'r')
                    spritPos.X = 210;
            }

            if (keyStat.IsKeyDown(Keys.Left))
            {
                //Compteur de Frames
                compteur++;

                //Vérifie la position du sprite
                if (spritPos.X != 170 && spritPos.X != 50)
                    spritPos.X = 170;


                //Gestions des sprites
                if (compteur % 7 == 0)
                {
                    if (spritPos.X == 170)
                        spritPos.X = 50;

                    else
                        spritPos.X = 170;
                }

                //Mise à jour des positions
                
                if (posChar.X > 0)
                    Charac1.MoveLeft(ElementsCollision);

                    posChar.X = Charac1.X;
                stop = 'l';
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
                posChar.Y = Charac1.Y;
            }

            if (keyStat.IsKeyDown(Keys.Down))
            {
                    Charac1.MoveDown(ElementsCollision);

                posChar.Y = Charac1.Y;
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


            const int CloudsSize = 512;
            for (int i = 0; i <= (Math.Ceiling((decimal)(graphics.PreferredBackBufferWidth / cloudsBackground.Width))); i++)
            {
                spriteBatch.Draw(cloudsBackground, new Vector2(i * CloudsSize, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            const int grassSize = 64;

            for (int i = 0; i < (Math.Ceiling((decimal)graphics.PreferredBackBufferWidth / grassBackground.Width)); i++)
            {
                spriteBatch.Draw(grassBackground, new Vector2(i* grassSize, graphics.PreferredBackBufferHeight - grassBackground.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }

            //Dessine le charactère.
            spriteBatch.Draw(testPerso, posChar, spritPos, Color.White, 0, Vector2.Zero , 1, SpriteEffects.None, 1);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
