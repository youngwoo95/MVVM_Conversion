using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);



        static void Main(string[] args)
        {
            v  // Postman의 윈도우 제목을 사용해서 핸들 찾기
        IntPtr hwnd = FindWindow(null, "Postman");

            if (hwnd != IntPtr.Zero)
            {
                Console.WriteLine($"Postman 윈도우 핸들: {hwnd}");
            }
            else
            {
                Console.WriteLine("Postman 윈도우 핸들을 찾을 수 없습니다.");
            }
        }

        static IntPtr GetPostmanWindowHandle()
        {
            // Postman의 윈도우 제목에 맞는 핸들을 가져옵니다.
            return FindWindow(null, "Postman");
        }

    
    }
}
