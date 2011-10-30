using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace platform_game.libraries
{
    class sprites
    {
        private Texture2D uneTextureEn2d;


        public sprites(Texture2D uneTextureALoader)
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
