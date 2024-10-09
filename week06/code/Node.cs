public class Node
{
    public int Data { get; private set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If the value is equal to the current node's data, we don't insert (ensuring uniqueness)
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Check if the BST contains a specific value
    /// </summary>
    /// <param name="value">The value to search for</param>
    /// <returns>true if the value is found, otherwise false</returns>
    public bool Contains(int value)
    {
        // If the current node's value matches, we've found it
        if (value == Data)
        {
            return true;
        }

        // If the value is less than the current node's value, search the left subtree
        if (value < Data && Left != null)
        {
            return Left.Contains(value);
        }

        // If the value is greater than the current node's value, search the right subtree
        if (value > Data && Right != null)
        {
            return Right.Contains(value);
        }

        // If we've reached this point, the value is not in the tree
        return false;
    }

    public int GetHeight()
    {
        // Base case: if this node is a leaf (no children), its height is 1
        if (Left == null && Right == null)
        {
            return 1;
        }

        // Recursive case: get the height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return 1 (for this node) plus the maximum of left and right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}