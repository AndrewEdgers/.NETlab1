using System.Collections;

namespace NETLab1
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Previous { get; set; }  // Nullable
        public Node<T>? Next { get; set; }  // Nullable

        public Node(T value)
        {
            Value = value;
        }
    }

    public class FlexibleDeque<T> : IEnumerable<T>
    {
        private Node<T>? _head;  // Nullable
        private Node<T>? _tail;  // Nullable
        private int _count;

        public event Action<T>? ItemEnqueued;
        public event Action<T>? ItemDequeued;
        public event Action? DequeEmptied;

        public FlexibleDeque() { }

        public void EnqueueHead(T item)
        {
            var node = new Node<T>(item);
            if (_head == null)
                _head = _tail = node;
            else
            {
                node.Next = _head;
                _head.Previous = node;
                _head = node;
            }
            _count++;
            ItemEnqueued?.Invoke(item);
        }

        public void EnqueueTail(T item)
        {
            var node = new Node<T>(item);
            if (_tail == null)
                _head = _tail = node;
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }
            _count++;
            ItemEnqueued?.Invoke(item);
        }

        public T DequeueHead()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty.");
            var value = _head.Value;
            _head = _head.Next;
            if (_head != null)
                _head.Previous = null;
            else
                _tail = null;
            _count--;
            ItemDequeued?.Invoke(value);
            return value;
        }

        public T DequeueTail()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty.");
            var value = _tail.Value;
            _tail = _tail.Previous;
            if (_tail != null)
                _tail.Next = null;
            else
                _head = null;
            _count--;
            ItemDequeued?.Invoke(value);
            return value;
        }

        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
            DequeEmptied?.Invoke();
        }

        public bool Contains(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
