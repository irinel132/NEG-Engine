using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NEG_Engine.Sprites;

namespace NEG_Engine.Managers.Graphics.Camera
{
    abstract class AbstractCamera : ICamera
    {
        // Internal variables
        protected   IGraphicsManager _graphicsManager   = null;

        protected   Point           _cameraPositon;                                 // Camera position               

        // Constructor
        public AbstractCamera(IGraphicsManager GraphicsManager)
        {
            _graphicsManager    = GraphicsManager;  // Save the graphics manager
            _cameraPositon      = new Point(0, 0);  // Default the initial camera position to 0, 0
        }


        // Interface Methods
        public Point CameraPosition
        {
            get { return _cameraPositon;    }
            set { _cameraPositon = value;   }
        }

        public Point GetCameraRelativeCoords(ISprite Sprite)
        {
            // Simply substract the sprite coords by the camera's and return the new coordinates
            return new Point
                (
                    Sprite.Position.X - _cameraPositon.X,
                    Sprite.Position.Y - _cameraPositon.Y
                );
        }

        public Point GetCameraRelativeCoords(Point Coordinates)
        {
            // Simply substract the coords by the camera's and return the new coordinates
            return new Point
                (
                    Coordinates.X - _cameraPositon.X,
                    Coordinates.Y - _cameraPositon.Y
                );
        }

        public bool SpriteIsInFrame(ISprite Sprite)
        {
            // Returns true if the sprite in inside the camera frame (between camera's position and camera's position + resolution)
            return
                (
                    (Sprite.Position.X >= _cameraPositon.X) && (Sprite.Position.X <= (_cameraPositon.X + _graphicsManager.RenderResolution.X)) &&
                    (Sprite.Position.Y >= _cameraPositon.Y) && (Sprite.Position.Y <= (_cameraPositon.Y + _graphicsManager.RenderResolution.Y))
                );
        }

        // Internal methods
    }
}
