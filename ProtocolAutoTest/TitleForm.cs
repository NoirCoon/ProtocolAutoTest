﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtocolAutoTest
{
    public partial class TitleForm : Form
    {
        class Star
        {
            public float X { get; set; }

            public float Y { get; set; }

            public float Z { get; set; }
        }

        private Star[] stars = new Star[15000]; //Массив звезд

        private Random random = new Random();

        private Graphics graphics;

        public TitleForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) //Каждый миллисек вызывается
        {
            graphics.Clear(Color.Black);

            foreach(var star in stars)
            {
                DrawStar(star);
                MoveStar(star);
            }

            pictureBox1.Refresh();

            if (TitleForm.ActiveForm.Opacity <= 0) 
            {
                TitleForm.ActiveForm.Close();
            } 
            else
            {
                TitleForm.ActiveForm.Opacity-=0.01;
            }

            
        }

        private void MoveStar(Star star)
        {
            star.Z -= 20; //скорость

            /*if (star.Z < 1)
            {
                star.X = random.Next(-pictureBox1.Width, pictureBox1.Width);
                star.Y = random.Next(-pictureBox1.Height, pictureBox1.Height);
                star.Z = random.Next(1, pictureBox1.Width);
            }*/
        }

        private void DrawStar(Star star)
        {
            float starSize = Map(star.Z, 0, pictureBox1.Width, 5, 0); //кароч 5 это размер

            float x = Map(star.X / star.Z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;

            float y = Map(star.Y / star.Z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;

            graphics.FillEllipse(Brushes.White, x, y, starSize, starSize);
        }

        private float Map(float n,float start1, float stop1, float start2,float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
        private void TitleForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); //Новый битмап соответствующий ширине и высоте пикчер бокса

            graphics = Graphics.FromImage(pictureBox1.Image);

            for(int i =0; i<stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    Z = random.Next(1, pictureBox1.Width)

                };
            }

            timer1.Start();
        }
    }
}
