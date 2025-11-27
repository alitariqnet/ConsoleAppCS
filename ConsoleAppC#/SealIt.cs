using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal sealed class SealIt
    {
        class X
        {
            protected virtual void F() { Console.WriteLine("X.F"); }
            protected virtual void F2() { Console.WriteLine("X.F2"); }

            public virtual void RunFunX()
            {
                this.F();
                this.F2();
            }
        }

        class Y : X
        {
            sealed protected override void F() { Console.WriteLine("Y.F"); }
            protected override void F2() { Console.WriteLine("Y.F2"); }

             public virtual void RunFunY()
            {
                this.F();
                this.F2();
            }
        }

        class Z : Y
        {
            // Attempting to override F causes compiler error CS0239.
            // protected override void F() { Console.WriteLine("Z.F"); }

            // Overriding F2 is allowed.
            protected override void F2() { Console.WriteLine("Z.F2"); }

            public virtual void RunFunZ()
            {
                this.F();
                this.F2();
            }
        }

        public static void RunSealedLogic()
        {
            var X = new X();
            X.RunFunX();
            var Y = new Y();
            Y.RunFunY();
            var Z = new Z();
            Z.RunFunZ();
        }
    }
}
