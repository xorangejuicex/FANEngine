using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FANEngine
{
    class Camera
    {
        private Matrix world;
        private Matrix view;
        private Matrix projection;

        private Vector3 position;

        public Matrix World
        {
            get { return world; }
        }

        public Matrix View
        {
            get { return view; }
        }

        public Matrix Projection
        {
            get { return projection; }
        }

        public Vector3 Position
        {
            get { return position; }
        }

        public Camera(Game game, Vector3 initialPos, Vector3 target, Vector3 up)
        {
            //world = Matrix.Identity;
            //view = CreateLookAt();
            //projection = CreatePerspectiveFieldOfView();

            world = Matrix.Identity;
            view = Matrix.CreateLookAt(initialPos, target, up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100.0f);

            position = initialPos;            
        }

        public void Update()
        {
            view = Matrix.CreateLookAt(position, Vector3.Forward + position, Vector3.Up);
        }

        private Matrix CreatePerspectiveFieldOfView()
        {
            Matrix p = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16 / 9f, 0.1f, 100.0f);

            return p;
        }

        public void MoveCamera(Vector3 v)
        {
            position += v;
        }
    }
}
