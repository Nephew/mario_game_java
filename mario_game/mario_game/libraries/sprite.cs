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
        protected Rectangle _partOfTheSpriteToShow;
        private bool _active = true;
        private float _profondeur; // 0 = foreground 1 = background.

        //TODO Ajouter les autres constructeurs avec largeur et hauteur.
        //TODO Position dans le sprite pas la même que le sprite en tant que tel.

        #region "Constructeurs"
        public sprite(Texture2D uneTextureALoader, Vector2 positionActuelle,Rectangle selectSprite, float profondeur)
        {
            _TextureEn2d = uneTextureALoader;
            _positionActuelle = positionActuelle;
            _profondeur = profondeur;
            _partOfTheSpriteToShow = selectSprite;
        }
        #endregion

        #region Accesseurs

        public Rectangle SelectSprite
        {
            get { return _partOfTheSpriteToShow; }
            set { _partOfTheSpriteToShow = value; }
        }

        public Texture2D TextureUsed
        {
            get
            { return _TextureEn2d; }
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

        /// <summary>
        /// Position personnage au X
        /// </summary>
        public float X
        {get { return _positionActuelle.X; }
            set { _positionActuelle.X = value; }
        }

        /// <summary>
        /// Position personnage au Y
        /// </summary>
        public float Y
        {
            get { return _positionActuelle.Y; }
            set { _positionActuelle.Y = value; }
        }
        #endregion

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_active)
            {
                //Dessine le tout.
                spriteBatch.Draw(_TextureEn2d, _positionActuelle, _partOfTheSpriteToShow, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
       }
    }
}
