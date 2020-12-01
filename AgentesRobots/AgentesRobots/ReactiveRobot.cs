using System;
using System.Collections.Generic;
using System.Text;

namespace AgentesRobots
{
    public class ReactiveRobot
    {
        public AgentesRobots board { get; private set; }
        public ReactiveRobot(int width, int height, int countChildren, int countBlocking, int countDirt)
        {
            board = new AgentesRobots(width, height, countChildren, countBlocking, countDirt);
            while (board.T < 30)
                Move();
        }
        private void DumyRobot()
        {
            int x = 0;
            int y = 0;
            agent temp1 = agent.empty;

            for (int i = 0; i < board.things.GetLength(0); i++)
            {
                for (int j = 0; j < board.things.GetLength(1); j++)
                {
                    if (board.things[i, j] == agent.robot || board.things[i, j] == agent.corralRobot || board.things[i, j] == agent.robotChildren ||
                        board.things[i, j] == agent.corralRobotChildren || board.things[i, j] == agent.dirtRobot || board.things[i, j] == agent.dirtRobotChildren)
                    {
                        x = i;
                        y = j;
                        temp1 = board.things[i, j];
                    }
                }
            }
            int r = 0;
            if (temp1 == agent.robot || temp1 == agent.robotChildren || temp1 == agent.dirtRobotChildren || temp1 == agent.corralRobot)
            {
                while (true)
                {
                    r = board.rand.Next(0, 4);
                    if (0 <= x + board.moveX[r] && x + board.moveX[r] < board.things.GetLength(0) && 0 <= y + board.moveY[r] && y + board.moveY[r] < board.things.GetLength(1) &&
                        board.things[x + board.moveX[r], y + board.moveY[r]] != agent.blocking && board.things[x + board.moveX[r], y + board.moveY[r]] != agent.corralFull &&
                        ((temp1 != agent.dirtRobotChildren && temp1 != agent.robotChildren) || board.things[x + board.moveX[r], y + board.moveY[r]] != agent.children))
                    {
                        board.Combine(x + board.moveX[r], y + board.moveY[r], temp1);
                        board.Split(x, y);
                        break;
                    }
                }
            }
            if (temp1 == agent.corralRobotChildren)
            {
                
                while (true)
                {
                    r = board.rand.Next(0, 4);
                    if (0 <= x + board.moveX[r] && x + board.moveX[r] < board.things.GetLength(0) && 0 <= y + board.moveY[r] && y + board.moveY[r] < board.things.GetLength(1) &&
                        board.things[x + board.moveX[r], y + board.moveY[r]] != agent.blocking && board.things[x + board.moveX[r], y + board.moveY[r]] != agent.corralFull)
                    {
                        board.Combine(x + board.moveX[r], y + board.moveY[r], temp1);
                        board.Split(x, y);
                        board.childrenLess--;
                        break;
                    }
                }
                board.Combine(x, y, agent.children);
            }
            if (temp1 == agent.dirtRobot)
            {
                board.things[x, y] = agent.robot;
                board.dirtLess--;
            }
        }
        public void Move()
        {
            if (board.t < 30 && (board.dirtLess != 0 || board.childrenLess != 0) && !board.calification)
            {
                DumyRobot();
                List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
                for (int i = 0; i < board.things.GetLength(0); i++)
                {
                    for (int j = 0; j < board.things.GetLength(1); j++)
                    {
                        if (board.things[i, j] == agent.children)
                            temp.Add(new Tuple<int, int>(i, j));
                    }
                }
                foreach (var item in temp)
                {
                    board.ChildMove(item.Item1, item.Item2);
                }
                float aux = (float)board.dirtLess / ((board.things.GetLength(0)) * (board.things.GetLength(1)) - (board.countChildren + board.countBlocking + board.childrenLess + 1));
                if (aux > 0.6)
                    board.calification = true;
                board.t++;
            }
            else
            {
                if (board.t < 30)
                    board.Calification();
                board.Restart();
            }
        }
    }
}
