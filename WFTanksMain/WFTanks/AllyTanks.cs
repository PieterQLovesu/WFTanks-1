﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFTanks
{
    class AllyTanks : Tanks
    {
        public Form1 FormAccess;

        public AllyTanks(Form1 FormConstruct)
        {
            FormAccess = FormConstruct;
            Side = Sides.Buddy;
        }
        
        public override void Shot(Game.Move TankDirection)
        {
            Bullet Bullets = new Bullet(TankDirection, FormAccess, FormAccess.AllieTanksDesign);
            Bullets.BulletMove(FormAccess.AllieTanksDesign);
        }
        
        public override void Movement(Game.Move Move, Game game)
        {
            var MoveDown = new Action(() => {if (!(FormAccess.AllieTanksDesign.Top > 660)) { FormAccess.AllieTanksDesign.Top += 3; } } );
            var MoveUp = new Action(() => {  { if (!(FormAccess.AllieTanksDesign.Top < 0)) { FormAccess.AllieTanksDesign.Top -= 3; } } });
            var MoveLeft = new Action(() => {  if (!(FormAccess.AllieTanksDesign.Left < 0)) FormAccess.AllieTanksDesign.Left -= 3; });
            var MoveRight = new Action(() =>{ if (!(FormAccess.AllieTanksDesign.Left > 720)) { FormAccess.AllieTanksDesign.Left += 3;  } });

            Task MovementTask = new Task(() =>
            {
                if (Game.Move.Down == Move)
                {
                    FormAccess.AllieTanksDesign.Invoke(MoveDown);
                    Thread.Sleep(10);

                    if (Enumerable.Range(0, 10).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Down4;

                    else if (Enumerable.Range(11, 20).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Down3;

                    else if (Enumerable.Range(21, 30).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Down2;

                    else if (Enumerable.Range(31, 40).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.down1;
                }
                if(Game.Move.Up == Move)
                {
                    FormAccess.AllieTanksDesign.Invoke(MoveUp);
                    Thread.Sleep(10);

                    if (Enumerable.Range(0, 10).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Up4;

                    else if (Enumerable.Range(11, 20).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Up3;

                    else if (Enumerable.Range(21, 30).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Up2;

                    else if (Enumerable.Range(31, 40).Contains(Math.Abs(FormAccess.y - FormAccess.AllieTanksDesign.Top)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Up1;

                }
                if (Game.Move.Left == Move)
                {
                    FormAccess.AllieTanksDesign.Invoke(MoveLeft);
                    Thread.Sleep(10);

                    if (Enumerable.Range(0, 10).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Left4;

                    else if (Enumerable.Range(11, 20).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Left3;

                    else if (Enumerable.Range(21, 30).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Left2;

                    else if (Enumerable.Range(31, 40).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Left1;
                }
                if (Game.Move.Right == Move)
                {
                    FormAccess.AllieTanksDesign.Invoke(MoveRight);
                    Thread.Sleep(10);

                    if (Enumerable.Range(0, 10).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Right4;

                    else if (Enumerable.Range(11, 20).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Right3;

                    else if (Enumerable.Range(21, 30).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Right2;

                    else if (Enumerable.Range(31, 40).Contains(Math.Abs(FormAccess.x - FormAccess.AllieTanksDesign.Left)))
                        FormAccess.AllieTanksDesign.Image = Properties.Resources.Right1;
                } 
            });

           
            
                MovementTask.Start();
              if (MovementTask.IsCompleted)
                    MovementTask.Dispose();
            
              
        }
    }
}
