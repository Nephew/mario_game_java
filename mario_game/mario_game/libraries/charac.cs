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
        public charac(Texture2D uneTextureALoader, Vector2 positionActuelle, Rectangle selectSprite, float profondeur)
            : base(uneTextureALoader, positionActuelle, selectSprite, profondeur)
        { }

        public void moveLeft(float screenWidth, List<decor> ElementsCollisionable)
        {
            if (!checkCollissionXMoveLeft(screenWidth, ElementsCollisionable))
              X -= 3;
        }

        public void moveRight(float screenWidth, List<decor> ElementsCollisionable)
        {
            if (!checkCollissionXMoveRight(screenWidth, ElementsCollisionable))
                    X += 3;
        }

        public void moveUp(List<decor> ElementsCollisionable)
        {
            if (!checkCollissionYJump(ElementsCollisionable))
            Y -= 3;
        }

        public void moveDown(List<decor> ElementsCollisionable)
        {
            if (!checkCollissionLanding(ElementsCollisionable))
            Y += 3;
        }

        /// <summary>
        /// Verifie si il y a collision avec l'écran. True si collision sinon False.
        /// </summary>
        /// <param name="posXchar"></param>
        /// <param name="screenWidth"></param>
        /// <returns></returns>
        private bool checkCollissionXMoveRight(float screenWidth, List<decor> ElementsCollisionable)
        {
            for (int i = 0; i < ElementsCollisionable.Count; i++)
            {
                if ((X + _partOfTheSpriteToShow.Width + 3) >= screenWidth || (X + SelectSprite.Height - 7 >= ElementsCollisionable[i].X &&
                    Y + SelectSprite.Height - 2 >= ElementsCollisionable[i].PositionActuelle.Y && Y <= ElementsCollisionable[i].PositionActuelle.Y +
                    ElementsCollisionable[i].SelectSprite.Height && X + SelectSprite.Height <= ElementsCollisionable[i].X + 9))
                    return true;
            }
                return false;
        }

        /// <summary>
        /// Verifie si il y a collision avec l'écran. True si collision sinon False.
        /// </summary>
        /// <param name="posXchar"></param>
        /// <param name="screenWidth"></param>
        /// <returns></returns>
        private bool checkCollissionXMoveLeft(float screenWidth, List<decor> ElementsCollisionable)
        {
            for (int i = 0; i < ElementsCollisionable.Count;i++ )
            {
                if ((X - 3) <= 0 || (X <= ElementsCollisionable[i].PositionActuelle.X + ElementsCollisionable[i].SelectSprite.Width &&
                    Y + SelectSprite.Height - 2 >= ElementsCollisionable[i].PositionActuelle.Y && Y <= ElementsCollisionable[i].PositionActuelle.Y +
                    ElementsCollisionable[i].SelectSprite.Height && X + 2 >= ElementsCollisionable[i].X + ElementsCollisionable[i].SelectSprite.Width))
                    return true;
            }
                    return false;
        }

        private bool checkCollissionYJump(List<decor> ElementsCollisionable)
        {
            for (int i = 0; i < ElementsCollisionable.Count;i++ )
            {
                if(Y > ElementsCollisionable[i].Y + ElementsCollisionable[i].SelectSprite.Height && X <= ElementsCollisionable[i].X + ElementsCollisionable[i].SelectSprite.Width
                && X + SelectSprite.Height >= ElementsCollisionable[i].X && Y - 2 < ElementsCollisionable[i].Y + ElementsCollisionable[i].SelectSprite.Height)
                return true;
            }

            return false;
        }

        private bool checkCollissionLanding(List<decor> ElementsCollisionable)
        {
            for (int i = 0; i < ElementsCollisionable.Count; i++)
            {
                if(Y + SelectSprite.Height >= ElementsCollisionable[i].Y  && X <= ElementsCollisionable[i].X + ElementsCollisionable[i].SelectSprite.Width
                && X + SelectSprite.Height >= ElementsCollisionable[i].X && Y + SelectSprite.Height - 2 <= ElementsCollisionable[i].Y)
                    return true;
            }
            return false;
        }
        
    }
}
