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
        private charac charac = null;
        private List<decor> ElementsDecor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charac1">Personnage à gérer</param>
        public colision(charac charac1, List<decor> ElementDecor)
        {
            this.charac = charac1;
            this.ElementsDecor = ElementDecor;
        }

        public bool CheckColision()
        {
            for (byte i = 0; i < ElementsDecor.Count; i++)
            {
                if (charac.PositionX > ElementsDecor[i].PosX && charac.PositionX < ElementsDecor[i].PosX + ElementsDecor[i].Width
                    && charac.PositionY > ElementsDecor[i].PosY && charac.PositionY < ElementsDecor[i].PosX + ElementsDecor[i].Height)
                    return true;
            }

            return false;
        }
    }
}
