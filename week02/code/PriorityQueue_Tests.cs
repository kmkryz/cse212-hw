using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of priority (highest first)
    // Defect(s) Found: The dequeue order is incorrect. It's not respecting the priority.
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and dequeue them
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: The FIFO order for same priority items is not maintained.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and dequeue them
    // Expected Result: Higher priority items should be dequeued first, then FIFO for same priority
    // Defect(s) Found: The order is incorrect. It's not respecting both priority and FIFO order.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("Low2", 1);
        priorityQueue.Enqueue("High2", 3);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
        Assert.AreEqual("Low2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: Should throw an exception
    // Defect(s) Found: No defect. The exception is thrown as expected.
    [ExpectedException(typeof(System.Exception))]
    public void TestPriorityQueue_DequeueEmpty()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}