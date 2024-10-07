using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerNamespace
{
    //[Flags]
    //enum Roles
    //{
    //    None = 0,
    //    User = 1,
    //    Customer = 2,
    //    Moderator = 4,
    //    Admin = 8,
    //    Employee = 16,
    //    Manager = 32,
    //    Support = Admin | Employee | Manager, // Combination of Admin, Employee, and Manager
    //    Client = User | Customer | Moderator
    //}
    internal class ActionTimer
    {
        public static long CheckTime(Action _action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _action();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;            
        }
    }
}
