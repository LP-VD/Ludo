using System;
using System.Runtime.InteropServices;

namespace 飞行棋
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 控制台初始化
            int w = 50;
            int h = 30;
            ConsoleInit(w, h);
            #endregion 
        }
        static void ConsoleInit(int w, int h)
        {
            //窗口的大小
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            //光标的隐藏
            Console.CursorVisible = false;
        }
    }

}