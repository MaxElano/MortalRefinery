using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntroductieProject
{
    partial class BaseLevel : GameObject
    {
        Tile[,] mapGrid;
        public void LoadLevelFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);

            int gridWidth = 0;
            
            List<string> gridRows = new List<string>();
            string row = streamReader.ReadLine();

            while (row != null) 
            { 
                if (row.Length > gridWidth)
                {
                    gridWidth = row.Length;
                }

                gridRows.Add(row);
                row = streamReader.ReadLine();
            }

            streamReader.Close();

            TurnToGrid(gridRows, gridWidth, gridRows.Count);
        }

        public void TurnToGrid(List<string> gridRows, int gridWidth, int gridHeight)
        {    
            List<GameObject> gameWorld = new List<GameObject>();

            mapGrid = new Tile[gridWidth, gridHeight];
        }
    }
}
