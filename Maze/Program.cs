using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);


            Console.CursorVisible = false;


            const int WAIT_TICK = 1000 / 30;
            
            int lastTick = 0;
            while(true)
            {
                #region 프레임관리
                int currentTick = System.Environment.TickCount;
                //만약 겨
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion


                //Input

                //Logic
                player.Update(deltaTick);

                //Rendering
                Console.SetCursorPosition(0, 0);
                board.Render();
                
            }

        }
    }
}
