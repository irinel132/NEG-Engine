using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Hitbox
{
    class TestTrigger : AbstractHitbox
    {
        public TestTrigger(Point Origin, Point Size) : base(Origin, Size)
        {

        }

        public override void OnCollission(IHitbox CollidedWith, long Ticks)
        {
            Console.WriteLine("Collided with " + CollidedWith.ToString() + " at " + Ticks.ToString() + " Ticks");
        }
    }
}
