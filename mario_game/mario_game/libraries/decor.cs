using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game.libraries
{
    class decor : sprite
    { 
        private bool EnableColl;
       
        public decor(Texture2D uneTextureALoader)
            :base(uneTextureALoader)
        {}

        public decor(Texture2D uneTextureALoader, Vector2 positionActuelle)
            : base(uneTextureALoader, positionActuelle)
        { }

        public decor(Texture2D uneTextureALoader,int y, int x)
            :base(uneTextureALoader, new Vector2(x,y))
        {}

        public decor(Texture2D uneTextureALoader, int y, int x,  byte nbFramesHoriz)
            :base(uneTextureALoader, new Vector2(x,y), nbFramesHoriz)
        {}

        public decor(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz)
            : base(uneTextureALoader, positionActuelle, nbFramesHoriz)
        { }
    }
}
