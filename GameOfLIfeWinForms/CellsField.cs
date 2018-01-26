using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLIfeWinForms
{
    class CellsField 
    {
        bool[,] _field;
        public bool[,] Field
        { get { return _field; } }

        int _x;
        int _y;

        int _fieldSize = 50;

        public CellsField()
        {
            Random rnd = new Random();

            _field = new bool[50, 50];

            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    _field[i, j] = (rnd.NextDouble() > 0.5) ? true : false;
                }
            }

            _x = 0;
            _y = 0;
        }

        public CellsField(bool[,] cf)
        {
            _field = cf;
        }     

        public bool[,] GetStep()
        {
            bool[,] bufArray = new bool[50, 50];
            for (int i = 0; i < _fieldSize; i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {
                    int count = GetNeighborsCount(i, j);

                    if (_field[i, j])
                    {
                        bufArray[i, j] = true;

                        if (count == 2 || count == 3)
                        {
                            bufArray[i, j] = true;                            
                        }
                        else
                        {
                            bufArray[i, j] = false;
                            
                        }
                    }
                    else
                    {
                        if (count == 3)
                        {
                            bufArray[i, j] = true;
                            
                        }
                    }
                }
            }

            this._field = bufArray;
            return this._field;

        }

        private int GetNeighborsCount(int x, int y)
        {
            int count = 0;


            if (x > 0 && y > 0 && _field[x - 1, y - 1]) count++;
            if (x > 0 && _field[x - 1, y]) count++;
            if (x > 0 && y < _fieldSize - 1 && _field[x - 1, y + 1]) count++;
            if (x < _fieldSize - 1 && y > 0 && _field[x + 1, y - 1]) count++;
            if (x < _fieldSize - 1 && _field[x + 1, y]) count++;
            if (x < _fieldSize - 1 && y < _fieldSize - 1 && _field[x + 1, y + 1]) count++;
            if (y > 0 && _field[x, y - 1]) count++;
            if (y < _fieldSize - 1 && _field[x, y + 1]) count++;

            if (x == 0 && y == 0)
            {
                if (_field[_fieldSize - 1, _fieldSize - 1]) count++;
                if (_field[0, _fieldSize - 1]) count++;
                if (_field[_fieldSize - 1, 0]) count++;
            }

            if (x == 0 && y == _fieldSize - 1)
            {
                if (_field[_fieldSize - 1, 0]) count++;
                if (_field[_fieldSize - 1, _fieldSize - 1]) count++;
                if (_field[0, 0]) count++;

            }

            if (x == _fieldSize && y == _fieldSize)
            {
                if (_field[0, 0]) count++;
                if (_field[0, _fieldSize - 1]) count++;
                if (_field[_fieldSize - 1, 0]) count++;
            }

            if (x == _fieldSize && y == 0)
            {
                if (_field[0, 0]) count++;
                if (_field[0, _fieldSize - 1]) count++;
                if (_field[_fieldSize - 1, _fieldSize - 1]) count++;
            }





            return count;
        }


    }
}
