using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace mario_game.levels
{
    /// <summary>
    /// Initalise le niveau 1, WARNING load le level au constructeur!!!
    /// </summary>
    public class Menu
    {
        public const short levelNumber = 0;

        Texture2D background;
        Texture2D btnNewgame;
        Texture2D btnNewgameHover;
        Texture2D btnLoadgame;
        Texture2D btnLoadgameHover;
        Texture2D btnQuit;
        Texture2D btnQuitHover;

        libraries.keyboard statutKeyboard = new libraries.keyboard(Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.Space);

        System.Diagnostics.Stopwatch delais;

        //Hauteur d'écran pour positioner char.
        int height;
        int width;

        int position;

        private Game jeu;       
 
        /// <summary>
        /// Initalise le niveau 1, WARNING load le level au constructeur!!!
        /// </summary>
        public Menu(Game unJeu, int screenHeight, int screenWidth)
        { this.jeu = unJeu; this.height = screenHeight; this.width = screenWidth; this.LoadLevel(); position = 0;
        delais = new System.Diagnostics.Stopwatch(); delais.Stop(); }

        private void LoadLevel()  {
            // Initialiser
            InitialiserLesObjets();
            //Chargement des sons.
            

            // Chargement des textures
            background = jeu.Content.Load<Texture2D>(@"textures/background_menu");
            btnNewgame = jeu.Content.Load<Texture2D>(@"textures/btn_newgame");
            btnNewgameHover = jeu.Content.Load<Texture2D>(@"textures/btn_newgame_hover");
            btnLoadgame = jeu.Content.Load<Texture2D>(@"textures/btn_loadgame");
            btnLoadgameHover = jeu.Content.Load<Texture2D>(@"textures/btn_loadgame_hover");
            btnQuit = jeu.Content.Load<Texture2D>(@"textures/btn_quit");
            btnQuitHover = jeu.Content.Load<Texture2D>(@"textures/btn_quit_hover");
        }

        public void InitialiserLesObjets()
        {

            // Créations des objets de base.

        }

        public void unloadLevel()
        {
            background.Dispose();
            btnNewgame.Dispose();
            btnNewgameHover.Dispose();
            btnLoadgame.Dispose();
            btnLoadgameHover.Dispose();
            btnQuit.Dispose();
            btnQuitHover.Dispose();

            background = null;
            btnNewgame = null;
            btnNewgameHover = null;
            btnLoadgame = null;
            btnLoadgameHover = null;
            btnQuit = null;
            btnQuitHover = null;
        }

        public void updateKeyboard(KeyboardState etatClavier)
        {
            
            if (statutKeyboard.moveDown(etatClavier))
            {
                if (!delais.IsRunning)
                {
                    delais.Start();
                }
                else if (delais.Elapsed.Milliseconds >= 175)
                {
                    delais.Stop();
                    delais.Reset();
                    if (position < 2)
                    {
                        position++;
                    }
                    else
                    {
                        position = 0;
                    }
                    delais.Start();
                }
            }

            if (statutKeyboard.moveUp(etatClavier))
            {
                if (!delais.IsRunning)
                {
                    delais.Start();
                }
                else if (delais.Elapsed.Milliseconds >= 175)
                {
                    delais.Stop();
                    delais.Reset();
                    if (position == 0)
                    {
                        position = 2;
                    }
                    else
                    {
                        position --;

                    }
                    delais.Start();
                }

                if (statutKeyboard.enter(etatClavier))
                {
                    switch (position)
                    {
                        case 0:
                            // code du newgame
                            break;
                        case 1:
                            // code du loadgame
                            break;
                        case 2:
                            // code du quit
                            break;
                    }
                }

            }
        }


        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            LoadLevel();

            for (int i = 0; i <= (Math.Ceiling((decimal)(graphics.PreferredBackBufferWidth / background.Width))); i++)
            {
                for (int j = 0; j <= (Math.Ceiling((decimal)(graphics.PreferredBackBufferHeight / background.Height))); j++)
                {
                    spriteBatch.Draw(background, new Vector2(i * background.Width, j * background.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);
                }
            }

            const int btnWidth = 300;
            const int btnHeight = 80;

            switch (position)
            {
                case 0 :
                    spriteBatch.Draw(btnNewgameHover, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) - 90), Color.White);
                    spriteBatch.Draw(btnLoadgame, new Vector2(width / 2 - btnWidth / 2, height / 2 - btnHeight / 2), Color.White);
                    spriteBatch.Draw(btnQuit, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) + 90), Color.White);
                    break;
                case 1 :
                    spriteBatch.Draw(btnNewgame, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) - 90), Color.White);
                    spriteBatch.Draw(btnLoadgameHover, new Vector2(width / 2 - btnWidth / 2, height / 2 - btnHeight / 2), Color.White);
                    spriteBatch.Draw(btnQuit, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) + 90), Color.White);
                    break;
                case 2 :
                    spriteBatch.Draw(btnNewgame, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) - 90), Color.White);
                    spriteBatch.Draw(btnLoadgame, new Vector2(width / 2 - btnWidth / 2, height / 2 - btnHeight / 2), Color.White);
                    spriteBatch.Draw(btnQuitHover, new Vector2(width / 2 - btnWidth / 2, (height / 2 - btnHeight / 2) + 90), Color.White);
                    break;
            }
            
        }
    }
}
