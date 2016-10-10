using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    class BTree
    {
        private Node stRoot;
        private uint uCount;

        public BTree()
        { 
            stRoot = null;
            uCount = 0;
        }

        public Node stGetRoot()
        {
            return stRoot;
        }

        public void vInsertData(Node stData)
        {
            Node stNewNode = new Node();
            stNewNode      = stData;

            if (stRoot == null)
            {
                stRoot = stNewNode;
            }
            else
            {
                Node stCurrent = stRoot;
                Node stParent;

                while (true)
                {
                    stParent = stCurrent;
                    if (stData.uGetID() < stCurrent.uGetID())
                    {
                        stCurrent = stCurrent.pLeft;
                        if (stCurrent == null)
                        {
                            stParent.pLeft = stNewNode;
                            return;
                        }
                    }
                    else
                    {
                        stCurrent = stCurrent.pRight;
                        if (stCurrent == null)
                        {
                            stParent.pRight = stNewNode;
                            return;
                        }
                    }
                }
            }

            uCount++;
        }

        public Node stGetNode(uint uNodeID)
        {
            Node stCurrent = stRoot;

            while (stCurrent != null)
            {
                if (stCurrent.uGetID() == uNodeID)
                {
                    return stCurrent;
                }
                else if (stCurrent.uGetID() < uNodeID)
                {
                    stCurrent = stCurrent.pRight;
                }
                else if (stCurrent.uGetID() > uNodeID)
                {
                    stCurrent = stCurrent.pLeft;
                }
            }

            return null;
        }

        public void vPrintInorder(Node stRoot)
        {
            if (stRoot != null)
            {
                vPrintInorder(stRoot.pLeft);
                Console.Write(stRoot.uGetID() + " ");
                vPrintInorder(stRoot.pRight);
            }
        }
    }
}
