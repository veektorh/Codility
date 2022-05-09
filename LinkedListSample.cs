using System;
namespace Codility
{
    public class LinkedListSample
    {
        public LinkedListSample()
        {
        }

        public class Node
        {
            int data;
            Node next;

            public Node(int data)
            {
                this.data = data;
            }

            public Node createLinkedList()
            {
                var node_a = new Node(6);
                var node_b = new Node(4);
                var node_c = new Node(3);
                var node_d = new Node(7);
                var node_e = new Node(1);

                node_a.next = node_b;
                node_b.next = node_c;
                node_c.next = node_d;
                node_d.next = node_e;

                return node_a;
            }

            public int countNodes(Node head)
            {
                int count = 1;
                Node current = head;
                while (current.next != null)
                {
                    count++;
                    current = current.next;
                }
                return count;
            }

            public void Run()
            {
                var sample = createLinkedList();
                var count = countNodes(sample);
                Console.WriteLine(count);
            }


        }

        public int factorial(int num)
        {
            
            if (num > 1)
            {
                return num * factorial(num - 1);
            }
            else
            {
                return 1;
            }
        }

        public int fibonacci(int num)
        {

            if (num >= 3)
            {
                return fibonacci(num - 1) + fibonacci(num - 2);
            }
            else
            {
                return 1;
            }
        }



    }
}
