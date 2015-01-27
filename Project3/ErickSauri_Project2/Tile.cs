using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Sauri_Project3
{
    public class Tile : Canvas
    {
      
        public static Dictionary<string, Color> TileColors = new Dictionary<string, Color>();

        public static int SIZE = 30;   //size of square
        public static int START = 10; //distance from left corner of window to first column
        public static int SPACING = 1;
        string value; //defines what the tile is
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value; //update our field
                // update display
                myColor = Tile.TileColors[value];
                background.Fill = new SolidColorBrush(myColor);
            }
        }

        //position in the grid and screen
        int column, row;
        public int Column { get { return column; } }
        public int Row { get { return row; } }

        Rectangle background;
     
        Color myColor;

        public Tile(int c, int r, string val)
        {
            this.value = val;
            this.row = r;
            this.column = c;

            //make a rectangele, set its w, h, col, corners
            background = new Rectangle();
            background.Width = SIZE;
            background.Height = SIZE;
            //background.RadiusX = background.RadiusY = 5;

            this.Children.Add(background);

            //call the setter which will take care of the color/text display
            this.Value = value;

            //Scale Transform Group
            TransformGroup tg = new TransformGroup();
            ScaleTransform myScale = new ScaleTransform(.1, .1, SIZE / 2, SIZE / 2);
            tg.Children.Add(myScale);
            this.RenderTransform = tg;

            //positioning will be done by changing the Margin property of this Canvas
            MoveTo(column, row);

            DoubleAnimation da = new DoubleAnimation(.01, 1, TimeSpan.FromSeconds(0.05));
            da.BeginTime = TimeSpan.FromSeconds(0.05);

            myScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            myScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);

        }

        public void MoveTo(int c, int r)
        {
            column = c;
            row = r;

            Thickness myMargin = new Thickness(
                Tile.START + c * (Tile.SIZE + Tile.SPACING),
                Tile.START + r * (Tile.SIZE + Tile.SPACING), 0, 0);
            this.Margin = myMargin;

        }

        public void SlideTo(int c, int r)
        {
            column = c;
            row = r;

            Thickness from = this.Margin;
            Thickness to = new Thickness(Tile.START + c * (Tile.SIZE + Tile.SPACING), Tile.START + r * (Tile.SIZE + Tile.SPACING), 0, 0);

            //create animtion
            ThicknessAnimation ta = new ThicknessAnimation(from, to, TimeSpan.FromSeconds(0.05));

            //start animation
            this.BeginAnimation(Canvas.MarginProperty, ta);
        }
      
       
    }
}
