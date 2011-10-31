using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game.libraries
{
    class sprite
    {
        private Texture2D _TextureEn2d;
        private Vector2 positionActuelle;
        private Vector2 partOfTheSpriteToShow;
        private byte _nombreDeFrames;
        private byte _frameActuelle;

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFrames)
        {
            if (nombreDeFrames > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            _TextureEn2d = uneTextureALoader;
            _frameActuelle = 1;
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFrames, byte frameEnDisplay)
        {
            if (nombreDeFrames > 254 || frameEnDisplay > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelle = frameEnDisplay;
        }

        #region Accesseurs
        public Texture2D TextureUsed
        {
            get
            { return _TextureEn2d; }
        }

        public byte NombresDeFramesDansLeSprite
        {
            get
            { return _nombreDeFrames; }
        }

        public byte FrameActuelle
        {
            get
            { return _frameActuelle; }
        }
        #endregion

        private void nextPartOfTheSprite()
        {
            if (_nombreDeFrames != 1)
            {
                if (_frameActuelle == _nombreDeFrames)
                {
                    _frameActuelle = 1;
                }
                else
                    _frameActuelle++;
            }
        }
    }
}
