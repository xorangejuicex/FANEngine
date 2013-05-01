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

        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up)
        {
            //world = Matrix.Identity;
            //view = CreateLookAt();
            //projection = CreatePerspectiveFieldOfView();

            world = Matrix.Identity;
            view = Matrix.CreateLookAt(pos, target, up);
            projection = CreatePerspectiveFieldOfView();
            
        }

        private Matrix CreateLookAt()
        {
            Matrix v = Matrix.CreateLookAt(new Vector3(0, 0, 3), Vector3.Forward, Vector3.Up);

            return v;
        }

        private Matrix CreatePerspectiveFieldOfView()
        {
            Matrix p = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16 / 9f, 0.1f, 100.0f);

            return p;
        }
    }
}
