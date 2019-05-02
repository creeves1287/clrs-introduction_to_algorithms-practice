using System.Collections.Generic;

namespace TreeTraverse
{
    public interface ITreeTraverser
    {
        List<int> TraverseTree(TreeNode root);
    }
}