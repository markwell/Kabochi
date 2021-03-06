﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Kabochi
{
    class Hero: DrawableObject
    {
        public Brush brush;
        public Random random;
        private System.Windows.Point previousPosition;
        public Hero(float x_m, float y_m, float scale_m)
        {
            solid = true;
            movable = true;
            random = new Random();
            drawable = true;
            depth = -5;
            //_angle = 270;
            _speed = 4f;
            CalculateVector();
            position = new System.Windows.Point(x_m, y_m);
            previousPosition = position;
            width = height = scale_m * 5;
            brush = Brushes.Blue;
        }
        override public void Draw(BufferedGraphics grafx, float x, float y)
        {
            //grafx.Graphics.FillRectangle(brush, x, y, width, height);
            for (int i = 0; i < 120; i++)
                grafx.Graphics.FillRectangle(brush, (float)(x + random.NextDouble() * width), (float)(y + random.NextDouble() * height), 1, 1);
        }

        override public void Update(Core.GameLogic gameLogic)
        {
            previousPosition = position;
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Up))
                position.Y -= _speed;
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Down))
                position.Y += _speed;
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
                position.X -= _speed;
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
                position.X += _speed;
            //MoveVector();
        }

        public override void CollisionWith(DrawableObject b)
        {
            base.CollisionWith(b);
            if (b.GetType().Name=="Wall")
            {
                position = previousPosition;
            }
        }
    }
}
