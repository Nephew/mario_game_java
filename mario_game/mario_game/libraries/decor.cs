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
        private byte posX = 0;
        private byte posY = 0;
        private byte width = 0;
        private byte height = 0;
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
        public decor(byte posX, byte posY, byte width, byte height, Texture2D sprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.sprite = sprite;
        }

        public byte PositionX
        {
            get { return posX; }
        }

        public byte PositionY
        {
            get { return posY; }
        }

        public byte Height
        {
            get { return height; }
        }

        public byte Width
        {
            get { return width; }
        }

        private void Draw()
        {
        }
    }
}
