using System;
using System.Runtime.InteropServices;

namespace 飞行棋
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. 控制台初始化
            int w = 40;
            int h = 30;
            ConsoleInit(w, h);
            #endregion

            #region 2. 场景选择相关
            //申明一个表示场景的枚举变量
            E_ScenceType nowScenceType = E_ScenceType.Start;
            while (true)
            {
               switch(nowScenceType)
               {
                    case E_ScenceType.Start:
                        //开始场景逻辑
                        Console.Clear();
                        StartScence(w,h,ref nowScenceType);
                        break;
                    case E_ScenceType.Game:
                        //游戏场景逻辑
                        Console.Clear();
                        break;
                    case E_ScenceType.Over:
                        //结束场景逻辑
                        Console.Clear();
                        break;
                }
            }
            #endregion
        }
        #region 1. 控制台初始化
        static void ConsoleInit(int w, int h)
        {
            //光标隐藏
            Console.CursorVisible = false;
            //设置窗口大小
            Console.SetWindowSize(w, h);
            //设置缓冲区大小
            Console.SetBufferSize(w, h);
        }
        #endregion

        #region 3. 开始场景逻辑

        static void StartScence(int w,int h,ref E_ScenceType nowScenceType)
        {
            Console.SetCursorPosition(w/2-3,8);
            Console.Write("飞行棋");

            //当前选项的编号
            int nowSelIndex = 0;
            bool isQuitStart = false;
            //开始场景逻辑
            while (true)
            {
                Console.SetCursorPosition(w/2-4,13);
                Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("开始游戏");
                Console.SetCursorPosition(w/2-4,15);
                Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("退出游戏");

                //通过ReadKey可以得到一个输入的枚举类型
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        --nowSelIndex;
                        if(nowSelIndex < 0)
                            nowSelIndex = 0;
                        break;
                    case ConsoleKey.S:
                        ++nowSelIndex;
                        if(nowSelIndex > 1)
                            nowSelIndex = 1;
                        break;
                    case ConsoleKey.J:
                        if(nowSelIndex == 0)
                        {
                            //进入游戏场景
                            nowScenceType = E_ScenceType.Game;
                            isQuitStart = true;
                        }
                        else
                        {
                            //退出游戏
                            Environment.Exit(0);
                        }
                        break;
                }
                //通过标识决定是否退出开始场景
                if (isQuitStart)
                    break;  
            }
            
        }
        #endregion
    }
    #region 2. 场景选择相关
    enum E_ScenceType
    {
        Start,
        Game,
        Over
    }
    #endregion
}