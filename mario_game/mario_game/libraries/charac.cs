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
        private int h_charac = 20;
        private int w_charac = 15;
        private float accel = 0f;
        private float pos_x = 0;
        private float pos_y = 0;
        private Texture2D sprit;
        private bool CollLeft = true;
        private bool CollRight = true;
        private bool CollTop = true;
        private bool CollDown = true;

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
            if(CollLeft)
            pos_x -= 3;
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight()
        {
            if(CollRight)
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
                if ((pos_y + h_charac) >= (ElementsCollision[i].PositionY + ElementsCollision[i].PositionY * 1.9)) //Contact avec pied
                {
                    CollLeft = true;
                    CollRight = true;
                    CollTop = true;
                    CollDown = false;
                    return true;
                }

                if (pos_y >= (ElementsCollision[i].Height + ElementsCollision[i].PositionY)) //Contact avec tête
                {
                    CollLeft = true;
                    CollRight = true;
                    CollTop = false;
                    CollDown = true;
                    return true;
                }

                if (pos_x >= ElementsCollision[i].PositionX + ElementsCollision[i].Width && (pos_y + h_charac) <= -(ElementsCollision[i].PositionY)) //Contact avec droit
                {
                    CollLeft = true;
                    CollRight = false;
                    CollTop = true;
                    CollDown = true;
                    return true;
                }

                if (pos_x + w_charac <= ElementsCollision[i].PositionX && (pos_y + h_charac) <= -(ElementsCollision[i].PositionY)) //Contact avec gauche
                {
                    CollLeft = false;
                    CollRight = true;
                    CollTop = true;
                    CollDown = true;
                    return true;
                }

            }

            CollDown = true;
            CollLeft = true;
            CollRight = true;
            CollTop = true;
            return false;
                
        }

        /// <summary>
        /// Gestion des sauts
        /// </summary>
        public void MoveUp()
        {
            if(CollTop)
            pos_y -= 1; 
        }

        public void MoveDown()
        {
            if(CollDown)
            pos_y += 1;
        }

        
    }
}
