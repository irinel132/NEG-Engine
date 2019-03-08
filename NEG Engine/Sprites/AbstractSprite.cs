using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Sprites
{
    abstract class AbstractSprite : ISprite
    {
        // Internval variables
        protected   Bitmap      _sprite         = null;                 // The actual Bitmap sprite

        protected   Point       _position;                              // 
        protected   Point       _scale;                                 // 

        protected   bool _      flipped         = null;                 // 
        protected   float       _rotation       = null;                 // 

        // Constructors


        // Interface Methods
        public Bitmap Sprite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Scale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Rotation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Flipped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        // Methods
    }
}
