using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace mario_game
{
    class charac
    {
        private int h_charac = 30;
        private int w_charac = 30;
        private float accel = 0f;
        private float pos_x = 0;
        private float pos_y = 0;
        private Texture2D sprite;

        public charac()
        {
        }

        public charac(int y, int x)
        {
            this.pos_y = y;
            this.pos_x = x;
        }

        public charac(int y, int x, int height, int width)
        {
            this.pos_y = y;
            this.pos_x = x;
            this.h_charac = height;
            this.w_charac = width;
        }

        //Acceseur sur les positions
        public float PositionY
        {
            get { return pos_y; }
        }

        public float PositionX
        {
            get { return pos_x; }
        }
        //////////////////////////

        

        /// <summary>
        /// Fait bouger le personnage à gauche
        /// </summary>
        public void MoveLeft()
        {
            if (accel < 3)
            {
                pos_x -= 3;
            }

            else
            {
                pos_x -= 3;
            }
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight()
        {
            if (accel < 3)
            {
                pos_x += 3;
            }

            else
            {
                pos_x += 3;
            }
        }

        /// <summary>
        /// Stop l'accélération lors d'un arrêt ou changement de direction
        /// </summary>
        public void Stop()
        {
            accel = 0;
        }

        /// <summary>
        /// Gestion des sauts
        /// </summary>
        /// <param name="hauteur_max"></param>
        /// <param name="hauteur_actuelle"></param>
        public void MoveUp()
        {
            pos_y -= 1; 
        }

        public void MoveDown()
        {
            pos_y += 1;
        }
    }
}
