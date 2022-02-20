using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public  interface IMyInterface
    {
        int MyProperty { get; set; }
        int MyProperty2 { get; set; }
        int main();

        int mainSub(int a, int b);
        int mainSub(int a, int b,int c);
    }

    public abstract   class  Class1 :IMyInterface 
    {
        public int MyProperty { get; set; }

        public int MyProperty2{ get; set; }

        public string name { get; set; }
        public abstract int name3();
        public int main()
        {
            throw new NotImplementedException();
        }

        public int mainSub(int a, int b)
        {
            throw new NotImplementedException();
        }



        public int  mainSub(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        internal  int name2 { get; set; }
        public virtual int  propee()
        {
            return name2;
        }
        protected  readonly int n = 22;

    }
}
