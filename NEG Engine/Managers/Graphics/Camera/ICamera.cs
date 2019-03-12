using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Graphics.Camera
{
    interface ICamera
    {
        Point   CameraPosition { get; set; }                        // The camera position

        bool    SpriteIsInFrame(ISprite Sprite);                    // Returns true if the the given sprite is inside the camera frame (needs to be rendered)

        Point   GetCameraRelativeCoords(ISprite Sprite);            // Converts absolute coordinates to camera relative ones, and returns it
        Point   GetCameraRelativeCoords(Point Coordinates);         // Converts absolute coordinates to camera relative ones, and returns it
    }
}
