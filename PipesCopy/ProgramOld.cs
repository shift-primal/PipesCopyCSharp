// namespace PipesCopy;
//
// internal static class ProgramOld
// {
//     private static class DebugDisplay
//     {
//         private static bool Enabled { get; set; } = true;
//
//         private const int StartLine = 0;
//
//         public static void ShowInfo(CurrentPosition pos, Direction dir)
//         {
//             if (!Enabled) return;
//
//             var savedPos = Console.GetCursorPosition();
//
//             Console.SetCursorPosition(0, StartLine);
//
//             Console.WriteLine($"Width: {Console.WindowWidth} Height: {Console.WindowHeight}   ");
//             Console.WriteLine($"Pos: {pos.X}, {pos.Y}   ");
//             Console.WriteLine($"Direction: {dir}   ");
//
//             Console.SetCursorPosition(savedPos.Left, savedPos.Top);
//         }
//     }
//
//     private static readonly Random Random = new();
//
//     private enum Direction
//     {
//         Up = 0,
//         Down = 1,
//         Left = 2,
//         Right = 3
//     }
//
//     private static readonly Dictionary<Direction, Direction> Opposites = new()
//     {
//         { Direction.Up, Direction.Down },
//         { Direction.Down, Direction.Up },
//         { Direction.Left, Direction.Right },
//         { Direction.Right, Direction.Left }
//     };
//
//     // private static readonly Dictionary<Direction, string> DirectionSymbols = new()
//     // {
//     //     { Direction.Up, "▲" },
//     //     { Direction.Down, "▼" },
//     //     { Direction.Left, "◀" },
//     //     { Direction.Right, "▶" }
//     // };
//
//     private struct CurrentPosition(int x, int y)
//     {
//         public int X { get; set; } = x;
//         public int Y { get; set; } = y;
//     }
//
//     private static bool ShouldGetNewDirection(int count)
//     {
//         var roll = Random.Next(count, 11);
//         return roll == 10;
//     }
//
//     private static Direction GetRandomDirection(Direction currDir)
//     {
//         Direction newDirection;
//
//         do
//         {
//             newDirection = (Direction)Random.Next(0, 4);
//         } while (IsOpposite(newDirection, currDir));
//
//
//         return newDirection;
//     }
//
//     private static bool IsOpposite(Direction dir1, Direction dir2)
//     {
//         return Opposites[dir1] == dir2;
//     }
//
//     private static void WrapCursorPosition(ref CurrentPosition pos)
//     {
//         if (pos.X < 0) pos.X = Console.WindowWidth - 1;
//         if (pos.X >= Console.WindowWidth) pos.X = 0;
//
//         if (pos.Y < 0) pos.Y = Console.WindowHeight - 1;
//         if (pos.Y >= Console.WindowHeight) pos.Y = 0;
//     }
//
//     // private static int[] GetOffset(Direction dir)
//     // {
//     //     switch (dir)
//     //     {
//     //         case Direction.Up:
//     //         {
//     //             return [0, 1];
//     //         }
//     //
//     //         case Direction.Down:
//     //         {
//     //             return [0, -1];
//     //         }
//     //
//     //         case Direction.Left:
//     //         {
//     //             return [1, 0];
//     //         }
//     //
//     //         case Direction.Right:
//     //         {
//     //             return [-1, 0];
//     //         }
//     //     }
//     //
//     //
//     //     return [0, 0];
//     // }
//
//     private static void Main()
//     {
//         var running = true;
//
//         var currPos = new CurrentPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
//         var countSinceDirChange = 0;
//         var direction = GetRandomDirection((Direction)Random.Next(0, 4));
//
//         // Fpms (Frames per millisecond) | Lower = faster
//         var speed = 50;
//
//         Console.Clear();
//         Console.CursorVisible = false;
//
//         while (running)
//         {
//             if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) running = false;
//
//             DebugDisplay.ShowInfo(
//                 currPos,
//                 direction
//             );
//
//             if (ShouldGetNewDirection(countSinceDirChange))
//             {
//                 direction = GetRandomDirection(direction);
//                 countSinceDirChange = 0;
//             }
//
//             switch (direction)
//             {
//                 case Direction.Up:
//                     currPos.Y -= 1;
//                     break;
//                 case Direction.Down:
//                     currPos.Y += 1;
//                     break;
//                 case Direction.Left:
//                     currPos.X -= 1;
//                     break;
//                 case Direction.Right:
//                     currPos.X += 1;
//                     break;
//                 default:
//                     Console.WriteLine("Error!");
//                     break;
//             }
//
//             WrapCursorPosition(ref currPos);
//
//             // var cursorOffset = GetOffset(direction);
//
//             // Console.SetCursorPosition(currPos.X + cursorOffset[0], currPos.Y + cursorOffset[1]);
//             // Console.Write(DirectionSymbols[direction]);
//
//
//             Console.SetCursorPosition(currPos.X, currPos.Y);
//             Console.Write("█");
//
//             countSinceDirChange += 1;
//             Thread.Sleep(speed);
//         }
//
//         Console.SetCursorPosition(0, 4);
//         Console.WriteLine("Ferdig");
//         Console.CursorVisible = true;
//     }
// }