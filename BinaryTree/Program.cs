using System;

namespace BinaryTree
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class BinTree
    {
        public Node root = null;
        
        public void insert(int key, Node leaf)
        {

            if(key < leaf.value)
            {
                if(leaf.left != null)
                {
                    insert(key, leaf.left);
                }
                else
                {
                    leaf.left = new Node();
                    leaf.left.value = key;
                    leaf.left.left = null;
                    leaf.left.right = null;
                }
            }
            else if(key >= leaf.value)
            {
                if(leaf.right != null)
                {
                    insert(key, leaf.right);
                }
                else
                {
                    leaf.right = new Node();
                    leaf.right.value = key;
                    leaf.right.right = null;
                    leaf.right.left = null;
                }
            }
        }
        
        public void insert(int key)
        {
            if(this.root != null)
            {
                insert(key, this.root);
            }
            else
            {
                this.root = new Node();
                this.root.value = key;
                this.root.left = null;
                this.root.right = null;
            }
        }
        
        public Node search(int key, Node leaf)
        {
            if(leaf != null)
            {
                if(key == leaf.value)
                {
                    return leaf;
                }
                if(key < leaf.value)
                {
                    return search(key, leaf.left);
                }
                else
                {
                    return search(key, leaf.right);
                }
            }
            else
            {
                return null;
            }
        }

        public Node search(int key)
        {
            return search(key, this.root);
        }
        
        public void inorder_print()
        {
            inorder_print(this.root);
            Console.WriteLine("");
        }        
        
        public void inorder_print(Node leaf)
        {
            if(leaf != null)
            {
                inorder_print(leaf.left);
                Console.WriteLine("{0},",leaf.value);
                inorder_print(leaf.right);
            }
        }
        
        public void postorder_print()
        {
            postorder_print(this.root);
            Console.WriteLine("");
        }

        public void postorder_print(Node leaf)
        {
            if(leaf != null)
            {
                postorder_print(leaf.left);
                postorder_print(leaf.right);
                Console.WriteLine("{0},",leaf.value);
            }
        }

        public void preorder_print()
        {
            preorder_print(this.root);
            Console.WriteLine("");
        }

        public void preorder_print(Node leaf)
        {
            if(leaf != null)
            {
                Console.WriteLine("{0},",leaf.value);
                preorder_print(leaf.left);
                preorder_print(leaf.right);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BinTree tree = new BinTree();
            tree.insert(5);
            tree.insert(6);
            tree.insert(1);
            tree.insert(2);
            tree.insert(4);
            tree.insert(3);
            tree.inorder_print();
            var temp = tree.search(1);
            Console.WriteLine(temp);
            tree.postorder_print();
            Console.WriteLine("");
            tree.preorder_print();
        }
    }
}