using System;

namespace LinkedList
{
    public class Node
    {
        public string data;
        public Node next;
        public Node previous;

        public Node(string data)
        {
            this.data = data;
            next = null;
            previous = null;
        }
    }

    public class List
    {
        public Node begin;
        
        public Node GetLast()
        {
            Node last = this.begin;
            while (last.next != null)
            {
                last = last.next;
            }

            return last;
        }
        
        /// <summary>
        /// Добавляет элемент в конец списка.
        /// </summary>
        /// <param name="data">Данные для элемента списка.</param>
        public void InsertAtEnd(string data)
        {
            Node node = new Node(data);
            if (this.begin == null)
            {
                node.previous = null;
                this.begin = node;
            }
            else
            {
                Node last = this.GetLast();
                last.next = node;
                node.previous = last;
            }
        }
        /// <summary>
        /// Добавляет элемент в начало списка.
        /// </summary>
        /// <param name="data">Данные для элемента списка.</param>
        public void InsertAtFront(string data)
        {
            Node node = new Node(data);
            node.next = this.begin;
            node.previous = null;
            if (this.begin != null)
            {
                this.begin.previous = node;
            }
            this.begin = node;
        }
        /// <summary>
        /// Добавляет элемент списка после указанного.
        /// </summary>
        /// <param name="selNumb">Номер элемента после которого необходимо поместить элемент.</param>
        /// <param name="data">Данные для элемента списка.</param>
        public void InsertAfterSelected(int selNumb, string data)
        {
            Node selected = this.begin;
            int tempNum = 1;
            if (tempNum == selNumb)
            {
                selected = this.begin;
            }
            while (tempNum != selNumb) 
            {  
                selected = selected.next;
                tempNum += 1;
            }
            Node node = new Node(data);
            node.next = selected.next;
            selected.next = node;
            node.previous = selected;
            if (node.next != null)
            {
                node.next.previous = node;
            }
        }
        
        /// <summary>
        /// Добавление элемента списка перед указанным.
        /// </summary>
        /// <param name="selNumb">Номер элемента перед которым необходимо поместить элемент.</param>
        /// <param name="data">Данные для элемента списка.</param>
        public void InsertBeforeSelected(int selNumb, string data)
        {
            Node selected = this.begin;
            int tempNum = 1;
            if (tempNum == selNumb)
            {
                this.InsertAtFront(data);
                return;
            }
            while (tempNum != selNumb) 
            {  
                selected = selected.next;
                tempNum += 1;
            }
            Node node = new Node(data);
            node.next = selected;
            node.previous = selected.previous;
            
            selected.previous.next = node;
            selected.previous = node;
            
            if (node.next != null)
            {
                node.next.previous = node;
            }
        }
        /// <summary>
        /// Удаление выбранного элемента списка.
        /// </summary>
        /// <param name="delNumber">Номер удаляемого элемента.</param>
        public void DeleteSelected(int delNumber)  
        {  
            Node node = this.begin;
            int tempNum = 1;
            if (tempNum == delNumber)
            {
                this.begin = node.next;
                node.next.previous = node.previous;
            }
            while (tempNum != delNumber) 
            {  
                node = node.next;
                tempNum += 1;
            }  
            if (node == null) 
            {  
                return;  
            }  
            if (node.next != null) 
            {  
                node.next.previous = node.previous;  
            }  
            if (node.previous != null) 
            {  
                node.previous.next = node.next;  
            }  
        }
        /// <summary>
        /// Разворот списка.
        /// </summary>
        public void ListReverse() 
        {
            if (this.begin == null || this.begin.next == null)
            {
                return;
            }
            
            Node current = this.begin;
            
            while (current.next != null) 
            {
                current = current.next;
            }

            this.begin = current;
            
            while (current != null) 
            {
                Node prev = current.previous;
                current.previous = current.next;
                current.next = prev;
                current = prev;
            }
        }
        /// <summary>
        /// Вывод данных элементов списка.
        /// </summary>
        public void PrintList()
        {
            if (this.begin == null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            Node here = this.begin;
            Console.WriteLine("DATA is: {0}",here.data);
            while (here.next != null)
            {
                here = here.next;
                Console.WriteLine("DATA is: {0}",here.data);
            }
            Console.WriteLine("------------");
        }
    }
    
    class Program
    {
        private static void Main()
        {
            var list = new List();
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите желаемое действие с двухсвязным списокм:");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1 - Добавить элемент в начало списка.");
                Console.WriteLine("2 - Добавить элемент в конец списка.");
                Console.WriteLine("3 - Добавить элемент перед выбранным элементом списка."); 
                Console.WriteLine("4 - Добавить элемент после выбранного элемента списка."); 
                Console.WriteLine("5 - Удалить выбранный элемент."); 
                Console.WriteLine("6 - Развернуть список.");
                Console.WriteLine("7 - Вывести список.");
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
                        list.InsertAtFront(data);
                        break;
                    case 2:
                        Console.WriteLine("Введите данные для добавляемого элемента:");
                        data = Console.ReadLine();
                        list.InsertAtEnd(data);
                        break;
                    case 3:
                        Console.WriteLine("Введите номер элемента:");
                        data = Console.ReadLine();
                        key = Convert.ToInt32(data);
                        Console.WriteLine("Введите данные для добавляемого элемента:");
                        data = Console.ReadLine();
                        list.InsertBeforeSelected(key,data);
                        break;
                    case 4:
                        Console.WriteLine("Введите номер элемента:");
                        data = Console.ReadLine();
                        key = Convert.ToInt32(data);
                        Console.WriteLine("Введите данные для добавляемого элемента:");
                        data = Console.ReadLine();
                        list.InsertAfterSelected(key,data);
                        break;
                    case 5:
                        Console.WriteLine("Введите номер удаляемого элемента:");
                        data = Console.ReadLine();
                        var delChoice = Convert.ToInt32(data);
                        list.DeleteSelected(delChoice);
                        break;
                    case 6:
                        list.ListReverse();
                        break;
                    case 7:
                        list.PrintList();
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