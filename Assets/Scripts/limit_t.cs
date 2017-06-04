using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class limit_t
    {
        public int down;
        public int top;

        public limit_t(int limitDown, int limitTop)
        {
            this.down = limitDown;
            this.top = limitTop;
        }

        public static limit_t operator +(limit_t first, limit_t second)
        {
            return new limit_t(first.down + second.down, first.top + second.top);
        }

        public static limit_t operator -(limit_t first, limit_t second)
        {
            return new limit_t(first.down - second.down, first.top - second.top);
        }


    }
}
