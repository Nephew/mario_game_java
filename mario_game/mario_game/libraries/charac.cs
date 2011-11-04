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

namespace mario_game.libraries
{
    class charac : sprite
    {
        private bool pasTest = false;

        public charac(Texture2D uneTextureALoader)
            :base(uneTextureALoader)
        {
            
        }

        public charac(int y, int x, Texture2D uneTextureALoader)
            :base(uneTextureALoader, new Vector2(x,y))
        {
        }

        public charac(int y, int x, Texture2D uneTextureALoader,  byte nbFramesHoriz)
            :base(uneTextureALoader, new Vector2(x,y), nbFramesHoriz)
        {

        }

        //Acceseur sur les positions
        public float PositionY
        {
            get { return Y; }
        }

        public float PositionX
        {
            get { return X; }
        }
        //////////////////////////

        

        /// <summary>
        /// Fait bouger le personnage à gauche
        /// </summary>
        public void MoveLeft(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'l')
                X -= 3;
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'r')
                X += 3;
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
                if ((Y + TextureUsed.Height) >= (ElementsCollision[i].PositionY) && X >= ElementsCollision[i].PositionX - 6 && X
                    <= ElementsCollision[i].PositionX + ElementsCollision[i].Height && Y + TextureUsed.Height <= ElementsCollision[i].PositionY)  //Contact avec pied
                    return 'b';

                if (Y >= (ElementsCollision[i].Height + ElementsCollision[i].PositionY) && X >= ElementsCollision[i].PositionX - 6 && X
                    <= ElementsCollision[i].PositionX + ElementsCollision[i].Height && Y <= ElementsCollision[i].PositionY + ElementsCollision[i].Height
                    && X <= ElementsCollision[i].PositionX + ElementsCollision[i].Height) //Contact avec tête
                    return 't';

                if (X <= ElementsCollision[i].PositionX + ElementsCollision[i].Width && Y <= ElementsCollision[i].PositionY +
                    ElementsCollision[i].Height && Y + TextureUsed.Height >= ElementsCollision[i].PositionY && X >= ElementsCollision[i].PositionX
                    + ElementsCollision[i].Width - 2) //Contact avec gauche
                    return 'l';
                 
                if (X + TextureUsed.Height >= ElementsCollision[i].PositionX + 6 && Y <= ElementsCollision[i].PositionY 
                    + ElementsCollision[i].Height && Y + TextureUsed.Height >= ElementsCollision[i].PositionY && X 
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
                Y -= 1;
        }

        public void MoveDown(List<libraries.decor> DecorColission)
        {
            if(GetCollision(DecorColission) != 'b')
                Y += 1;
        }

        
    }
}
