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
        private float pos_x = 0;
        private float pos_y = 0;
        private Texture2D sprit;
        private bool pasTest = false;

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
        public void MoveLeft(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'l')
                pos_x -= 3;
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'r')
                pos_x += 3;
        }

        /// <summary>
        /// Détecte les collisions avec l'objet Charac
        /// </summary>
        /// <param name="ElementsCollision">La liste des tout les éléments qui pourrait entré en collision avec l'user</param>
        /// <returns></returns>
        public char GetCollision(List<libraries.decor> ElementsCollision)
        {
            for (int i = 0; i < ElementsCollision.Count; i++)
            {
                if ((pos_y + h_charac) >= (ElementsCollision[i].PositionY) && pos_x >= ElementsCollision[i].PositionX - 6 && pos_x
                    <= ElementsCollision[i].PositionX + ElementsCollision[i].Height && pos_y + h_charac <= ElementsCollision[i].PositionY)  //Contact avec pied
                    return 'b';

                if (pos_y >= (ElementsCollision[i].Height + ElementsCollision[i].PositionY) && pos_x >= ElementsCollision[i].PositionX - 6 && pos_x
                    <= ElementsCollision[i].PositionX + ElementsCollision[i].Height && pos_y <= ElementsCollision[i].PositionY + ElementsCollision[i].Height
                    && pos_x <= ElementsCollision[i].PositionX + ElementsCollision[i].Height) //Contact avec tête
                    return 't';

                if (pos_x <= ElementsCollision[i].PositionX + ElementsCollision[i].Width && pos_y <= ElementsCollision[i].PositionY +
                    ElementsCollision[i].Height && pos_y + h_charac >= ElementsCollision[i].PositionY && pos_x >= ElementsCollision[i].PositionX
                    + ElementsCollision[i].Width - 2) //Contact avec gauche
                    return 'l';
                 
                if (pos_x + h_charac >= ElementsCollision[i].PositionX + 6 && pos_y <= ElementsCollision[i].PositionY 
                    + ElementsCollision[i].Height && pos_y + h_charac >= ElementsCollision[i].PositionY && pos_x 
                    <= ElementsCollision[i].PositionX) //Contact avec droite
                    return 'r';
            }

            return 'x';
                
        }

        /// <summary>
        /// Gestion des sauts
        /// </summary>
        public void MoveUp(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 't')
                pos_y -= 1;
        }

        public void MoveDown(List<libraries.decor> DecorColission)
        {
            if(GetCollision(DecorColission) != 'b')
                pos_y += 1;
        }

        
    }
}
