using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class SomeQueues
    {
        public SomeQueues() { }

        public static void Man()
        {
            Queue<string> queue = new();
            // Enqueue elements
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            Console.WriteLine("Queue contents after enqueuing:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            // Dequeue elements
            string dequeuedItem = queue.Dequeue();
            Console.WriteLine($"\nDequeued item: {dequeuedItem}");
            Console.WriteLine("\nQueue contents after dequeuing:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            // Peek at the next item
            string peekedItem = queue.Peek();
            Console.WriteLine($"\nNext item to dequeue (peek): {peekedItem}");
        }
    }
}
