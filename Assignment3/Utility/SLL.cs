using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    [DataContract]
    [KnownType(typeof(SLL))]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        private Node head;

        [DataMember]
        private int count;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Add(value, Count());
        }

        public void AddFirst(User value)
        {
            Add(value, 0);
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

            Node newNode = new Node(value);

            if (IsEmpty() || index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }


        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new CannotRemoveException();

            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            Remove(count - 1);
        }

        public void Remove(int index)
        {
            if (IsEmpty() || index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            count--;
        }


        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public void Prepend(User value)
        {
            AddFirst(value);
        }

        public void Append(User value)
        {
            AddLast(value);
        }

        public void InsertAt(int index, User value)
        {
            Add(value, index);
        }

        public void GetIndex(User value)
        {
            IndexOf(value);
        }

        public bool HasItem(User value)
        {
            return Contains(value);
        }

        // Additional functionalities
        public void Reverse()
        {
            if (IsEmpty() || count == 1)
                return;

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        public void SortByName()
        {
            // Implementation for sorting by name (assuming User class has a property called Name)
            throw new NotImplementedException();
        }

        public User[] CopyToArray()
        {
            User[] array = new User[count];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }
            return array;
        }

        public void Join(SLL list)
        {
            if (list == null || list.IsEmpty())
                return;

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = list.head;
            count += list.Count();
        }

        public (SLL, SLL) Divide(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            SLL firstHalf = new SLL();
            SLL secondHalf = new SLL();

            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex < index)
                    firstHalf.AddLast(current.Data);
                else
                    secondHalf.AddLast(current.Data);
                current = current.Next;
                currentIndex++;
            }

            return (firstHalf, secondHalf);
        }

        [DataContract]
        private class Node
        {
            [DataMember]
            public User Data { get; set; }
            [DataMember]
            public Node Next { get; set; }

            public Node(User data)
            {
                Data = data;
                Next = null;
            }
        }
    }
}

namespace Assignment3
{
    public class CannotRemoveException : Exception
    {
        public CannotRemoveException() : base("Cannot remove element from an empty list.")
        {
        }
    }
}