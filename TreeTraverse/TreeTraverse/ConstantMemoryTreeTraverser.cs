using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraverse
{
    public class ConstantMemoryTreeTraverser : ITreeTraverser
    {
        public List<int> TraverseTree(TreeNode root)
        {
            if (root == null) return null;

            List<int> result = new List<int>();
            TreeNode prev = root;
            TreeNode current = root.Left;
            TraverseTree(root, current, prev, result);
            result.Add(root.Value);
            prev = root;
            current = root.Right;
            TraverseTree(root, current, prev, result);
            return result;
        }

        public void TraverseTree(TreeNode root, TreeNode current, TreeNode prev, List<int> result)
        {
            while (current != root)
            {
                if (current == null)
                {
                    if (current == prev.Left)
                    {
                        result.Add(prev.Value);
                    }
                    current = prev.Parent;
                }
                else if (prev == current.Left)
                {
                    result.Add(current.Value);
                    prev = current;
                    current = prev.Right;
                }
                else if (prev == current.Right)
                {
                    prev = current;
                    current = prev.Parent;
                }
                else if (prev == current.Parent)
                {
                    prev = current;
                    current = prev.Left;
                }
            }
        }
    }
}
