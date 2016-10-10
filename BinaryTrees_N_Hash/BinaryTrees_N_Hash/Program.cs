using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree  cTree = new BTree();
            Node[] cNode = new Node[10];

            for (int i = 0; i < 9; i++)
            {
                cNode[i] = new Node(i.ToString(), "TEST", "TEST");
                cTree.vInsertData(cNode[i]);
            }

            cTree.vPrintInorder(cTree.cGetRoot());
            Console.ReadKey();
        }
    }
}
