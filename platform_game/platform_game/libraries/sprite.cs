using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace platform_game.libraries
{
    class sprite
    {
        private Texture2D uneTextureEn2d;


        public sprite(Texture2D uneTextureALoader)
        {
            uneTextureEn2d = uneTextureALoader;
        }

        public Texture2D texture
        {
            get
            { return uneTextureEn2d; }
        }
    }
}
