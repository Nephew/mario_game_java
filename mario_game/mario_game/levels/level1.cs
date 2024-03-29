﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace mario_game.levels
{
    /// <summary>
    /// Initalise le niveau 1, WARNING load le level au constructeur!!!
    /// </summary>
    class level1
    {
        public const short levelNumber = 1;
        
        Texture2D cloudsBackground;
        Texture2D grassBackground;
        Texture2D testPerso;

        // Test de son !
        SoundEffect sonJumpMario;

        //Variable charactère. Initialisation dans le Initialise()
        Vector2 posChar;
        charac Charac1;
        Rectangle spritPos;

        List<decor> ElementsCollision;

        //Hauteur d'écran pour positioner char.
        int height;
    
        private Game jeu;    
   
        // Attribut pour la gestion des touches
        libraries.keyboard statutKeyboard;
 
        /// <summary>
        /// Initalise le niveau 1, WARNING load le level au constructeur!!!
        /// </summary>
        public level1(Game unJeu,GraphicsDeviceManager graphics, int screenHeight)
        { this.jeu = unJeu; height = screenHeight;
            ElementsCollision = new List<decor>();

            //Objet composant le décor
            LoadLevel(graphics);
            // Chargement paramètre clavier
            statutKeyboard = new libraries.keyboard(Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.Space, Keys.Enter);
            }

        private void LoadLevel(GraphicsDeviceManager graphics)  {
            
            //Chargement des sons.
            sonJumpMario = jeu.Content.Load<SoundEffect>(@"son/Mario_Jump");

            // Chargement des textures
            cloudsBackground = jeu.Content.Load<Texture2D>(@"textures/cloud");
            grassBackground = jeu.Content.Load<Texture2D>(@"textures/ground");
            testPerso = jeu.Content.Load<Texture2D>(@"textures/smw_mario_sheet");

            // Initialsier
            InitialiserLesObjets(graphics);
        }

        public void InitialiserLesObjets(GraphicsDeviceManager graphics)
        {
            posChar = new Vector2(10, height - 84);
            spritPos = new Rectangle(210, 0, 15, 20);

            // Créations des objets de base.
            Charac1 = new charac(testPerso, posChar, spritPos, 0.5f);
            Charac1.Active = true;


            //On met tout le sol dans les éléments de collision
            for (int i = 0; i < (Math.Ceiling((decimal)graphics.PreferredBackBufferWidth / grassBackground.Width)); i++)
              {
                 decor TileSol = new decor(grassBackground, new Vector2( (int)(i * 64), (int)(graphics.PreferredBackBufferHeight - grassBackground.Height)), new Rectangle(0,0,64,64),1,true);
              ElementsCollision.Add(TileSol);
              }
        }

        private void jouerSonJump()
        {
                sonJumpMario.Play();
       }

        public void updateKeyboard(KeyboardState etatClavier, float screenWidth)
        {
            KeyboardState etatActuel = etatClavier;

            if (statutKeyboard.moveLeft(etatActuel))
                Charac1.moveLeft(screenWidth, ElementsCollision);
            if (statutKeyboard.moveRight(etatActuel))
                Charac1.moveRight(screenWidth, ElementsCollision);
            if (statutKeyboard.moveUp(etatActuel))
                Charac1.moveUp(ElementsCollision);
            if (statutKeyboard.moveDown(etatActuel))
                Charac1.moveDown(ElementsCollision);
            if (statutKeyboard.jump(etatActuel))
                jouerSonJump();

        }

        public void unloadLevel()
        {
            cloudsBackground.Dispose();
            grassBackground.Dispose();
            testPerso.Dispose();

            cloudsBackground = null;
            testPerso = null;
            grassBackground = null;
        }

        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i <= (Math.Ceiling((decimal)(graphics.PreferredBackBufferWidth / cloudsBackground.Width))); i++)
            {
                spriteBatch.Draw(cloudsBackground, new Vector2(i * cloudsBackground.Width, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);
            }
            
            //On load tout les objets collisionable a partir de la list
            for (int i = 0; i < ElementsCollision.Count; i++)
            {
                ElementsCollision[i].Draw(spriteBatch);
            }

            Charac1.Draw(spriteBatch);
        }
    }
}
