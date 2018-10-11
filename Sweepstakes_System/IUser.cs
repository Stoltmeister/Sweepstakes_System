using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes_System
{
    interface IUser
    {
        string FirstName { get; }
        void Notify(IUser winner);
    }
}
