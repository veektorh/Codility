using System;
namespace Codility
{
    public class TreeSample
    {
        public TreeSample()
        {
        }

        public class Node
        {
            int data;
            Node left;
            Node right;

            public Node(int data)
            {
                this.data = data;
            }

            public Node createTree()
            {
                var node_a = new Node(2);
                var sub1_left = new Node(3);
                var sub1_right = new Node(4);
                var sub2_left = new Node(5);
                var sub2_right = new Node(6);

                node_a.left = sub1_left;
                node_a.right = sub1_right;
                sub1_left.left = sub2_left;
                sub1_right.right = sub2_right;

                return node_a;
            }

            public int findSum(Node tree)
            {
                if (tree == null)
                {
                    return 0;
                }
                return tree.data + findSum(tree.left) + findSum(tree.right);
            }

            public void Run()
            {
                var root = createTree();
                var sum = findSum(root);
                Console.WriteLine(sum);
            }
        }
    }
}
