using System;
using System.Collections.Generic;
using System.Text;

namespace AgentesRobots
{
    public class ProactiveRobot
    {
        public AgentesRobots board { get; set; }
        public ProactiveRobot(int width, int height, int countChildren, int countBlocking, int countDirt)
        {
            board = new AgentesRobots(width, height, countChildren, countBlocking, countDirt);
            while (board.T < 30)
                Move();
        }
        private void Robot()
        {
            CountWay();
            int x = 0;
            int y = 0;
            agent temp1 = agent.empty;
            int aux = 5;

            for (int i = 0; i < board.things.GetLength(0); i++)
            {
                for (int j = 0; j < board.things.GetLength(1); j++)
                {
                    if (board.things[i, j] == agent.robot || board.things[i, j] == agent.corralRobot || board.things[i, j] == agent.robotChildren || 
                        board.things[i, j] == agent.corralRobotChildren || board.things[i, j] == agent.dirtRobot || 
                        board.things[i, j] == agent.dirtRobotChildren)
                    {
                        x = i;
                        y = j;
                        temp1 = board.things[i, j];
                    }
                }
            }
            if (temp1 == agent.robot || temp1 == agent.corralRobot || (x == board.destinyX && y == board.destinyY && temp1 != agent.robotChildren) || 
                temp1 == agent.dirtRobot)
            {
                if (board.childrenLess > 0 && (x != board.destinyX || y != board.destinyY))
                {
                    aux = NearAgent(agent.children, x, y);
                    if (aux != 4)
                    {
                        board.Combine(x - board.moveX[aux], y - board.moveY[aux], temp1);
                        board.Split(x, y);
                    }
                }
                else
                {
                    if (temp1 == agent.dirtRobot)
                    {
                        board.things[x, y] = agent.robot;
                        board.dirtLess--;
                    }
                    else
                    {
                        aux = NearAgent(agent.dirt, x, y);
                        if (aux != 4)
                        {
                            board.Combine(x - board.moveX[aux], y - board.moveY[aux], agent.robot);
                            board.Split(x, y);
                        }
                    }
                }
                if (x == board.destinyX && y == board.destinyY && aux != 5 && aux != 4)
                {
                    board.Combine(x - board.moveX[aux], y - board.moveY[aux], agent.robot);
                    board.Split(x, y);
                }
            }
            else
            {
                if (temp1 == agent.robotChildren || temp1 == agent.dirtRobotChildren || temp1 == agent.corralRobotChildren)
                {
                    int min = 0;
                    for (int i = 0; i < board.corral.GetLength(0); i++)
                        if (board.corral[i, 2] < board.corral[min, 2] || (board.things[board.corral[i, 0], board.corral[i, 1]] == agent.corralEmpty && 
                            board.things[board.corral[min, 0], board.corral[min, 1]] == agent.corralFull))
                            min = i;
                    board.destinyX = board.corral[min, 0];
                    board.destinyY = board.corral[min, 1];
                    aux = NearAgent(agent.corralEmpty, x, y);
                    if (aux != 4)
                    {
                        board.Combine(x - board.moveX[aux], y - board.moveY[aux], temp1);
                        board.Split(x, y);
                        if (x - board.moveX[aux] != board.destinyX || y - board.moveY[aux] != board.destinyY)
                        {
                            int aux2 = NearAgent(agent.corralEmpty, x - board.moveX[aux], y - board.moveY[aux]);
                            if (aux == aux2)
                            {
                                board.Combine(x - 2 * board.moveX[aux], y - 2 * board.moveY[aux], temp1);
                                board.Split(x - board.moveX[aux], y - board.moveY[aux]);
                            }
                        }
                    }
                }
            }
        }
        private void CountWay()
        {
            for (int i = 0; i < board.countChildren; i++)
            {
                board.corral[i, 2] = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (0 <= board.corral[i, 0] + board.moveX[j] && board.corral[i, 0] + board.moveX[j] < board.things.GetLength(0) && 
                        0 <= board.corral[i, 1] + board.moveY[j] && board.corral[i, 1] + board.moveY[j] < board.things.GetLength(1) && 
                        board.things[board.corral[i, 0] + board.moveX[j], board.corral[i, 1] + board.moveY[j]] != agent.blocking &&
                        board.things[board.corral[i, 0] + board.moveX[j], board.corral[i, 1] + board.moveY[j]] != agent.corralFull)
                        board.corral[i, 2]++;
                }
            }
        }
        private int NearAgent(agent agent, int posx, int posy)
        {
            int[,] aux = new int[board.things.GetLength(0), board.things.GetLength(1)];
            int x = int.MaxValue;
            int y = int.MaxValue;
            for (int i = 0; i < board.things.GetLength(0); i++)
            {
                for (int j = 0; j < board.things.GetLength(1); j++)
                {
                    aux[i, j] = int.MaxValue;
                }
            }
            aux[posx, posy] = 0;
            List<Tuple<int, int>> bfs = new List<Tuple<int, int>>();
            bfs.Add(new Tuple<int, int>(posx, posy));

            for (int j = 0; j < bfs.Count; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (0 <= bfs[j].Item1 + board.moveX[i] && bfs[j].Item1 + board.moveX[i] < board.things.GetLength(0) && 
                        0 <= bfs[j].Item2 + board.moveY[i] && bfs[j].Item2 + board.moveY[i] < board.things.GetLength(1) && 
                        board.things[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] != agent.blocking &&
                        board.things[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] != agent.corralFull && (agent != agent.corralEmpty ||
                        board.things[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] != agent.children) && 
                        IsIt(bfs, bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]))
                    {
                        bfs.Add(new Tuple<int, int>(bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]));
                        if (aux[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] > aux[bfs[j].Item1, bfs[j].Item2] + 1)
                            aux[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] = aux[bfs[j].Item1, bfs[j].Item2] + 1;

                        if (board.things[bfs[j].Item1 + board.moveX[i], bfs[j].Item2 + board.moveY[i]] == agent && agent != agent.corralEmpty && 
                            x == int.MaxValue && y == int.MaxValue)
                        {
                            x = bfs[j].Item1 + board.moveX[i];
                            y = bfs[j].Item2 + board.moveY[i];
                        }
                    }
                }
            }
            if (agent == agent.corralEmpty)
            {
                x = board.destinyX;
                y = board.destinyY;
            }
            int temp = 0;
            for (temp = 0; temp < 4 && (x + board.moveX[temp] != posx || y + board.moveY[temp] != posy); temp++)
            {
                if (0 <= x + board.moveX[temp] && x + board.moveX[temp] < board.things.GetLength(0) && 0 <= y + board.moveY[temp] && 
                    y + board.moveY[temp] < board.things.GetLength(1) && aux[x, y] > aux[x + board.moveX[temp], y + board.moveY[temp]])
                {
                    x = x + board.moveX[temp];
                    y = y + board.moveY[temp];
                    temp = -1;
                }
            }

            return temp;
        }
        private bool IsIt(List<Tuple<int, int>> bfs, int x, int y)
        {
            foreach (var item in bfs)
                if (item.Item1 == x && item.Item2 == y)
                    return false;
            return true;
        }
        private void GoCorral(bool[,] enviroment, int min, int count, ref int result, int move, int posx, int posy)
        {
            if (0 < posx && 0 < posy && posx < board.things.GetLength(0) && posy < board.things.GetLength(1) && posx == board.destinyX && posy == board.destinyY)
            {
                if (count < min)
                {
                    count = min;
                    result = move;
                    return;
                }
            }
            enviroment[posx, posy] = true;
            for (int i = 0; i < 4; i++)
            {
                if (0 < posx + board.moveX[i] && 0 < posy + board.moveY[i] && posx + board.moveX[i] < board.things.GetLength(0) &&
                    posy + board.moveY[i] < board.things.GetLength(1) && board.things[posx + board.moveX[i], posy + board.moveY[i]] != agent.blocking &&
                    board.things[posx + board.moveX[i], posy + board.moveY[i]] != agent.corralFull && enviroment[posx + board.moveX[i], posy + board.moveY[i]] == false && 
                    board.things[posx + board.moveX[i], posy + board.moveY[i]] != agent.children)
                {
                    enviroment[posx, posy] = true;
                    if (result == 5)
                        GoCorral(enviroment, min, count + 1, ref result, i, posx + board.moveX[i], posy + board.moveX[i]);
                    else
                        GoCorral(enviroment, min, count + 1, ref result, move, posx + board.moveX[i], posy + board.moveX[i]);
                    enviroment[posx, posy] = false;
                }
            }
        }
        public void Move()
        {
            if (board.t < 30 && (board.dirtLess != 0 || board.childrenLess != 0) && !board.calification)
            {
                Robot();
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
