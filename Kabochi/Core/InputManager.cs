﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Kabochi
{
    namespace Core
    {
        class InputManager
        {
            public Game game;
            public InputManager(Game game_m)
            {
                game = game_m;
                game.gameForm.MouseClick += gameForm_MouseClick; //Слушаем клики мышью
                game.gameForm.KeyDown += gameForm_KeyDown;
                game.gameForm.MouseMove += gameForm_MouseMove;
                Console.WriteLine("Input module is loaded");
            }

            public void gameForm_MouseMove(object sender, MouseEventArgs e)
            {
                //throw new NotImplementedException();
            }

            public void gameForm_KeyDown(object sender, KeyEventArgs e)
            {
                Console.WriteLine(e.KeyData);
                switch (e.KeyData)
                {
                    case Keys.A:
                        lock (game.drawManager.grafx)
                        {
                            game.drawManager.grafx.Graphics.ScaleTransform(1.1f, 1.1f);
                        }
                        break;
                    case Keys.S:
                        lock (game.drawManager.grafx)
                        {
                            game.drawManager.grafx.Graphics.ScaleTransform(0.9f, 0.9f);
                            
                        }
                        break;
                    case Keys.R:
                        lock (game.drawManager.grafx)
                        {
                            game.drawManager.grafx.Graphics.ResetTransform();

                        }
                        break;
                    case Keys.Left:
                        lock (game.drawManager.grafx)
                        {
                            //game.drawManager.grafx.Graphics.TranslateTransform(-5, 0);
                            game.drawManager.view.targetx -= 5;
                        }
                        break;
                    case Keys.Right:
                        lock (game.drawManager.grafx)
                        {
                            //game.drawManager.grafx.Graphics.TranslateTransform(5,0);
                            game.drawManager.view.targetx += 5;
                        }
                        break;
                    case Keys.Up:
                        lock (game.drawManager.grafx)
                        {
                            //game.drawManager.grafx.Graphics.TranslateTransform(0, -5);
                            game.drawManager.view.targety -= 5;
                        }
                        break;
                    case Keys.Down:
                        lock (game.drawManager.grafx)
                        {
                            //game.drawManager.grafx.Graphics.TranslateTransform(0, 5);
                            game.drawManager.view.targety += 5;
                        }
                        break;
                    default:
                        break;
                }
                //throw new NotImplementedException();
            }

            public void gameForm_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Middle)
                {
                    game.drawManager.view.targetx = game.drawManager.view.x + e.X -game.gameForm.Width / 2;
                    game.drawManager.view.targety = game.drawManager.view.y + e.Y - game.gameForm.Height / 2;
                    Console.WriteLine("View is on " + game.drawManager.view.x + " " + game.drawManager.view.y);
                }
                Console.WriteLine(e.Button+" click on "+e.X+" "+e.Y);
            }
        }
    }
}