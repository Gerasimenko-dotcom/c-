namespace LAB2_ELENA_V4
{
    public struct Grid2D 
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
            return $"Grid2D information: dx = {Dx}, dy = {Dy}, X = {CountX}, Y= {CountY}";
        }

        public string ToString(string format)
        {
            return $"Grid2D information: dx = {Dx.ToString(format)}, dy = {Dy.ToString(format)}, X = {CountX}, Y= {CountY}";
        }
    }
}
