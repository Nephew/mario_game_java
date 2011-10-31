// Codé par Mathieu Rhéaume (ddrmanxbxfr@gmail.com) Quebec, Canada.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game.libraries
{
    /// <summary>
    /// Initialise un sprite.
    /// </summary>
    class sprite
    {
        private Texture2D _TextureEn2d;
        private Vector2 _positionActuelle;
        private Rectangle _partOfTheSpriteToShow;
        private byte _nombreDeFrames;
        private byte _nombreFramesHauteur;
        private byte _frameActuelle;
        private bool _active;

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFramesLargeur, byte nombreFramesHauteur)
        {
            if (nombreDeFramesLargeur > 254 || nombreFramesHauteur > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nombreDeFrames = nombreDeFramesLargeur;
                _nombreFramesHauteur = nombreFramesHauteur;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelle = 1;
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFramesLargeur, byte nombreFramesHauteur, byte frameEnDisplay)
        {
            if (nombreDeFramesLargeur > 254 || frameEnDisplay > 254 || nombreFramesHauteur > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nombreDeFrames = nombreDeFramesLargeur;
                _nombreFramesHauteur = nombreFramesHauteur;
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

        public bool Active
        {
            get {return _active;}
            set {_active = value;}
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            //Dessine le tout.
            spriteBatch.Draw(_TextureEn2d, _positionActuelle, _partOfTheSpriteToShow, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

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
