# Data Structures And Algorithms

## Data Structures

### Nodes
- **Types**
    - `SinglyNode<T>`: Represents a node in a singly linked list.
    - `DoublyNode<T>`: Represents a node in a doubly linked list.
    - `PriorityNode<T>` : Represents a node in a linked priority queue() with priority.
### Linked Lists
- **Interfaces**
    - `ILinkedList<T>`: Defines basic operations for a linked list.
- **Types**
    - `SinglyLinkedList<T>`: Implements a singly linked list.
    - `DoublyLinkedList<T>`: Implements a doubly linked list.
    - `CircularLinkedList<T>`: Implements a circular singly linked list.
    - `CircularDoublyLinkedList<T>`: Implements a circular doubly linked list.

### Stacks
- **Interfaces**
    - `IStack<T>`: Defines basic operations for a stack.
- **Types**
    - `Stack<T>`: Implements a stack based on Singly Linked List.
    - `ListStack<T>`: Implements a stack based on `List<T>`.

### Queues
- **Interfaces**
    - `IQueue<T>`: Defines basic operations for a queue.
    - `IDeque<T>`: Defines basic operations for a deque (double-ended queue).
- **Types**
    - `Queue<T>`: Implements a queue based on Singly Linked List.
    - `ListQueue<T>`: Implements a queue based on `List<T>`.
    - `Deque<T>`: Implements a deque based on Doubly Linked List.
    - `ListDeque<T>`: Implements a deque based on `List<T>`.
    - `LinkedPriorityQueue<T>` : Implements a priority queue based on Singly Linked List.