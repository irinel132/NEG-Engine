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
        protected   int         _sprite;                                // The actual Bitmap sprite

        protected   Point       _position;                              // The in engine position of the Sprite
        protected   Point       _scale;                                 // The scale of the sprite in X and Y axises. 100 is normal

        protected   bool        _flipped        = false;                // True if the sprite is flipped vertically
        protected   float       _rotation       = 0;                    // The rotation of the sprite in degrees

        // Constructors     
        public AbstractSprite(int Sprite, Point Position, Point Scale, bool Flipped, float Rotation)
        {
            // Asign the arguments to the internal variables
            _sprite         = Sprite;

            _position       = Position;
            _scale          = Scale;

            _flipped        = Flipped;
            _rotation       = Rotation;
        }        

        // Interface Methods

        // Getters and Setters for days 
        public int Sprite
        {
            get { return _sprite;       }
            set { _sprite = value;      }
        }
        public Point Scale
        {
            get { return _scale;        }
            set { _scale = value;       }
        }
        public Point Position
        {
            get { return getActualPosition();       }
            set { _position = value;                }
        }
        public float Rotation
        {
            get { return _rotation;     }
            set { _rotation = value;    }
        }
        public bool Flipped
        {
            get { return _flipped;      }
            set { _flipped = value;     }
        }


        // Methods
        protected Point getActualPosition()
        {
            int x = _position.X,    // Get the X and Y coordinates
                y = _position.Y;

            x   -=  256; // 512 / 2
            y   -=  256;

            return new Point(x, y);
        }
    }
}
