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
        private byte compteurFrame = 0;
        bool spriteOn = true;

        public charac(Texture2D uneTextureALoader, Vector2 positionActuelle, Rectangle selectSprite, float profondeur)
            : base(uneTextureALoader, positionActuelle, selectSprite, profondeur)
        { }

        public charac(Texture2D uneTextureALoader, Vector2 positionActuelle, Rectangle selectSprite)
            : base(uneTextureALoader, positionActuelle, selectSprite)
        { }

        /// <summary>
        /// Verifie si il y a collision avec l'écran. True si collision sinon False.
        /// </summary>
        public void MoveLeft(List<decor> DecorColission,int width)
        {
            //Gestions des Frames
            compteurFrame++;
            ResetCompteur();


            if (GetCollision(DecorColission) != 'l' && X > 1)
            {
                X -= 3;
            }
        }

        /// <summary>
        /// Fait bouger le personnage à droite
        /// </summary>
        public void MoveRight(List<decor> DecorColission, int width)
        {

            if (GetCollision(DecorColission) != 'r' && X <= width - 15)
            {
                X += 3;
            }
        }

        /// <summary>
        /// Retourne la position au contact d'un objet
        /// </summary>
        /// <param name="ElementsCollision">Liste contenant les élément du décor positionnable</param>
        /// <returns></returns>
        public char GetCollision(List<decor> ElementsCollision)
        {
            for (int i = 0; i < ElementsCollision.Count; i++)
            {
                if (Y + _partOfTheSpriteToShow.Height >= ElementsCollision[i].Y && X <= ElementsCollision[i].X + ElementsCollision[i].SelectSprite.Width
                    && X + 10 >= ElementsCollision[i].X && Y + _partOfTheSpriteToShow.Height <= ElementsCollision[i].Y + 2)  //Contact avec pied
                    return 'b';

                if (Y + 2 >= ElementsCollision[i].Y + ElementsCollision[i].SelectSprite.Height && X <= ElementsCollision[i].X + ElementsCollision[i].SelectSprite.Width
                    && X >= ElementsCollision[i].X - 10 && Y <= ElementsCollision[i].Y + ElementsCollision[i].SelectSprite.Height + 1) //Contact avec tête
                    return 't';

                if (X <= ElementsCollision[i].X + ElementsCollision[i].SelectSprite.Width && Y <= ElementsCollision[i].Y + ElementsCollision[i].SelectSprite.Height &&
                    Y + _partOfTheSpriteToShow.Height >= ElementsCollision[i].Y && X >= ElementsCollision[i].X + ElementsCollision[i].SelectSprite.Width - 2) //Contact avec droite
                    return 'l';

                if (X - 2 + _partOfTheSpriteToShow.Width >= ElementsCollision[i].X && Y <= ElementsCollision[i].Y + ElementsCollision[i].SelectSprite.Height &&
                    Y + _partOfTheSpriteToShow.Height >= ElementsCollision[i].Y && X + _partOfTheSpriteToShow.Width <= ElementsCollision[i].X + ElementsCollision[i].SelectSprite.Width + 2)
                    //Contact avec droite
                    return 'r';
            }

            return 'x';
                
        }

        /// <summary>
        /// Gestion des sauts
        /// </summary>
        public void MoveUp(List<decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 't')
            {
                Y -= 3;
           
            }
        }

        public void MoveDown(List<decor> DecorColission)
        {
            if (GetCollision(DecorColission) != 'b')
            {
                Y += 3;

            }
        }

        public void ResetCompteur()
        {
            if (compteurFrame == 252)
                compteurFrame = 0;
        }
    }
}
