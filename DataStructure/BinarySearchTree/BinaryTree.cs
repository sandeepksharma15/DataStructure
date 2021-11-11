﻿using System;
using System.Runtime.CompilerServices;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private TreeNode _root { get; set; }

        public BinaryTree()
        {
            _root = null;
        }

        public void Insert(TreeNode node)
        {
            _root = InsertNode(_root, node);
        }

        public void PreOrder(Action<TreeNode> ProcessNode)
        {
            PreOrderTraversal(_root, ProcessNode);

        }

        public void PostOrder(Action<TreeNode> ProcessNode)
        {
            PostOrderTraversal(_root, ProcessNode);
        }

        public void LevelByLevelTraversal(Action<TreeNode> ProcessNode)
        {
            CircularCountQueue<TreeNode> queue = new CircularCountQueue<TreeNode>(20);

            queue.Add(_root);

            while (!queue.IsEmpty())
            {
                TreeNode p = queue.Remove();

                ProcessNode(p);

                if (p.Left is not null)
                    queue.Add(p.Left);

                if (p.Right is not null)
                    queue.Add(p.Right);
            }
        }

        public int Width()
        {
            throw new NotImplementedException();
        }

        public void Delete(TreeNode node)
        {
            DeleteNode(_root, node);
        }

        private void DeleteNode(TreeNode root, TreeNode node)
        {
            throw new NotImplementedException();
        }

        public void InOrder(Action<TreeNode> ProcessNode)
        {
            InOrderTraversal(_root, ProcessNode);
        }

        public TreeNode Search(int data)
        {
            return SearchTree(_root, data);
        }

        public int CountLeaves()
        {
            return CountLeaves(_root);
        }

        public int CountNodes()
        {
            return CountNodes(_root);
        }

        public int Height()
        {
            return Height(_root);
        }

        private static int Height(TreeNode root)
        {
            if (root is null)
                return 0;
            else
                return Math.Max(Height(root.Left), Height(root.Right)) + 1;
        }

        private static int CountNodes(TreeNode root)
        {
            if (root is null)
                return 0;
            else
                return CountNodes(root.Left) + CountNodes(root.Right) + 1;
        }

        private static int CountLeaves(TreeNode root)
        {
            if (root is null)
                return 0;
            else if (root.Left is null && root.Right is null)
                return 1;
            else
                return CountLeaves(root.Left) + CountLeaves(root.Right);
        }

        private static TreeNode SearchTree(TreeNode root, int data)
        {
            if (root is null)
                return null;
            else if (root.Data == data)
                return root;
            else if (root.Data > data)
                return SearchTree(root.Left, data);
            else
                return SearchTree(root.Right, data);
        }

        private static TreeNode InsertNode(TreeNode root, TreeNode node)
        {
            if (root is null)
                root = node;

            else if (root.Data > node.Data)
                root.Left = InsertNode(root.Left, node);

            else
                root.Right = InsertNode(root.Right, node);

            return root;
        }


        private void PostOrderTraversal(TreeNode root, Action<TreeNode> ProcessNode)
        {
            if (root is not null)
            {
                PostOrderTraversal(root.Left, ProcessNode);
                PostOrderTraversal(root.Right, ProcessNode);
                ProcessNode(root);
            }
        }

        private void InOrderTraversal(TreeNode root, Action<TreeNode> ProcessNode)
        {
            if (root is not null)
            {
                InOrderTraversal(root.Left, ProcessNode);
                ProcessNode(root);
                InOrderTraversal(root.Right, ProcessNode);
            }
        }

        private void PreOrderTraversal(TreeNode root, Action<TreeNode> ProcessNode)
        {
            if (root is not null)
            {
                ProcessNode(root);
                PreOrderTraversal(root.Left, ProcessNode);
                PreOrderTraversal(root.Right, ProcessNode);
            }
        }
    }
}
