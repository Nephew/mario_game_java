using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game
{
    class decor : sprite
    {  
        public decor(Texture2D uneTextureALoader, Vector2 positionActuelle,Rectangle selectSprite, float profondeur, bool enableColl)
            :base(uneTextureALoader,positionActuelle,selectSprite,profondeur)
        { }
    }
}
