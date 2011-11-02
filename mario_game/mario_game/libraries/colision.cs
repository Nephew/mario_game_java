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

namespace mario_game.libraries
{
    class colision
    {
        private charac charac;
        private decor elementDecor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charac1">Personnage à gérer</param>
        public colision(charac charac1)
        {
            this.charac = charac1;
        }

    }
}
