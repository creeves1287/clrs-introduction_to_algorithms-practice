using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeTraverse;

namespace TreeTraverseTests
{
    [TestClass]
    public class TreeTraverseTests
    {
        [TestMethod]
        public void ConstantMemoryTreeTraverser()
        {
            ITreeTraverser treeTraverser = new ConstantMemoryTreeTraverser();
            RunTests(treeTraverser);
        }

        private void RunTests(ITreeTraverser treeTraverser)
        {
            TreeNode root = BuildTree();
            List<int> expected = new List<int> { 2, 3, 4, 5, 6, 8, 10, 11, 12, 14 };
            List<int> result = treeTraverser.TraverseTree(root);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        private TreeNode BuildTree()
        {
            TreeNode eight = new TreeNode(8),
                     four = new TreeNode(4),
                     six = new TreeNode(6),
                     two = new TreeNode(2),
                     three = new TreeNode(3),
                     five = new TreeNode(5),
                     twelve = new TreeNode(12),
                     fourteen = new TreeNode(14),
                     ten = new TreeNode(10),
                     eleven = new TreeNode(11);

            TreeNode root = eight;
            eight.Left = four;
            eight.Right = twelve;
            four.Left = three;
            four.Right = six;
            four.Parent = eight;
            three.Left = two;
            three.Parent = four;
            two.Parent = three;
            six.Parent = four;
            six.Left = five;
            five.Parent = six;
            twelve.Left = eleven;
            twelve.Right = fourteen;
            twelve.Parent = eight;
            eleven.Parent = twelve;
            eleven.Left = ten;
            fourteen.Parent = twelve;
            ten.Parent = eleven;
            return root;
        }
    }
}
