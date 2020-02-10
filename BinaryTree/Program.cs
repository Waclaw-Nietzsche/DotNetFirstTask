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

        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="key"></param>
        /// <param name="leaf"></param>
        public void insertNode(int key, Node leaf)
        {

            if (key < leaf.value)
            {
                if (leaf.left != null)
                {
                    insertNode(key, leaf.left);
                }
                else
                {
                    leaf.left = new Node();
                    leaf.left.value = key;
                    leaf.left.left = null;
                    leaf.left.right = null;
                }
            }
            else if (key >= leaf.value)
            {
                if (leaf.right != null)
                {
                    insertNode(key, leaf.right);
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

        public void insertNode(int key)
        {
            if (this.root != null)
            {
                insertNode(key, this.root);
            }
            else
            {
                this.root = new Node();
                this.root.value = key;
                this.root.left = null;
                this.root.right = null;
            }
        }

        public Node findMinimum(Node cur)
        {
            while (cur.left != null)
            {
                cur = cur.left;
            }

            return cur;
        }
        /// <summary>
        /// Поиск элемента в дереве
        /// </summary>
        /// <param name="key"></param>
        /// <param name="leaf"></param>
        /// <returns></returns>
        public Node searchNode(int key, Node leaf)
        {
            if (leaf != null)
            {
                if (key == leaf.value)
                {
                    return leaf;
                }

                if (key < leaf.value)
                {
                    return searchNode(key, leaf.left);
                }
                else
                {
                    return searchNode(key, leaf.right);
                }
            }
            else
            {
                return null;
            }
        }

        public Node searchNode(int key)
        {
            return searchNode(key, this.root);
        }
        
        /// <summary>
        /// Удаление элемента в дереве
        /// </summary>
        /// <param name="root"></param>
        /// <param name="deleteNode"></param>
        /// <returns></returns>
        public Node deleteN(Node root, Node deleteNode)
        {
            if (root == null)
            {
                return root;
            }

            if (deleteNode.value < root.value)
            {
                root.left = deleteN(root.left, deleteNode);
            }

            if (deleteNode.value > root.value)
            {
                root.right = deleteN(root.right, deleteNode);
            }

            if (deleteNode.value == root.value)
            {
                if (root.left == null && root.right == null)
                {
                    root = null;
                    return root;
                }

                else if (root.left == null)
                {
                    Node temp = root;
                    root = root.right;
                    temp = null;
                }

                else if (root.right == null)
                {
                    Node temp = root;
                    root = root.left;
                    temp = null;
                }

                else
                {
                    Node min = findMinimum(root.right);
                    root.value = min.value;
                    root.right = deleteN(root.right, min);
                }
            }

            return root;
        }
        
        public void deleteN(int key)
        {
            Node deleteNode = searchNode(key);
            deleteN(root, deleteNode);
        }

        /// <summary>
        /// Прямой обход дерева
        /// </summary>
        public void preorder_print()
        {
            preorder_print(this.root);
            Console.WriteLine("");
        }

        public void preorder_print(Node leaf)
        {
            if (leaf != null)
            {
                Console.WriteLine("{0},", leaf.value);
                preorder_print(leaf.left);
                preorder_print(leaf.right);
            }
        }


        /// <summary>
        /// Центрированный обход дерева
        /// </summary>
        public void inorder_print()
        {
            inorder_print(this.root);
            Console.WriteLine("");
        }

        public void inorder_print(Node leaf)
        {
            if (leaf != null)
            {
                inorder_print(leaf.left);
                Console.WriteLine("{0},", leaf.value);
                inorder_print(leaf.right);
            }
        }

        /// <summary>
        /// Обратный обход дерева
        /// </summary>
        public void postorder_print()
        {
            postorder_print(this.root);
            Console.WriteLine("");
        }

        public void postorder_print(Node leaf)
        {
            if (leaf != null)
            {
                postorder_print(leaf.left);
                postorder_print(leaf.right);
                Console.WriteLine("{0},", leaf.value);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinTree tree = new BinTree();
            var exit = false;
            Node temp;
            while (!exit)
            {
                Console.WriteLine("Выберите желаемое действие с двухсвязным списокм:");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1 - Добавить элемент в дерево.");
                Console.WriteLine("2 - Удалить элемент из дерева.");
                Console.WriteLine("3 - Найти элемент в дереве."); 
                Console.WriteLine("4 - Прямой обход дерева."); 
                Console.WriteLine("5 - Центрированный обход."); 
                Console.WriteLine("6 - Обратный обход.");
                Console.WriteLine("0 - Выйти из программы.");
                var val = Console.ReadLine();
                var choice = Convert.ToInt32(val);
                var data = "";
                int key;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите данные для добавляемого элемента:");
                        data = Console.ReadLine();
                        tree.insertNode(Convert.ToInt32(data));
                        break;
                    case 2:
                        Console.WriteLine("Введите данные для удаляемого элемента:");
                        data = Console.ReadLine();
                        tree.deleteN(Convert.ToInt32(data));
                        break;
                    case 3:
                        Console.WriteLine("Введите данные для поиска элемента:");
                        data = Console.ReadLine();
                        temp = tree.searchNode(Convert.ToInt32(data));
                        if (temp != null)
                        {
                            Console.WriteLine("Элемент найден!");
                        }
                        else
                        {
                            Console.WriteLine("Элемент НЕ найден!");
                        }
                        break;
                    case 4:
                        tree.preorder_print();
                        break;
                    case 5:
                        tree.inorder_print();
                        break;
                    case 6:
                        tree.postorder_print();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error.");
                        break;
                }

            }
        }
    }
}