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
        private Texture2D sprit;

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
                pos_x += 3;
        }

        /// <summary>
        /// Détecte les collisions avec l'objet Charac
        /// </summary>
        /// <param name="ElementsCollision">La liste des tout les éléments qui pourrait entré en collision avec l'user</param>
        /// <returns></returns>
        public bool GetCollision(List<libraries.decor> ElementsCollision)
        {
            for (int i = 0; i < ElementsCollision.Count; i++)
            {
                if ((pos_y + h_charac) >= (ElementsCollision[i].PositionY - 113)) //Contact avec pied
                    return true;

                if (pos_y >= (ElementsCollision[i].Height + ElementsCollision[i].PositionY)) //Contact avec tête
                    return true;

                if (pos_x >= ElementsCollision[i].PositionX + ElementsCollision[i].Width && (pos_y + h_charac) <= -(ElementsCollision[i].PositionY)) //Contact avec droit
                    return true;

                if (pos_x + w_charac <= ElementsCollision[i].PositionX && (pos_y + h_charac) <= -(ElementsCollision[i].PositionY)) //Contact avec gauche
                    return true;

                int test = 1;
            }

            return false;
                
        }

        /// <summary>
        /// Gestion des sauts
        /// </summary>
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
