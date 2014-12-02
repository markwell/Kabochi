﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabochi.Core
{
    class GameLogic
    {
        private Game game;
        public int i=0;
        public Random random;
        public IList<GameObject> objects;
        public int stageWidth;
        public int stageHeight;
        public GameLogic(Game game_m)
        {
            game = game_m;
            random = new Random();
            objects = game.objectManager.gameObjects;
            stageWidth = 3000;
            stageHeight = 3000;
            for (int i = 0; i < 10000; i++)
            {
                game.objectManager.addSnowFlake((float)(random.NextDouble() * stageWidth), (float)(random.NextDouble() * stageHeight), (float)(0.7+random.NextDouble()*2));
            }
            
        }

        public void GameStep()
        {
            game.inputManager.gameStep();
            
               // SnowFlake a = game.objectManager.addSnowFlake(game.drawManager.view.x + , game.drawManager.view.y + e.Y , (float)(5+game.gameLogic.random.NextDouble()*12));
            //objects.Sort(delegate(GameObject x, GameObject y)
             //   {   
                    //Из-за подобной проверки типов отжирается солидный кусок производительности (падение с 65 до 45 фпс при 10к объектов)
                                                                                                 // Через GetType - до 40
                    //Так что нужно это сделать красивее
                    //if (!(typeof(DrawableObject).IsInstanceOfType(x)) && !(typeof(DrawableObject).IsInstanceOfType(y))) return 0;
                    //else if (x.GetType().GetProperty("depth") == null) return 1; 
                    //else if (y.GetType().GetProperty("depth") == null) return -1;
                    //else if (!(typeof(DrawableObject).IsInstanceOfType(x))) return 1;
                    //else if (!(typeof(DrawableObject).IsInstanceOfType(y))) return -1;
                 //       DrawableObject dx = (DrawableObject) x;
                 //       DrawableObject dy = (DrawableObject) y;
                 //   if (dx.depth == dy.depth) return 0;
                 //   else if (dx.depth > dy.depth) return -1;
                 //   else return 1;
               // });
            //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(game.gameForm.Width/2, game.gameForm.Height/2);
            i++;
            
            game.drawManager.view.moveA();
            foreach (GameObject obj in objects)
            {
                obj.Update(this);
            }
        }
    }
}
