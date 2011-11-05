using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;


namespace mario_game.libraries
{
    class config
    {
        Keys _laToucheEnHaut;
        Keys _laToucheEnBas;
        Keys _laToucheADroite;
        Keys _laToucheAGauche;
        Keys _laToucheJump;
        Keys _laToucheEnter;
        int height;
        int width;

        public config()
        { }

        /// <summary>
        /// Charge la configuration en assumant que le fichier de config est config.ini.
        /// </summary>
        public void loadConfig()
        {
            System.IO.StreamReader lecteurDeFichier = new System.IO.StreamReader("config.ini");

            string toucheHautATraiter = lecteurDeFichier.ReadLine();
            toucheHautATraiter = toucheHautATraiter.Substring(7, toucheHautATraiter.Length - 7);
            string toucheBasATraiter;
            string toucheADroiteTraiter;
            string toucheAGaucheTraiter;
            string toucheJUMPAtraiter;
            string toucheENTERATraiter;
            string heightATraiter;
            string widthATraiter;


        }

        public void saveConfig()
        { }

        private Keys evaluateWhichKey(string strATraiter)
        {

            return Keys.Attn;
        }
    }
}
