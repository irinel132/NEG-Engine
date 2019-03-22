using NEG_Engine.Hitbox;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using NEG_Engine.Hitbox;

namespace NEG_Engine.Game
{
    class Obstacle : AbstractSprite, IHitbox
    {
        public Obstacle(int X, int Y, bool Flipped) : base(3, new Point(X, Y), 0.45f, Flipped, 0)
        {
            
        }

        public Point Origin { get => _position; set { } }
        public Point Size { get => new Point((int)(512 * _scale), (int)(300 * _scale)); set { } }
        public Rectangle GetHitboxArea()
        {
            return new Rectangle(_position, new Size(Size));
        }

        public void OnCollission(IHitbox CollidedWith, long Ticks)
        {
            
        }
    }
}
