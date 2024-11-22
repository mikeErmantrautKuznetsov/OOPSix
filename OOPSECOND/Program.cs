using System.Numerics;
namespace OOPSecond
{
    // Работа со свойствами
    //Создать класс игрока, у которого есть поля с его положением в x, y.
    //Создать класс отрисовщик, с методом, который отрисует игрока.
    //Попрактиковаться в работе со свойствами.
    public class Player
    {
        public int XPosition { get; }
        public int YPosition { get; }
        public Player(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
    public class Drawer
    {
        public void StartRendering(Player player)
        {
            int[,] mapArray = new int[10, 10];

            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    Console.Write(mapArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(player.XPosition, player.YPosition);
            Console.WriteLine("$");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Drawer drawer = new Drawer();
            drawer.StartRendering(new Player(4, 6));
        }

    }
}