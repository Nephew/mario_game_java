// Codé par Mathieu Rhéaume (ddrmanxbxfr@gmail.com) Quebec, Canada.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game
{
    /// <summary>
    /// Initialise un sprite.
    /// </summary>
    public class sprite
    {
        private Texture2D _TextureEn2d;
        private Vector2 _positionActuelle;
        private Vector2 _positionFrameSprite;
        protected Rectangle _partOfTheSpriteToShow;
        protected byte _nbFramesHoriz;
        protected byte _nbFramesVert;
        private byte _frameActuelleHoriz;
        private byte _frameActuelleVertical;
        private bool _active;
        private bool _spriteToBeUpdatedOrNot;
        private float _profondeur; // 0 = foreground 1 = background.

        //TODO Ajouter les autres constructeurs avec largeur et hauteur.
        //TODO Position dans le sprite pas la même que le sprite en tant que tel.

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
            _frameActuelleVertical = 0;
            _positionFrameSprite = new Vector2(0, 0);
            _positionActuelle = new Vector2(0, 0);
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X,(int)_positionActuelle.Y,uneTextureALoader.Width,uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, float profondeur)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _profondeur = profondeur;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = new Vector2(0, 0);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
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
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _positionFrameSprite = new Vector2(0, 0);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, Vector2 positionImageAAficher)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _positionFrameSprite = positionImageAAficher;
            _partOfTheSpriteToShow = new Rectangle((int)_positionFrameSprite.X, (int)_positionFrameSprite.Y, uneTextureALoader.Width, uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, int hauteur, int largeur)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, largeur, hauteur);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, Vector2 positionImageAAficher, int hauteur, int largeur)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _positionFrameSprite = positionImageAAficher;
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, largeur, hauteur);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, float profondeur)
        {
            _nbFramesHoriz = 1;
            _nbFramesVert = 1;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _profondeur = profondeur;
            _frameActuelleVertical = 0;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = positionActuelle;
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
        }


        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz)
        {
            if (nbFramesHoriz > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = 0;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = positionActuelle;
            _profondeur = 1;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, _nbFramesHoriz, _nbFramesVert);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz, float profondeur)
        {
            if (nbFramesHoriz > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = 0;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = positionActuelle;
            _profondeur = profondeur;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, _nbFramesHoriz, _nbFramesVert);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }


        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz)
        {
            if (nbFramesHoriz > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = 0;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = 1;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, _nbFramesHoriz, _nbFramesVert);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, float profondeur)
        {
            if (nbFramesHoriz > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = 0;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = profondeur;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, _nbFramesHoriz, _nbFramesVert);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }


        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _spriteToBeUpdatedOrNot = false;
            _frameActuelleVertical = 0;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = 1;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, float profondeur)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = profondeur;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz, byte nbFramesVertical)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, Vector2 positionActuelle, float profondeur)
        {
            if (nbFramesHoriz > 254 || nbFramesVertical > 254)
                throw new ArgumentException("Le nombre de frames est trop elevee");
            else
            {
                _nbFramesHoriz = nbFramesHoriz;
                _nbFramesVert = nbFramesVertical;
            }

            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = 1;
            _frameActuelleVertical = 0;
            _positionActuelle = positionActuelle;
            _profondeur = profondeur;
            _spriteToBeUpdatedOrNot = false;

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
            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = 0;
            _profondeur = 1;
            _positionActuelle = new Vector2(0, 0);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, float profondeur)
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
            _profondeur = profondeur;
            _spriteToBeUpdatedOrNot = false;
            _positionActuelle = new Vector2(0, 0);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, uneTextureALoader.Width, uneTextureALoader.Height);
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
            _profondeur = 1;
            _spriteToBeUpdatedOrNot = false;

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        /// <summary>
        /// Initialise un sprite.
        /// </summary>
        /// <param name="nombreDeFrames">Minimum 1 sinon il y a pas de frames</param>
        /// <param name="frameEnDisplay">Le numero de la sprite qui est actuellement choisis</param>
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, float profondeur)
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
            _profondeur = profondeur;
            _spriteToBeUpdatedOrNot = false;

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
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

            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = 1;

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        public sprite(Texture2D uneTextureALoader, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, byte frameEnDisplayHauteur, float profondeur)
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

            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = new Vector2(0, 0);
            _profondeur = profondeur;

            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
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

            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = positionActuelle;
            _profondeur = 1;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }

        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle, byte nbFramesHoriz, byte nbFramesVertical, byte frameEnDisplay, byte frameEnDisplayHauteur, float profondeur)
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

            _spriteToBeUpdatedOrNot = false;
            _TextureEn2d = uneTextureALoader;
            _frameActuelleHoriz = frameEnDisplay;
            _frameActuelleVertical = frameEnDisplayHauteur;
            _positionActuelle = positionActuelle;
            _profondeur = profondeur;
            Point sizeFramesPx = findSpriteSize(uneTextureALoader, nbFramesHoriz, nbFramesVertical);
            _partOfTheSpriteToShow = new Rectangle((int)_positionActuelle.X, (int)_positionActuelle.Y, (int)sizeFramesPx.X, (int)sizeFramesPx.Y);
        }


        #region Accesseurs
        public Vector2 PositionFrameSprite
        {
            get { return _positionFrameSprite; }
            set { _positionFrameSprite = value; }
        }

        public Rectangle PartOfTheSpriteToShow
        {get { return _partOfTheSpriteToShow; }}

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

        public float profondeur
        {
            get { return _profondeur; }
            set { _profondeur = value; }
        }

        public Vector2 PositionActuelle
            {
                get {return _positionActuelle; }
                set { _positionActuelle = value; }
            }

        public float X
        {get { return _positionActuelle.X; }
            set { _positionActuelle.X = value; }
        }

        public float Y
        {
            get { return _positionActuelle.Y; }
            set { _positionActuelle.Y = value; }
        }

        public bool SpriteToBeUpdatedOrNot
        {
            get { return _spriteToBeUpdatedOrNot; }
            set { _spriteToBeUpdatedOrNot = value; }
        }
        #endregion

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_active)
            {
                if (_spriteToBeUpdatedOrNot)
                    if (presenceDePlusieursFrame(_nbFramesVert, _nbFramesHoriz))
                        nextPartOfTheSprite();

                //Dessine le tout.
                spriteBatch.Draw(_TextureEn2d, _positionActuelle, _partOfTheSpriteToShow, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
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
            else
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
