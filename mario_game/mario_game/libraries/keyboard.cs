using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace mario_game.libraries
{
    /// <summary>
    /// Gestion du clavier !
    /// </summary>
    class keyboard
    {
        Keys _laToucheEnHaut;
        Keys _laToucheEnBas;
        Keys _laToucheADroite;
        Keys _laToucheAGauche;
        Keys _laToucheJump;

        public keyboard(Keys laToucheEnHaut, Keys laToucheEnBas, Keys laToucheADroite, Keys laToucheAGauche, Keys laToucheASauter)
        {_laToucheADroite = laToucheADroite; _laToucheEnBas = laToucheEnBas; _laToucheEnHaut = laToucheEnHaut; _laToucheAGauche = laToucheAGauche; _laToucheJump = laToucheASauter; }

        public bool moveUp(KeyboardState etatDuKeyboard, Keys laToucheAVerifier)
        {
            if (etatDuKeyboard.IsKeyDown(_laToucheEnHaut))
                return true;
            else
                return false;
        }

        public bool moveDown(KeyboardState etatDuKeyboard)
        {
            if (etatDuKeyboard.IsKeyDown(_laToucheEnBas))
                return true;
            else
                return false;
        }

        public bool moveLeft(KeyboardState etatDuKeyboard)
        {
            if (etatDuKeyboard.IsKeyDown(_laToucheAGauche))
                return true;
            else
                return false;
        }

        public bool moveRight(KeyboardState etatDuKeyboard)
        {
            if (etatDuKeyboard.IsKeyDown(_laToucheADroite))
                return true;
            else
                return false;
        }

        public bool jump(KeyboardState etatDuKeyboard)
        {
            if (etatDuKeyboard.IsKeyDown(_laToucheJump))
                return true;
            else
                return false;
        }
    }
}
