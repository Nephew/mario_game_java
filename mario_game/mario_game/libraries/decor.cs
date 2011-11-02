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
        private byte width;
        private byte height;
        private sprite sprite;
        private colision colision;
        private byte pos_x;
        private byte pos_y;
        


        public decor(byte width, byte height, Texture2D sprite, byte pos_x, byte pos_y)
        {
            this.width = width;
            this.height = height;
            this.sprite = new sprite(sprite, width, height);
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }
    }
}
