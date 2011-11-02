using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool ColisionGround()
        {
            if (charac.PositionY <= -768 + 138)
                return true;

            return false;
        }
    }
}
