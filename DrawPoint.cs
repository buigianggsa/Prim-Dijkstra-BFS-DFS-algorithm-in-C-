using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LTDT
{
 public class DrawPoint
    {
       

      private  DrawPoint() { }

        private static DrawPoint drawP;

        public static DrawPoint DrawP
        {
            get
            {
                if (drawP == null)
                {
                    drawP = new DrawPoint();
                }
                return DrawPoint.drawP;
            }

          private  set
            {
                DrawPoint.drawP = value;
            }
        }

        public void Draw1Point(PictureBox pic,string name,Size size,Point point, ref Point pointGet)
        {
            Font font = new Font("Arial", 11);
            Graphics g = pic.CreateGraphics();
            Pen pen = new Pen(Color.Red);        
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush dotBrush = new SolidBrush(Color.Yellow);
            pointGet = new Point(point.X + 22, point.Y + 21);
            Rectangle rect = new Rectangle(point.X + 14, point.Y + 14, 30, 30);
            float startAngle = 0.0F;
            float sweepAngle = 360.0F;
            g.FillPie(redBrush, rect, startAngle, sweepAngle);
            g.DrawString(name, font, dotBrush, pointGet);
           
         
           
     


        }
        public void DrawLine(PictureBox pic,Point p1,Point p2)
        {
            
            Graphics g = pic.CreateGraphics();
            Pen pen = new Pen(Color.Yellow,2);
            Point a = new Point(p1.X+7, p1.Y);
            Point b = new Point(p2.X+7, p2.Y);
            g.DrawLine(pen, a, b);
            
        }
        public void DrawVector(PictureBox pic, Point p1, Point p2, int dinh)
        {
           
            Graphics g = pic.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            Point a = new Point(p1.X + 7, p1.Y);
            Point b = new Point(p2.X + 7, p2.Y);
            g.DrawLine(pen, a, b);
            Brush bb = new SolidBrush(Color.Black);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x1 = a.X;
            int y1 = a.Y;
            int x2 = b.X;
            int y2 = b.Y;
            float xtemp = 0;
            float ytemp = 0;
            g.DrawLine(pen, x1, y1, x2, y2);

            double angle = Math.Atan2(y1 - y2, x1 - x2);


            switch (dinh)
            {
                case 2:
                    {

                        if (x1 == x2 && y1 < y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 1.71f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });

                        }
                        //--- mũi tên lên -- arrow cross up
                        if (x1 == x2 && y1 > y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 0.37f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross right
                        if (y1 == y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 1.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross left
                        if (y1 == y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 0.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                    }
                    break;


                case 3:
                    {

                        if (x1 == x2 && y1 < y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 1.71f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });

                        }
                        //--- mũi tên lên -- arrow cross up
                        if (x1 == x2 && y1 > y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 0.37f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross right
                        if (y1 == y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 1.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross left
                        if (y1 == y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 0.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên xuống trái -- arrow  left down
                        if (y1 < y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f * 1.55f;
                            xtemp = (x1 + x2) / 2f * 0.65f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }
                        //--- mũi tên xuống trái -- arrow  right down
                        if (y1 < y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f * 1.53f;
                            xtemp = (x1 + x2) / 2f * 1.19f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //---- mũi tên lên phải -- arrow up right
                        if (y1 > y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f * .51f;
                            xtemp = (x1 + x2) / 2f * 1.32f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //---- mũi tên lên phải -- arrow up left
                        if (y1 > y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f * .51f;
                            xtemp = (x1 + x2) / 2f * 0.83f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }


                    }
                    break;
                case 4:
                    {
                        if (x1 == x2 && y1 < y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 1.71f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });

                        }
                        //--- mũi tên lên -- arrow cross up
                        if (x1 == x2 && y1 > y2)
                        {
                            xtemp = (x1 + x2) / 2f;
                            ytemp = (y1 + y2) / 2f * 0.37f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross right
                        if (y1 == y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 1.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên lên -- arrow cross left
                        if (y1 == y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f;
                            xtemp = (x1 + x2) / 2f * 0.5f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //--- mũi tên xuống trái -- arrow  left down
                        if (y1 < y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f * 1.55f;
                            xtemp = (x1 + x2) / 2f * 0.65f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }
                        //--- mũi tên xuống trái -- arrow  right down
                        if (y1 < y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f * 1.53f;
                            xtemp = (x1 + x2) / 2f * 1.19f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //---- mũi tên lên phải -- arrow up right
                        if (y1 > y2 && x1 < x2)
                        {
                            ytemp = (y1 + y2) / 2f * .51f;
                            xtemp = (x1 + x2) / 2f * 1.32f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        }

                        //---- mũi tên lên phải -- arrow up left
                        if (y1 > y2 && x1 > x2)
                        {
                            ytemp = (y1 + y2) / 2f * .51f;
                            xtemp = (x1 + x2) / 2f * 0.83f;
                            PointF p11 = new PointF(xtemp + (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp + (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            PointF p22 = new PointF(xtemp - (float)(Math.Cos(angle) * 10), ytemp - (float)(Math.Sin(angle) * 10));
                            PointF p33 = new PointF(xtemp - (float)(Math.Cos(angle - Math.PI / 2.0) * 10), ytemp - (float)(Math.Sin(angle - Math.PI / 2.0) * 10));
                            g.FillPolygon(bb, new PointF[] { p11, p22, p33 });
                        } 


                    }
                    break;
                case 5:
                    {



                    }
                    break;
                case 6:
                    {



                    }
                    break;
                case 7:
                    {



                    }
                    break;
                case 8:
                    {



                    }
                    break;
                case 9:
                    {



                    }
                    break;





            }
           
            pen.Dispose();
            bb.Dispose();






        }

        void OKvecto() { }

    }
}
