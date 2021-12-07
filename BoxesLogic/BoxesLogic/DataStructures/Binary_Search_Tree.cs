using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic
{   
   internal class Binary_Search_Tree<T> where T : IComparable<T>
   {
       Node root;

        public bool IsEmpty => root is null;

        //Add new node to the BST
        public void Add(T newItem)
       {
           Node n = new Node(newItem);
   
           if (root == null) //empty tree
           {
               root = n;
               return;
           }
   
           Node tmp = root;
           Node parent = root;
   
           //the parent Node will set itself as the actual parent of the tmp Node because the tmp is moving only at the next lines,
           //this way we can approach the next node and define it as a part of the tree.
           while (tmp != null)
           {
               
               parent = tmp;
               if (newItem.CompareTo(tmp.data) < 0) tmp = tmp.left;
               if (newItem.CompareTo(tmp.data) > 0) tmp = tmp.right;
               else tmp = tmp.right;
           }
            
           //after we set the tmp Node in place (we found the null place) we approach to the parent Node
           //using the parent we DEFINE (parent.left/right = n) our new node.
           if (newItem.CompareTo(parent.data) < 0) parent.left = n;
           else parent.right = n;
       }

        public void ScanInOrder(Action<T> action)
       {
           ScanInOrder(root, action);
       }
   
       private void ScanInOrder(Node tmpRoot, Action<T> action)
       {
           if (tmpRoot == null) return;
   
           ScanInOrder(tmpRoot.left, action);
           action(tmpRoot.data);
           ScanInOrder(tmpRoot.right, action);
       }        
        
        //Search weather there's a Node with the data of the "searchItem", if so return the data of that item
        //if not return false
        public bool Find(T searchItem, out T foundNode)
        {
            foundNode = default(T);
            Node searcher = new Node(searchItem);

            if (root == null) return false;

            Node tmp = root;
            Node parent = new Node(root.data);

            while(tmp.data.CompareTo(searcher.data) != 0)
            {
                parent = tmp;
                if (tmp.data.CompareTo(searcher.data) < 0) tmp = parent.right;
                else if (tmp.data.CompareTo(searcher.data) > 0) tmp = parent.left;
                if (tmp == null) return false;                
            }

            foundNode = tmp.data;            
            return true;            
        }

        //Does the node exsist or not.
        //if yes return true
        //if not - create new node in the currect place and return false
        public bool FindAndUpdate(T searchItem, out T foundData)
        {            
            //create the requested node to add            
            //check if the tree is full, if not create 
            if (root == null)
            {
                Node node = new Node(searchItem);
                root = node;
                foundData = node.data;
                return false;
            }

            //create parent and tmp inorder to move around the tree
            Node tmp = root;
            Node parent = null;

            //set in place or find null
            while(tmp != null)
            {
                parent = tmp;
                //if bigger or smaller go to you place in the tree.
                if (tmp.data.CompareTo(searchItem) > 0) tmp = tmp.left;
                else if (tmp.data.CompareTo(searchItem) < 0) tmp = tmp.right; 
                else if (tmp.data.CompareTo(searchItem) == 0)
                {
                    foundData = tmp.data;
                    return true;
                }
            }

            var n = new Node(searchItem);
            if (parent.data.CompareTo(searchItem) > 0) parent.left = n;
            else parent.right = n;
            foundData = n.data;
            return false;
        }
        
        //find the location to insert the node.
        //change the node if exsist,
        //create new node if not and return.
        public bool ClosestOrExact(T searchItem, out T foundData)
        {
            foundData = default(T);
            if (root is null) return false;
            Node temp = root;

            while (temp != null)
            {
                if (temp.data.CompareTo(searchItem) == 0)
                {
                    foundData = temp.data;
                    return true;
                }
                else if (temp.data.CompareTo(searchItem) < 0)
                {
                    temp = temp.right;
                }
                else if (temp.data.CompareTo(searchItem) > 0)
                {
                    foundData = temp.data;
                    temp = temp.left;
                }
            }
            return foundData != null;
        }

        //Delete Requested node
        public bool DeleteNode(T data)
        {
            root = DeleteNode(root, data);
            return (root != null);
        }
        private Node DeleteNode(Node root, T data)
        {
            //Base Case: If the tree is empty
            if (root == null)
                return null;

            //Otherwise, recur down the tree
            if(data.CompareTo(root.data) < 0)
                root.left = DeleteNode(root.left, data);
            else if (root.data.CompareTo(data) < 0)
                root.right = DeleteNode(root.right, data);

            // if key is same as root's key, then This is the
            // node to be deleted
            else
            {
                // node with only one child or no child
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // node with two children: Get the
                // inorder successor (smallest
                // in the right subtree)
                root.data = minValue(root.right);

                // Delete the inorder successor
                root.right = DeleteNode(root.right, root.data);
            }
            return root;
        }
        private T minValue(Node root)
        {
            T minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }

        //Node class defenition
        class Node 
       {
           public Node left;
           public Node right;
           public T data;
   
           public Node(T data)
           {
               this.data = data;
           }

            
        }
   }
   
}
