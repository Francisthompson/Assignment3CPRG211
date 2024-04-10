using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment3;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void TestEmptyLinkedList()
        {
            SLL list = new SLL();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestPrepend()
        {
            SLL list = new SLL();
            list.Prepend(new User(1, "John", "john@example.com", "password"));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("John", list.GetValue(0).Name);
        }

        [Test]
        public void TestAppend()
        {
            SLL list = new SLL();
            list.Append(new User(2, "Alice", "alice@example.com", "password"));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("Alice", list.GetValue(0).Name);
        }

        [Test]
        public void TestInsertAtIndex()
        {
            SLL list = new SLL();
            list.Append(new User(3, "Bob", "bob@example.com", "password"));
            list.InsertAt(0, new User(4, "Charlie", "charlie@example.com", "password"));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual("Charlie", list.GetValue(0).Name);
        }

        [Test]
        public void TestReplace()
        {
            SLL list = new SLL();
            list.Append(new User(5, "David", "david@example.com", "password"));
            list.Replace(new User(6, "Eva", "eva@example.com", "password"), 0);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("Eva", list.GetValue(0).Name);
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            SLL list = new SLL();
            list.Append(new User(7, "Frank", "frank@example.com", "password"));
            list.RemoveFirst();
            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            SLL list = new SLL();
            list.Append(new User(8, "Grace", "grace@example.com", "password"));
            list.RemoveLast();
            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            SLL list = new SLL();
            list.Append(new User(9, "Harry", "harry@example.com", "password"));
            list.Append(new User(10, "Ivy", "ivy@example.com", "password"));
            list.Remove(0);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("Ivy", list.GetValue(0).Name);
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            SLL list = new SLL();
            list.Append(new User(11, "Jack", "jack@example.com", "password"));
            list.Append(new User(12, "Kate", "kate@example.com", "password"));
            Assert.AreEqual(1, list.IndexOf(new User(12, "Kate", "kate@example.com", "password")));
            Assert.AreEqual("Kate", list.GetValue(1).Name);
        }

        [Test]
        public void TestAdditionalFunctionality()
        {
            SLL list1 = new SLL();
            list1.Append(new User(13, "Liam", "liam@example.com", "password"));
            list1.Append(new User(14, "Mia", "mia@example.com", "password"));

            SLL list2 = new SLL();
            list2.Append(new User(15, "Noah", "noah@example.com", "password"));
            list2.Append(new User(16, "Olivia", "olivia@example.com", "password"));

            list1.Join(list2);
            Assert.AreEqual(4, list1.Count());
            Assert.AreEqual("Noah", list1.GetValue(2).Name);

            (SLL firstHalf, SLL secondHalf) = list1.Divide(2);
            Assert.AreEqual(2, firstHalf.Count());
            Assert.AreEqual("Liam", firstHalf.GetValue(0).Name);
            Assert.AreEqual(2, secondHalf.Count());
            Assert.AreEqual("Noah", secondHalf.GetValue(0).Name);
        }
    }
}
