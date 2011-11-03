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
            pos_x -= 3;
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
            Rectangle charHitBox = new Rectangle((int)pos_x, (int)pos_y, w_charac, h_charac); //HitBox de Mario
            Rectangle decorHitBox;

            for (int i = 0; i < ElementsCollision.Count; i++)
            {
                decorHitBox = new Rectangle(ElementsCollision[i].PositionX, ElementsCollision[i].PositionY + 43,
                    ElementsCollision[i].Width, ElementsCollision[i].Height);

                if(decorHitBox.Intersects(charHitBox))
                    return true;
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
