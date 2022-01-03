using Stride.Engine;

namespace AreaPrototype
{
    class AreaPrototypeApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
