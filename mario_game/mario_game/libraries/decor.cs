using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game.libraries
{
    class decor
    { 
        private int posX = 0;
        private int posY = 0;
        private int width = 0;
        private int height = 0;
        private Texture2D sprite;
        private bool EnableColl;
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="posX">Position en largeur</param>
        /// <param name="posY">Position en haute</param>
        /// <param name="width">Largeur</param>
        /// <param name="height">Hauteur</param>
        /// <param name="sprite">Feuille de sprite relié à l'élément</param>
        public decor(int posX, int posY, int width, int height, Texture2D sprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.sprite = sprite;
        }

        public int PositionX
        {
            get { return posX; }
        }

        public int PositionY
        {
            get { return posY; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }
    }
}
