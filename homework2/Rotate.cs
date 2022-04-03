using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public interface IRotable
    {
        int GetDirection();
        void SetDirection(int value);
        int GetAngularVelocity();
        int GetMatrixDirection();
    }
    public class RotateCommand : Command
    {
        private IRotable r;
        public RotateCommand(IRotable rotable) { this.r = rotable; }

        public virtual void Execute()
        {
            r.SetDirection((r.GetDirection() + r.GetAngularVelocity()) % r.GetMatrixDirection());
        }
    }
    public class RotableAdapter : IRotable
    {
        UObject r;
        public RotableAdapter(UObject r) { this.r = r; }

        public int GetAngularVelocity()
        {
            return (int)r["AngularVelocity"];
        }

        public int GetDirection()
        {
            return (int)r["Direction"];
        }

        public int GetMatrixDirection()
        {
            return (int)r["MatrixDirection"];
        }

        public void SetDirection(int value)
        {
            r["Direction"] = value;
        }

        //public int Direction
        //{
        //    get { return (int)r["Direction"]; }
        //    set { r["Direction"] = value; }
        //}
        //public int AngularVelocity
        //{
        //    get { return (int)r["AngularVelocity"]; }
        //    set { r["AngularVelocity"] = value; }
        //}
        //public int MatrixDirection
        //{
        //    get { return (int)r["MatrixDirection"]; }
        //    set { r["MatrixDirection"] = value; }
        //}


    }
}
