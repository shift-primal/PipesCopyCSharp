// namespace PipesCopy;
//
// internal class LoadingAnim
// {
//     private static void Main(string[] args)
//     {
//         Console.Clear();
//         Console.CursorVisible = false;
//
//         var running = true;
//
//         string[] frames =
//         {
//             "/",
//             "-",
//             @"\",
//             "|"
//         };
//
//         for (var i = 0; i < 10; i++)
//         for (var cf = 0; cf < frames.Length; cf++)
//         {
//             Console.SetCursorPosition(0, 0);
//             Console.Write(frames[cf]);
//             Thread.Sleep(100);
//         }
//
//         Console.SetCursorPosition(0, 2);
//         Console.WriteLine("Ferdig");
//         Console.CursorVisible = true;
//     }
// }