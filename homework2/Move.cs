using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public interface IMovable
    {
        Vector GetPosition();
        void SetPosition(Vector value);
        Vector GetVelocity();
    }

    public class MoveCommand : Command
    {
        private IMovable m;
        public MoveCommand(IMovable movable) { this.m = movable; }

        public virtual void Execute()
        {
            m.SetPosition(Vector.Add(m.GetPosition(), m.GetVelocity()));
        }
    }
    public class MovableAdapter : IMovable
    {
        UObject m;
        public MovableAdapter(UObject m) { this.m = m; }

        public Vector GetPosition() { return (Vector)m["Position"]; }

        public void SetPosition(Vector value) { m["Position"] = value; }

        public Vector GetVelocity() { return (Vector)m["Velocity"]; }
        //public Vector Velocity
        //{
        //    get { return (Vector)m["Velocity"]; }
        //    set { m["Velocity"] = value; }
        //}
    }
}
