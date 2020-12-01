using System;
using System.Collections.Generic;
using System.Drawing;

namespace AgentesRobots
{
    public class AgentesRobots
    {
        public int[] moveX { get; private set; } = { 1, -1, 0, 0 };
        public int[] moveY { get; private set; } = { 0, 0, 1, -1 };
        public int[,] corral { get; internal set; }
        public int destinyX { get; internal set; }
        public int destinyY { get; internal set; }
        public int childrenLess { get; internal set; }
        public int dirtLess { get; internal set; }
        public int T { get; internal set; }
        public int t { get; internal set; }
        public agent[,] things { get; private set; }
        public int countChildren { get; private set; }
        public int countDirt { get; private set; }
        public int countBlocking { get; private set; }
        public string report { get; internal set; }
        public bool calification { get; internal set; }
        public Random rand { get; private set; }

        public AgentesRobots(int width, int height, int countChildren, int countBlocking, int countDirt)
        {
            report = "";
            calification = false;
            t = 0;
            T = 0;
            rand = new Random();
            things = new agent[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    things[i, j] = agent.empty;
                }
            }
            this.countChildren = countChildren;
            this.countBlocking = countBlocking;
            this.countDirt = countDirt;
            childrenLess = countChildren;
            dirtLess = countDirt;
            CorralGenerator();
            BoardGenerator(countBlocking, agent.blocking);
            BoardGenerator(countDirt, agent.dirt);
            BoardGenerator(countChildren, agent.children);
            BoardGenerator(1, agent.robot);
        }
        private void CorralGenerator()
        {
            corral = new int[countChildren,3];
            List<Tuple<int, int>> aux = new List<Tuple<int, int>>();
            int aux2 = 0;
            int aux3 = 0;
            if (countChildren == 0)
                return;
            aux2 = rand.Next(things.GetLength(0));
            aux3 = rand.Next(things.GetLength(1));
            Tuple<int, int> aux4;
            things[aux2, aux3] = agent.corralEmpty;
            corral[0, 0] = aux2;
            corral[0, 1] = aux3;
            aux.Add(new Tuple<int, int>(aux2, aux3));
            while (aux.Count<countChildren)
            {
                aux2 = rand.Next(aux.Count);
                aux3 = rand.Next(0, 2);
                aux4 = new Tuple<int, int>(aux3 * (rand.Next(3) - 1) + aux[aux2].Item1, Math.Abs(aux3 - 1) * (rand.Next(3) - 1) + aux[aux2].Item2);
                if(0 <= aux4.Item1 && aux4.Item1 < things.GetLength(0) && 0 <= aux4.Item2 && aux4.Item2 < things.GetLength(1))
                {
                    if (things[aux4.Item1, aux4.Item2] != agent.corralEmpty)
                    {
                        things[aux4.Item1, aux4.Item2] = agent.corralEmpty;
                        corral[aux.Count, 0] = aux4.Item1;
                        corral[aux.Count, 1] = aux4.Item2;
                        aux.Add(new Tuple<int, int>(aux4.Item1, aux4.Item2));
                    }
                }
            }
        }
        private void BoardGenerator(int value,agent agent)
        {
            int aux = 0;
            int aux2 = 0;
            int aux3 = 0;
            while (value != aux)
            {
                aux2 = rand.Next(things.GetLength(0));
                aux3 = rand.Next(things.GetLength(1));
                if (things[aux2, aux3] == agent.empty)
                {
                    things[aux2, aux3] = agent;
                    aux++;
                }
            }
        }
        public void Combine(int i, int j, agent agent)
        {
            if (things[i, j] == agent.empty)
            {
                if (agent == agent.dirtRobot || agent == agent.corralRobot)
                    agent = agent.robot;
                if (agent == agent.dirtRobotChildren)
                    agent = agent.robotChildren;
                things[i, j] = agent;
            }
            if (things[i, j] == agent.dirt && (agent == agent.robot || agent == agent.dirtRobot || agent == agent.corralRobot))
                things[i, j] = agent.dirtRobot;
            if (things[i, j] == agent.children && (agent == agent.robot || agent == agent.dirtRobot || agent == agent.corralRobot))
            {
                things[i, j] = agent.robotChildren;
                childrenLess--;
            }
            if (things[i,j] == agent.dirt && (agent == agent.robotChildren || agent == agent.dirtRobotChildren || agent == agent.corralRobotChildren))
                things[i, j] = agent.dirtRobotChildren;
            if (things[i, j] == agent.corralEmpty && (agent == agent.robot || agent == agent.corralRobot || agent == agent.dirtRobot))
                things[i, j] = agent.corralRobot;
            if(things[i, j] == agent.corralEmpty && (agent == agent.robotChildren || agent == agent.dirtRobotChildren || agent == agent.corralRobotChildren))
                things[i, j] = agent.corralRobotChildren;
            if (things[i, j] == agent.corralEmpty && agent == agent.children)
            {
                if(i == destinyX && j == destinyY)
                things[i, j] = agent.corralFull;
            }
        }
        private void DirtyChild(int x, int y)
        {
            int countbb = 0;
            int dirt = 0;
            int aux1 = 0;
            int aux2 = 0;
            for (int i = x-1; i <= x+1; i++)
            {
                for (int j = y-1; j <= y+1; j++)
                {
                    if (0 <= x - 1 && x + 1 < things.GetLength(0) && 0 <= y - 1 && y + 1 < things.GetLength(1) && things[i, j] == agent.children)
                        countbb++;
                }
            }
            switch (countbb)
            {
                case 1:
                    dirt = rand.Next(0, 2);
                    break;
                case 2:
                    dirt = rand.Next(0, 4);
                    break;
                default:
                    dirt = rand.Next(0, 7);
                    break;
            }
            for (int i = 0; i < dirt; i++)
            {
                aux1 = rand.Next(x - 1, x + 2);
                aux2 = rand.Next(y - 1, y + 2);
                if (0 <= x - 1 && x + 1 < things.GetLength(0) && 0 <= y - 1 && y + 1 < things.GetLength(1) && things[aux1, aux2] == agent.empty)
                {
                    things[aux1, aux2] = agent.dirt;
                    dirtLess++;
                }
            }
        }
        public void ChildMove(int x,int y)
        {
            List<Tuple<int,int>> temp = new List<Tuple<int,int>>();
            temp.Add(new Tuple<int, int>(x - 1, y));
            temp.Add(new Tuple<int, int>(x + 1, y));
            temp.Add(new Tuple<int, int>(x, y - 1));
            temp.Add(new Tuple<int, int>(x, y + 1));
            int aux;
            for (int i = 0; i < temp.Count; i++)
            {
                aux = rand.Next(0, temp.Count);
                if (CanMove(x, y, temp[aux].Item1, temp[aux].Item2, agent.children))
                {
                    DirtyChild(x, y);
                    break;
                }
                temp.Remove(temp[aux]);
                i--;
            }
        }
        private bool CanMove(int x1, int y1, int x2, int y2, agent agent)
        {
            if (x2 < 0 || things.GetLength(0) <= x2 || y2 < 0 || things.GetLength(1) <= y2)
                return false;
            if (things[x2, y2] == agent.empty)
            {
                things[x2, y2] = agent;
                things[x1, y1] = agent.empty;
                return true;
            }
            if (things[x2, y2] == agent.blocking && CanMove(x2, y2, x2 + x2 - x1, y2 + y2 - y1, agent.blocking))
            {
                things[x2, y2] = agent;
                things[x1, y1] = agent.empty;
                return true;
            }
            return false;
        }       
        public void Split(int x, int y)
        {
            switch (things[x,y])
            {
                case agent.robot:
                    {
                        things[x, y] = agent.empty;
                        break;
                    }
                case agent.robotChildren:
                    {
                        things[x, y] = agent.empty;
                        break;
                    }
                case agent.corralRobot:
                    {
                        things[x, y] = agent.corralEmpty;
                        break;
                    }
                case agent.dirtRobot:
                    {
                        things[x, y] = agent.dirt;
                        break;
                    }
                case agent.dirtRobotChildren:
                    {
                        things[x, y] = agent.dirt;
                        break;
                    }
                case agent.corralRobotChildren:
                    {
                        if (x == destinyX && y == destinyY)
                            things[x, y] = agent.corralFull;
                        else
                            things[x, y] = agent.corralEmpty;
                        break;
                    }
                default:
                    break;
            }
        }
        public void Restart()
        {
            calification = false;
            t = 0;
            rand = new Random();
            for (int i = 0; i < things.GetLength(0); i++)
            {
                for (int j = 0; j < things.GetLength(1); j++)
                {
                    things[i, j] = agent.empty;
                }
            }
            childrenLess = countChildren;
            dirtLess = countDirt;
            CorralGenerator();
            BoardGenerator(countBlocking, agent.blocking);
            BoardGenerator(countDirt, agent.dirt);
            BoardGenerator(countChildren, agent.children);
            BoardGenerator(1, agent.robot);
        }
        public void Calification()
        {
            if (dirtLess == 0 && childrenLess == 0)
            {
                report += "El robot gano";
            }
            else
            {
                if (calification)
                    report += "El robot fue despedido";
            }
            report += (char)10;
            T++;
        }
        
    }
}
public enum agent
{
    dirt,
    children,
    robot,
    corralEmpty,
    corralRobot,
    corralFull,
    blocking,
    empty,
    dirtRobot,
    dirtRobotChildren,
    corralRobotChildren,
    robotChildren
};