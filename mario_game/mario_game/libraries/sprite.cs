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
        public sprite(Texture2D uneTextureALoader)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _positionActuelle = new Vector2(0, 0);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X,(int)_positionActuelle.Y,uneTextureALoader.Width,uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _positionActuelle = positionActuelle;
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else if (nbFramesHoriz == 0 || nbFramesVertical == 0)
                throw new ArgumentException("Il y a présence d'aucune frames.");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _positionActuelle = new Vector2(0, 0);

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, Vector2 positionActuelle)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else if (nbFramesHoriz == 0 || nbFramesVertical == 0)
                throw new ArgumentException("Il y a présence d'aucune frames.");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _positionActuelle = positionActuelle;


            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay)
        {
            if (nbFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesVertical > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = 0;
            _positionActuelle = new Vector2(0, 0);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, Vector2 positionActuelle)
        {
            if (nbFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesVertical > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
        }

        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, byte frameEnDisplayHauteur)
        {
            if (nbFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesVertical > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = new Vector2(0, 0);
        }

        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, byte frameEnDisplayHauteur, Vector2 positionActuelle)
        {
            if (nbFramesHoriz > 254 || frameEnDisplay > 254 || nbFramesVertical > 254)
            {
                throw new ArgumentException("Le nombre de frames est trop elevee");
            }
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = positionActuelle;
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

        public Vector2 PositionActuelle
            {
                get {return _positionActuelle; }
                set { value = _positionActuelle; }
            }

        public float X
        {get { return _positionActuelle.X; }}

        public float Y
        {get { return _positionActuelle.Y; }}
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

        /// <summary>
        /// Trouve la taille d'un seul sprite afin d'initaliser le rectangle des sprites.
        /// </summary>
        /// <param name="laTextureATraiter"></param>
        /// <param name="nbFramesHoriz">Nombre de frames à l'horizontal</param>
        /// <param name="nbFramesVertical">Nombre de frames à vertical</param>
        /// <returns></returns>
        private Point findSpriteSize(Texture2D laTextureATraiter, byte nbFramesHoriz, byte nbFramesVertical)
        {
            Point maSpriteSize;
            maSpriteSize.Y = 0; maSpriteSize.X = 0;

            if (nbFramesVertical == 0)
            {
                if (nbFramesHoriz == 0)
                { maSpriteSize.X = laTextureATraiter.Width; maSpriteSize.Y = laTextureATraiter.Height; }
                else
                {
                    maSpriteSize.X = (laTextureATraiter.Width / nbFramesHoriz);
                    maSpriteSize.Y = laTextureATraiter.Height;
                }
            }
            else
            {
                if (nbFramesHoriz == 0)
                {
                    maSpriteSize.X = laTextureATraiter.Width;
                    maSpriteSize.Y = (laTextureATraiter.Height / nbFramesVertical);
                }
                // Rendu ici ça veux dire que il y a des frames horizontales et verticales.
                else
                {
                    maSpriteSize.X = (laTextureATraiter.Width / nbFramesHoriz);
                    maSpriteSize.Y = (laTextureATraiter.Height / nbFramesVertical);
                }  
          }

            return maSpriteSize;
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

        /// <summary>
        /// Pour définir une taille ou une location.
        /// </summary>
        private struct Point { public float X; public float Y;};
    }
}
