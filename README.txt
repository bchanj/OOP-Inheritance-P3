P3 exercises your understanding of inheritance and Dependency Injection

 

For an acceptable P3 submission:

    Design using inheritance and Dependency Injection
    Fulfill requirements as specified in steps 1-9 from P1

 

Part  I: Class Design

Design an inheritance hierarchy of dataFilters, where each object encapsulates a prime number p and provides the functionality to filter and to scramble an integer sequence:

    filter() -- obj is of type dataFilter -- returns a subset of an encapsulated integer sequence, as follows
        returns ‘p’ if the internal sequence is null
        Otherwise, returns,
            when in ‘large’ mode, all integers larger than p
            when in ‘small’ mode, all integers smaller than p

    scramble(seq) -- obj is of type dataFilter
        updates the encapsulated sequence with seq, if not null
        returns a reordered integer sequence, as follows
            When in ‘large’ mode, views a sequence of n integers as n/2 pairs;

For each pair, exchanges the values, if necessary to have the larger value first

e.g  if a[4]= 15 and a[42]= 56 are ‘paired’, a[4] and a[42] are swapped

and a[45]= 111 and a[83]= 36 are ‘paired’, they are not swapped

    When in ‘small’ mode, views a sequence of n integers as n/2 pairs;

For each pair, exchanges the values, if necessary to have the smaller value first

e.g  if a[4]= 15 and a[42]= 56 are ‘paired’, they are not swapped

and a[45]= 111 and a[83]= 36 are ‘paired’, a[45] and a[83] are swapped

    each dataMod object is-a dataFilter and thus operates like an dataFilter object, except that:
        filter() increments each value returned when in ‘large’ mode; otherwise, decrements
        scramble(seq) replaces all prime numbers with ‘2’ before scrambling
    each dataCut object is-a dataFilter and thus operates like an dataFilter object, except that:
        filter() removes the maximum number when in ‘large’ mode; otherwise, removes the minimum
        scramble(seq) removes any number that occurred in the previous scramble request before scrambling
    Client’s sequences acquired via Dependency Injection so design should include error processing.

 

Many details are missing.   You MUST make and DOCUMENT your design decisions!!

Do NOT tie your type definition to the Console.

 

Use Unit Testing to verify functionality of each class => 3 test files.  

 

Part II: Driver  (P3.cs) -- External Perspective of Client – tests inheritance hierarchy design

The P3 driver must test the use of all 3 types together. 

Thus, the driver will differ from the unit tests which test each type separately. 

Additionally: 

    Use at least one heterogeneous collection for testing collective functionality
    Instantiate a variety of objects
    Trigger a variety of mode changes
