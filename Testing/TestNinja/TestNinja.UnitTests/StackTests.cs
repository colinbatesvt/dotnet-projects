using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {

        [Test]
        public void Push_WhenCalledWithObject_PushesObjectToStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            Assert.That(stack.Peek(), Is.EqualTo(1));
        }

        [Test]
        public void Push_WhenCalledWithNull_ThrowsArgumentNullException()
        {
            Stack<string> stack = new Stack<string>();
            string s = null;

            Assert.That( (()=> stack.Push(s)), Throws.ArgumentNullException);
        }

        [Test]
        public void Pop_WhenCalled_ReturnsTopValueOfStack()
        { 
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.That(stack.Pop(), Is.EqualTo(2));
        }

        [Test]
        public void Pop_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Stack<int> stack = new Stack<int>();
            Assert.That((()=> stack.Pop()), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_RemovesTopValueOfStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_WhenCalled_ReturnsTopValueOfStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.That(stack.Peek(), Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Stack<int> stack = new Stack<int>();
            Assert.That((() => stack.Peek()), Throws.InvalidOperationException);
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            Stack<int> stack = new Stack<int>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }
    }
}
