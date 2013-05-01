#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace FANEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Matrix worldTranslation = Matrix.Identity;
        Matrix worldRotation = Matrix.Identity;

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;
        BasicEffect basicEffect;

        Camera camera;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            camera = new Camera(this, new Vector3(0, 0, 5), Vector3.Forward, Vector3.Up);

            
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            VertexPositionColor[] vertexData = new VertexPositionColor[8];
            vertexData[0] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.SaddleBrown);    // LEFT BOTTOM BACK
            vertexData[1] = new VertexPositionColor(new Vector3(1, -1, -1), Color.SaddleBrown);     // RIGHT BOTTOM BACK
            vertexData[2] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.SaddleBrown);     // LEFT BOTTOM FRONT
            vertexData[3] = new VertexPositionColor(new Vector3(1, -1, 1), Color.SaddleBrown);      // RIGHT BOTTOM FRONT
            vertexData[4] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);           // LEFT TOP BACK
            vertexData[5] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);            // RIGHT TOP BACK
            vertexData[6] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);            // LEFT TOP FRONT
            vertexData[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);             // RIGHT TOP FRONT

            // Array of quads/blocks.  Each vertexpositionColor(new Vector3(1,1,1) * arrayIndex;



            // Create our vertexBuffer
            vertexBuffer = new VertexBuffer(GraphicsDevice,
                                            typeof(VertexPositionColor), vertexData.Length,
                                            BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(vertexData);

            short[] indexData = new short[36];

            // Front Quad
            indexData[0] = 6;
            indexData[1] = 7;
            indexData[2] = 2;
            indexData[3] = 7;
            indexData[4] = 3;
            indexData[5] = 2;

            // Back Quad
            indexData[6] = 5;
            indexData[7] = 4;
            indexData[8] = 1;
            indexData[9] = 4;
            indexData[10] = 0;
            indexData[11] = 1;

            // Left Quad
            indexData[12] = 4;
            indexData[13] = 6;
            indexData[14] = 0;
            indexData[15] = 6;
            indexData[16] = 2;
            indexData[17] = 0;

            // Right Quad
            indexData[18] = 7;
            indexData[19] = 5;
            indexData[20] = 3;
            indexData[21] = 5;
            indexData[22] = 1;
            indexData[23] = 3;

            // Top Quad
            indexData[24] = 4;
            indexData[25] = 5;
            indexData[26] = 6;
            indexData[27] = 5;
            indexData[28] = 7;
            indexData[29] = 6;

            // Bottom Quad
            indexData[30] = 2;
            indexData[31] = 3;
            indexData[32] = 0;
            indexData[33] = 3;
            indexData[34] = 1;
            indexData[35] = 0;

            // Create our IndexBuffer
            indexBuffer = new IndexBuffer(GraphicsDevice, IndexElementSize.SixteenBits,
                                          36, BufferUsage.None);
            indexBuffer.SetData<short>(indexData);

            // Create new basic effect and properties
            basicEffect = new BasicEffect(GraphicsDevice);
            //basicEffect.World = Matrix.Identity;
            //basicEffect.View = Matrix.CreateLookAt(new Vector3(0, 0, 3),
            //                                       new Vector3(0, 0, 0),
            //                                       new Vector3(0, 1, 0));

            //basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
            //                                              GraphicsDevice.Viewport.AspectRatio,
            //                                              0.1f, 100.0f);


            basicEffect.VertexColorEnabled = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Input.IsKeyDown(Keys.Up))
            {
                worldRotation *= Matrix.CreateRotationX(-MathHelper.PiOver4 / 60);
            }
            if (Input.IsKeyDown(Keys.Down))
            {
                worldRotation *= Matrix.CreateRotationX(MathHelper.PiOver4 / 60);
            }
            if (Input.IsKeyDown(Keys.Left))
            {
                worldRotation *= Matrix.CreateRotationY(-MathHelper.PiOver4 / 60);
            }
            if (Input.IsKeyDown(Keys.Right))
            {
                worldRotation *= Matrix.CreateRotationY(MathHelper.PiOver4 / 60);
            }

            if (Input.IsKeyDown(Keys.W))
            {
                camera.MoveCamera(new Vector3(0, 0, -1));
            }
            if (Input.IsKeyDown(Keys.A))
            {
                camera.MoveCamera(new Vector3(-1, 0, 0));
            }
            if (Input.IsKeyDown(Keys.S))
            {
                camera.MoveCamera(new Vector3(0, 0, 1));
            }
            if (Input.IsKeyDown(Keys.D))
            {
                camera.MoveCamera(new Vector3(1, 0, 0));
            }

            Input.Update();
            camera.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            basicEffect.World = worldRotation * worldTranslation;
            basicEffect.View = camera.View;
            basicEffect.Projection = camera.Projection;

            // Set which vertex buffer to use
            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            // Set which index buffer to use
            GraphicsDevice.Indices = indexBuffer;

            // Set which effect to use
            basicEffect.CurrentTechnique.Passes[0].Apply();

            // Draw the triangle using the vertex buffer
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 36);

            base.Draw(gameTime);
        }
    }
}
