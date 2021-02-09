using System;

namespace LAB1_ELENA_V4
{
    struct Grid2D // Done
    {
        public Grid2D(float Dx, int CountX, float Dy, int CountY)
        {
            this.Dx = Dx;
            this.Dy = Dy;
            this.CountX = CountX;
            this.CountY = CountY;
        }

        public float Dx { set; get; }
        public int CountX { set; get; }
        public float Dy { set; get; }
        public int CountY { set; get; }

        public override string ToString()
        {
            return String.Format("Grid2D information: dx = {0}, dy = {1}, X = {2}, Y= {3}\n", Dx, Dy, CountX, CountY);
        }

    }
}
