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

        public void moveLeft(float screenWidth)
        {
            if (!checkCollissionXMoveLeft(X, screenWidth))
              X -= 3;
        }

        public void moveRight(float screenWidth)
        {
            if (!checkCollissionXMoveRight(X,screenWidth))
                    X += 3;
        }

        /// <summary>
        /// Verifie si il y a collision avec l'écran. True si collision sinon False.
        /// </summary>
        /// <param name="posXchar"></param>
        /// <param name="screenWidth"></param>
        /// <returns></returns>
        private bool checkCollissionXMoveRight(float posXchar, float screenWidth)
        {
            if ((posXchar + _partOfTheSpriteToShow.Width + 3) >= screenWidth)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifie si il y a collision avec l'écran. True si collision sinon False.
        /// </summary>
        /// <param name="posXchar"></param>
        /// <param name="screenWidth"></param>
        /// <returns></returns>
        private bool checkCollissionXMoveLeft(float posXchar, float screenWidth)
        { 
           if ((posXchar - 3) <= 0)
                return true;
            else
                return false;
        }
        
    }
}
