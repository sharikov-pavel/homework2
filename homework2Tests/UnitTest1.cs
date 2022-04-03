using homework2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace homework2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class homework2Tests
        {
            [TestMethod]
            public void DirectMovement()
            {
                Mock<IMovable> mock = new Mock<IMovable>();
                mock.Setup(move => move.GetPosition()).Returns(new Vector(new int[] { 12, 5 })).Verifiable();
                mock.Setup(move => move.GetVelocity()).Returns(new Vector(new int[] { -7, 3 })).Verifiable();
                Vector vector = new Vector(new int[] { 5, 8 });

                MoveCommand command = new MoveCommand(mock.Object);
                command.Execute();

                Vector.Equals(mock.Object.GetPosition(), vector);
            }

            [TestMethod]
            public void MovementWithoutPosition()
            {
                Mock<IMovable> mock = new Mock<IMovable>();
                mock.Setup(move => move.GetPosition()).Throws(new Exception()).Verifiable();
                mock.Setup(move => move.GetVelocity()).Returns(new Vector(new int[] { -7, 3 })).Verifiable();
                mock.Setup(move => move.SetPosition(It.Is<Vector>(p => p.Equals(new Vector(new int[] { 5, 8 }))))).Verifiable();

                MoveCommand command = new MoveCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }

            [TestMethod]
            public void MovementWithoutVelocity()
            {
                Mock<IMovable> mock = new Mock<IMovable>();
                mock.Setup(move => move.GetPosition()).Returns(new Vector(new int[] { 12, 5 })).Verifiable();
                mock.Setup(move => move.GetVelocity()).Throws(new Exception()).Verifiable();
                mock.Setup(move => move.SetPosition(It.Is<Vector>(p => p.Equals(new Vector(new int[] { 5, 8 }))))).Verifiable();

                MoveCommand command = new MoveCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }

            [TestMethod]
            public void MovementNotChangePosition()
            {
                Mock<IMovable> mock = new Mock<IMovable>();
                mock.Setup(move => move.GetPosition()).Returns(new Vector(new int[] { 12, 5 })).Verifiable();
                mock.Setup(move => move.GetVelocity()).Returns(new Vector(new int[] { -7, 3 })).Verifiable();
                mock.Setup(move => move.SetPosition(It.IsAny<Vector>())).Throws(new Exception()).Verifiable();

                MoveCommand command = new MoveCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }

            [TestMethod]
            public void ObjectRotation()
            {
                Mock<IRotable> mock = new Mock<IRotable>();

                mock.Setup(rotate => rotate.GetDirection()).Returns(90).Verifiable();
                mock.Setup(rotate => rotate.GetAngularVelocity()).Returns(100).Verifiable();
                mock.Setup(rotate => rotate.GetMatrixDirection()).Returns(10).Verifiable();

                RotateCommand command = new RotateCommand(mock.Object);
                command.Execute();

                int.Equals(mock.Object.GetDirection(), 90);
            }

            [TestMethod]
            public void ObjectWithoutRotation()
            {
                Mock<IRotable> mock = new Mock<IRotable>();

                mock.Setup(rotate => rotate.GetDirection()).Throws(new Exception()).Verifiable();
                mock.Setup(rotate => rotate.GetAngularVelocity()).Returns(100).Verifiable();
                mock.Setup(rotate => rotate.GetMatrixDirection()).Returns(10).Verifiable();

                RotateCommand command = new RotateCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }

            [TestMethod]
            public void ObjectWithoutAngularVelocity()
            {
                Mock<IRotable> mock = new Mock<IRotable>();

                mock.Setup(rotate => rotate.GetDirection()).Returns(90).Verifiable();
                mock.Setup(rotate => rotate.GetAngularVelocity()).Throws(new Exception()).Verifiable();
                mock.Setup(rotate => rotate.GetMatrixDirection()).Returns(10).Verifiable();

                RotateCommand command = new RotateCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }

            [TestMethod]
            public void ObjectWithoutMatrixDirection()
            {
                Mock<IRotable> mock = new Mock<IRotable>();

                mock.Setup(rotate => rotate.GetDirection()).Returns(90).Verifiable();
                mock.Setup(rotate => rotate.GetAngularVelocity()).Returns(100).Verifiable();
                mock.Setup(rotate => rotate.GetMatrixDirection()).Throws(new Exception()).Verifiable();

                RotateCommand command = new RotateCommand(mock.Object);

                Assert.ThrowsException<Exception>(() => command.Execute());
            }
        }
    }
}
