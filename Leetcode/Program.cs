// var solution = new Solution();

#region Solution 48
// solution.Rotate(matrix: [[1, 2, 3], [4, 5, 6], [7, 8, 9]]);

// solution.Rotate(matrix:
// [
//     [5,  1,  9,  11],
//     [2,  4,  8,  10],
//     [13, 3,  6,  7],
//     [15, 14, 12, 16]
// ]);
#endregion

#region Solution 1770
// var result = solution.MaximumScore(nums: [1, 2, 3], multipliers: [3, 2, 1]);
#endregion

#region Solution 547
// var result = solution.FindCircleNum(isConnected:
// [
//     [1, 1, 1, 0, 1, 1, 1, 0, 0, 0],
//     [1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
//     [1, 0, 1, 0, 0, 0, 0, 0, 0, 0],
//     [0, 0, 0, 1, 1, 0, 0, 0, 1, 0],
//     [1, 0, 0, 1, 1, 0, 0, 0, 0, 0],
//     [1, 0, 0, 0, 0, 1, 0, 0, 0, 0],
//     [1, 0, 0, 0, 0, 0, 1, 0, 1, 0],
//     [0, 1, 0, 0, 0, 0, 0, 1, 0, 1],
//     [0, 0, 0, 1, 0, 0, 1, 0, 1, 1],
//     [0, 0, 0, 0, 0, 0, 0, 1, 1, 1]
// ]);
#endregion

#region Solution 37
// solution.SolveSudoku(board:
//     [
//         ['5','3','.','.','7','.','.','.','.'],
//         ['6','.','.','1','9','5','.','.','.'],
//         ['.','9','8','.','.','.','.','6','.'],
//         ['8','.','.','.','6','.','.','.','3'],
//         ['4','.','.','8','.','3','.','.','1'],
//         ['7','.','.','.','2','.','.','.','6'],
//         ['.','6','.','.','.','.','2','8','.'],
//         ['.','.','.','4','1','9','.','.','5'],
//         ['.','.','.','.','8','.','.','7','9']
//     ]);
#endregion

#region Solution 36
// solution.IsValidSudoku(
//     [['.','.','4', '.','.','.', '6','3','.'],
//      ['.','.','.', '.','.','.', '.','.','.'],
//      ['5','.','.', '.','.','.', '.','9','.'],
//
//      ['.','.','.', '5','6','.', '.','.','.'],
//      ['4','.','3', '.','.','.', '.','.','1'],
//      ['.','.','.', '7','.','.', '.','.','.'],
//
//      ['.','.','.', '5','.','.', '.','.','.'],
//      ['.','.','.', '.','.','.', '.','.','.'],
//      ['.','.','.', '.','.','.', '.','.','.']
//     ]);
#endregion

#region Solution 211
// var wordDictionary = new WordDictionary();
// wordDictionary.AddWord("bad");
// wordDictionary.AddWord("dad");
// wordDictionary.AddWord("mad");
// var result1 = wordDictionary.Search("pad"); // return False
// var result2 = wordDictionary.Search("bad"); // return True
// var result3 = wordDictionary.Search(".ad"); // return True
// var result4 = wordDictionary.Search("b.."); // return True
#endregion

#region Solution 208
// var trie = new Trie();
// trie.Insert("apple");
// var res1 = trie.Search("apple");   // return True
// var res2 = trie.Search("app");     // return False
// var res3 = trie.StartsWith("app"); // return True
// trie.Insert("app");
// var res4 = trie.Search("app");     // return True
#endregion

#region Solution 155
// var stack = new MinStack();
// stack.Push(-2);
// stack.Push(0);
// stack.Push(-3);
// var min1 = stack.GetMin();
// stack.Pop();
// var top = stack.Top();
// var min2 = stack.GetMin();
#endregion

#region Solution 622
// MyCircularQueue obj = new MyCircularQueue(6);
// var param_1 = obj.EnQueue(6);
// var param_2 = obj.Rear();
// var param_3 = obj.Rear();
// var param_4 = obj.DeQueue();
// var param_5 = obj.EnQueue(5); // дб true
// var param_6 = obj.EnQueue(5);
#endregion

#region Solution 450
// var root = new Solution.TreeNode(
//     val: 5,
//     left: new Solution.TreeNode(
//         val: 3,
//         left: new Solution.TreeNode(2),
//         right: new Solution.TreeNode(4)),
//     right: new Solution.TreeNode(
//         val: 6,
//         left: null,
//         right: new Solution.TreeNode(7)));
//
// var result = solution.DeleteNode(root, key: 7);
#endregion

#region Solution 652
// solution.FindDuplicateSubtrees(
//     new TreeNode(1,
//         new TreeNode(2,
//             new TreeNode(4, null, null),
//             null),
//         new TreeNode(3,
//             new TreeNode(2,
//                 new TreeNode(4, null, null),
//                 null),
//             new TreeNode(4, null, null))));
#endregion

#region Solution 705
// var myHashSet = new MyHashSet();
// myHashSet.Add(1);
// myHashSet.Add(2);
// var result1 = myHashSet.Contains(1);
// var result2 = myHashSet.Contains(3);
// myHashSet.Add(2);
// var result3 = myHashSet.Contains(2);
// myHashSet.Remove(2);
// var result4 = myHashSet.Contains(2);
//
// myHashSet.Add(0);
// var result5 = myHashSet.Contains(0);
// myHashSet.Add(1000000);
// var result6 = myHashSet.Contains(1000000);
// myHashSet.Add(33003);
// var result7 = myHashSet.Contains(33003);
#endregion

#region Solution 206
// solution.ReverseList(
//     new Solution.ListNode(1,
//         new Solution.ListNode(2,
//             new Solution.ListNode(3,
//                 new Solution.ListNode(4,
//                     new Solution.ListNode(5))))));
#endregion

#region Solution 147
// var listNode3 = new Solution.ListNode(3);
// var listNode2 = new Solution.ListNode(1, listNode3);
// var listNode1 = new Solution.ListNode(2, listNode2);
// var listNode0 = new Solution.ListNode(4, listNode1);
// var result = solution.InsertionSortList(listNode0);
#endregion

#region Solution 54
// int[][] array1 =
// {
//     new [] { 1, 2, 3 },
//     new [] { 4, 5, 6 },
//     new [] { 7, 8, 9 }
// };
// var result1 = solution.SpiralOrder(array1);

// // [[1,2,3,4], [5,6,7,8], [9,10,11,12], [13,14,15,16], [17,18,19,20], [21,22,23,24]]
// int[][] array2 =
// {
//     new [] { 1, 2, 3, 4 },
//     new [] { 5, 6, 7, 8 },
//     new [] { 9, 10, 11, 12 },
//     new [] { 13, 14, 15, 16 },
//     new [] { 17, 18, 19, 20 },
//     new [] { 21, 22, 23, 24 }
// };
// // required output: [1,2,3,4,8,12,16,20,24,23,22,21,17,13,9,5,6,7,11,15,19,18,14,10]
// var result2 = solution.SpiralOrder(array2);
#endregion
