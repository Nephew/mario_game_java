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
    class charac : sprite
    {
        public charac(Texture2D uneTextureALoader)
            :base(uneTextureALoader)
        {}

        public charac(Texture2D uneTextureALoader, Vector2 positionActuelle)
            : base(uneTextureALoader, positionActuelle)
        { }

        public charac(Texture2D uneTextureALoader,int y, int x)
            :base(uneTextureALoader, new Vector2(x,y))
        {}

        public charac(Texture2D uneTextureALoader, int y, int x,  byte nbFramesHoriz)
            :base(uneTextureALoader, new Vector2(x,y), nbFramesHoriz)
        {}

        public charac(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz)
            : base(uneTextureALoader, positionActuelle, nbFramesHoriz)
        { }

        /// <summary>
        /// Fait bouger le personnage à gauche
        /// </summary>
        public void MoveLeft(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'l')
            {
                X -= 3;
                SpriteToBeUpdatedOrNot = true;
            }
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'r')
            {
                X += 3;
                SpriteToBeUpdatedOrNot = true;
            }
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
                if ((Y + TextureUsed.Height) >= (ElementsCollision[i].Y) && X >= ElementsCollision[i].X - 6 && X
                    <= ElementsCollision[i].X + ElementsCollision[i].TextureUsed.Height && Y + TextureUsed.Height <= ElementsCollision[i].Y)  //Contact avec pied
                    return 'b';

                if (Y >= (ElementsCollision[i].TextureUsed.Height + ElementsCollision[i].Y) && X >= ElementsCollision[i].X - 6 && X
                    <= ElementsCollision[i].X + ElementsCollision[i].TextureUsed.Height && Y <= ElementsCollision[i].Y + ElementsCollision[i].TextureUsed.Height
                    && X <= ElementsCollision[i].X + ElementsCollision[i].TextureUsed.Height) //Contact avec tête
                    return 't';

                if (X <= ElementsCollision[i].X + ElementsCollision[i].TextureUsed.Width && Y <= ElementsCollision[i].Y +
                    ElementsCollision[i].TextureUsed.Height && Y + TextureUsed.Height >= ElementsCollision[i].Y && X >= ElementsCollision[i].X
                    + ElementsCollision[i].TextureUsed.Width - 2) //Contact avec gauche
                    return 'l';
                 
                if (X + TextureUsed.Height >= ElementsCollision[i].X + 6 && Y <= ElementsCollision[i].Y 
                    + ElementsCollision[i].TextureUsed.Height && Y + TextureUsed.Height >= ElementsCollision[i].Y && X 
                    <= ElementsCollision[i].X) //Contact avec droite
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
            {
                Y -= 1;
                SpriteToBeUpdatedOrNot = true;
            }
        }

        public void MoveDown(List<libraries.decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'b')
            {
                Y += 1;
                SpriteToBeUpdatedOrNot = true;
            }
        }

        
    }
}
