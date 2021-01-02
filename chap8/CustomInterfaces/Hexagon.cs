using System;

namespace CustomInterfaces
{
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }

        public byte Points => 6;

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        public void Draw3D() => Console.WriteLine("Drawing Hexagon in 3D!");
    }
}