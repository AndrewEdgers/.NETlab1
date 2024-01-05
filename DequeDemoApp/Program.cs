using NETLab1;

namespace DequeDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var deque = new FlexibleDeque<string>();

            deque.ItemEnqueued += (item) => Console.WriteLine($"Item enqueued: {item}");
            deque.ItemDequeued += (item) => Console.WriteLine($"Item dequeued: {item}");
            deque.DequeEmptied += () => Console.WriteLine("Deque has been cleared.");

            Console.WriteLine("Adding items...");
            deque.EnqueueTail("First");
            deque.EnqueueTail("Second");
            deque.EnqueueHead("Third");

            Console.WriteLine("\nItems in deque after adding:");
            foreach (var item in deque)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nRemoving from head: {deque.DequeueHead()}");
            Console.WriteLine($"Removing from tail: {deque.DequeueTail()}");

            Console.WriteLine("\nItems in deque after removing:");
            foreach (var item in deque)
            {
                Console.WriteLine(item);
            }

            deque.Clear();
            Console.WriteLine($"\nIs deque empty after clearing? {deque.IsEmpty}");

            Console.WriteLine("\nAttempting to remove from an empty deque to trigger an exception...");
            try
            {
                deque.DequeueHead();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nAdding a null item to the deque (if allowed)...");
            try
            {
                deque.EnqueueTail(null);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Null values are not allowed in this deque.");
            }
        }
    }
}
