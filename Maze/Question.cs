using System;

namespace Maze
{
    public class Question
    {
        public int number;
        private bool _Locked;

        public Question() { }

        public Question(int num) {
            number = num;
            _Locked = true;

        }

        internal bool Locked()
        {
            return _Locked;
        }

        internal void Unlock()
        {
            _Locked = true;
        }
    }
}