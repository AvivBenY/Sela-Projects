using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic
{
    class Double_Linked_List<T>
    {
        public Node start;
        public Node end;        
        
        public Node AddFirst(T val)
        {
            Node n = new Node(val);
            if (start == null)
            {
                start = n;
                end = n;
            }
            else
            {
                start.previews = n;
                n.next = start;
                start = n;
            }
            return n;
        }

        public void AddLast(T val)
        {
            if (start == null)
            {
                AddFirst(val);
                return;
            }
            Node n = new Node(val);
            n.previews = end;
            end.next = n;
            end = n;
        }
        
        public bool RemoveFirst(out T saveFirstValue)
        {
            saveFirstValue = default(T);
            if (start == null) return false;        
            saveFirstValue = start.data;
            start = start.next;        
            if (start == null) end = null;                            
            return true;
        }

        public bool RemoveLast(out T data)
        {
            data = default(T);
            if (end == null) return false;
            Node n = end.previews;
            data = end.data;
            n.next = null;
            end = n;
            return true;
        }

        public bool GetAt(int index, out T data)
        {
            Node temp = start;
            int i = 0;
            data = default(T);
            while (temp != null && i < index)
            {
                i++;
                temp = temp.next;
            }
            if (temp == null) return false;
            data = temp.data;
            return true;
        }

        public bool AddAt(int index, T value)
        {
            Node newNode = new Node(value);
            Node temp = start;
            int i = 0;
            if (temp == null) return false;
            for (i = 0, temp = start; temp != null && i != index; i++, temp = temp.next) ;
            if (index == i && temp != null)
            {
                newNode.previews = temp.previews;
                temp.previews.next = newNode;
                temp.previews = newNode;
                newNode.next = temp;
                return true;
            }
            return false;
        }

        public void MoveToFirst(Node node)
        {
            //were handling the first node
            if (node.previews is null) return;
            //were handling the last node
            if (node.next is null)
            {
                node.previews.next = null;
                this.AddFirst(node.data);
                return;
            }
            //node in the middle
            else
            {
                node.previews.next = node.next;
                node.next.previews = node.previews;
                this.AddFirst(node.data);
            }
        }

        public void RemoveNode(Node node)
        {
            if (node.next != null) node.next.previews = node.previews;
            else end = node.previews;
            if (node.previews != null) node.previews.next = node.next;
            else start = node.next;            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = start;
            while (tmp != null)
            {
                sb.AppendLine(tmp.data.ToString());
                tmp = tmp.next;
            }
            return sb.ToString();
        }

        internal class Node
        {
            public T data;
            public Node next;
            public Node previews;

            public Node(T data)
            {
                this.data = data;
                next = null;
                previews = null;
            }
        }
    }
}