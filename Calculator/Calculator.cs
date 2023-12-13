using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        public int Result = 0;
        private Stack<int> Results = new Stack<int>();

        public int Divide(int value)
        {
            Results.Push(Result);
            Result /= value;
            RaisEvent();
            return Result;
        }

        public int Multiply(int value)
        {
            Results.Push(Result);
            Result *= value;
            RaisEvent();
            return Result;
        }

        public int Subatruct(int value)
        {
            Results.Push(Result);
            Result -= value;
            RaisEvent();
            return Result;
        }

        public int Sum(int value)
        {
            Results.Push(Result);
            Result += value;
            RaisEvent();
            return Result;
        }

        private void RaisEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RaisEvent();
            }

        }
    }
}