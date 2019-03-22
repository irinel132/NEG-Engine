using NEG_Engine.Factories.Hitbox;
using NEG_Engine.Factories.Sprite;
using NEG_Engine.Hitbox;
using NEG_Engine.Input;
using NEG_Engine.Mind;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine.Game
{
    class Player : AbstractMind, IInputListener, IHitbox
    {
        protected ISprite   sprite      = null;
        protected Point     location;

        protected Keys[]    controlls   = null;
        protected bool[]    actions     = null;

        protected bool      facingLeft  = false;

        protected Point         speed;
        protected readonly int  max_speed       = 12;
        protected readonly int  acceleration    = 2;

        public Player(int X, int Y, Keys[] Controlls, int Sprite)
        {
            MIND_TAG    = "PLAYER";

            location    = new Point(X, Y);

            controlls   = Controlls;
            actions     = new bool[controlls.Length];

            speed = new Point(0);

            sprite      = SpriteFactory.GetNewSprite(() => new TestSprite(Sprite, location, 0.5f, false, 0));

            HitboxFactory.RegisterHitbox(this);
            InputHandler.Instance.Subscribe(this);
        }

        public Point Origin { get { return location; } set { } }
        public Point Size { get => new Point((int) (128 * sprite.Scale), (int)(128 * sprite.Scale)); set { } }

        public Rectangle GetHitboxArea()
        {
            return new Rectangle(location, new Size(Size));
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < controlls.Length; i++)
                if (e.KeyCode == controlls[i]) { actions[i] = true; }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < controlls.Length; i++)
                if (e.KeyCode == controlls[i]) { actions[i] = false; }
        }

        public void OnCollission(IHitbox CollidedWith, long Ticks)
        {
            Point CLocation = CollidedWith.Origin;

            int x = Math.Abs(CLocation.X - location.X);
            int y = Math.Abs(CLocation.Y - location.Y);

            if (x >= y) {speed.X = 0; }
            if (y >= x) {speed.Y = 0; }
        }

        public override void Tick(long Tick)
        {
            Movement();

            location.X += speed.X;
            location.Y += speed.Y;

            sprite.Position     = location;
            sprite.Flipped      = facingLeft;
        }

        protected void Movement()
        {
            if ( actions[0] && speed.Y > -max_speed) { speed.Y -= acceleration; }
            if ( actions[1] && speed.Y < max_speed)  { speed.Y += acceleration; }
            if (!actions[0] && !actions[1] && speed.Y != 0) { speed.Y += (speed.Y > 0 ? -acceleration : acceleration); }

            if ( actions[2] && speed.X > -max_speed) { speed.X -= acceleration; facingLeft = true;  }
            if  (actions[3] && speed.X < max_speed) { speed.X += acceleration;  facingLeft = false; }
            if (!actions[2] && !actions[3] && speed.X != 0) { speed.X += (speed.X > 0 ? -acceleration : acceleration); }
        }
    }
}
