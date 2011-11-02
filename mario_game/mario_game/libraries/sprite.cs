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
        private byte _nbFramesHoriz;
        private byte _nbFramesVert;

        private byte _frameActuelleHoriz;
        private byte _frameActuelleVertical;
        private bool _active;

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFramesHoriz, byte nbFramesHauteur)
        {
            if (nombreDeFramesHoriz > 254 || nbFramesHauteur > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else if (nombreDeFramesHoriz == 0 || nbFramesHauteur == 0)
                throw new ArgumentException("Il y a présence d'aucune frames.");
            else
            {
                _nbFramesHoriz = nombreDeFramesHoriz;
                _nbFramesVert = nbFramesHauteur;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nombreDeFramesHoriz, byte nbFramesHauteur, byte frameEnDisplay)
        {
            if (nombreDeFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesHauteur > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nombreDeFramesHoriz;
                _nbFramesVert = nbFramesHauteur;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = 0;
        }

        public sprite(Texture2D uneTextureALoader, byte nombreDeFramesHoriz, byte nbFramesHauteur, byte frameEnDisplay, byte frameEnDisplayHauteur)
        {
            if (nombreDeFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesHauteur > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nombreDeFramesHoriz;
                _nbFramesVert = nbFramesHauteur;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
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
            { return _nbFramesHoriz; }
        }

        public byte FrameActuelle
        {
            get
            { return _frameActuelleHoriz; }
        }

        public bool Active
        {
            get {return _active;}
            set {_active = value;}
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            if (presenceDePlusieursFrame(_nbFramesVert,_nbFramesHoriz))
                nextPartOfTheSprite();
            //Dessine le tout.
            spriteBatch.Draw(_TextureEn2d, _positionActuelle, _partOfTheSpriteToShow, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

       /// <summary>
       /// Verification si il y a plusieurs frames ou non.
       /// </summary>
       /// <param name="nbFrameVert"></param>
       /// <param name="nbFrameHoriz"></param>
       /// <returns>True si il y en a plusieurs sinon false.</returns>
        private bool presenceDePlusieursFrame(byte nbFrameVert, byte nbFrameHoriz)
        {
            if (nbFrameHoriz > 1 || nbFrameVert > 1)
                return true;
            return false;
        }

        private void nextPartOfTheSprite()
        {
            if (_nbFramesHoriz != 1)
            {
                if (_frameActuelleHoriz == _nbFramesHoriz)
                {
                    _frameActuelleHoriz = 1;
                    if (_frameActuelleVertical == _nbFramesVert)
                        _frameActuelleVertical = 1;
                    else
                        _frameActuelleVertical++;
                }
                else
                    _frameActuelleHoriz++;
            }
        }
    }
}
