using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    class BTree
    {
        private Node cRoot;
        private uint uCount;

        public BTree()
        { 
            cRoot = null;
            uCount = 0;
        }

        public Node cGetRoot()
        {
            return cRoot;
        }

        public void vInsertData(Node cData)
        {
            Node stNewNode = new Node();
            stNewNode      = cData;

            if (cRoot == null)
            {
                cRoot = stNewNode;
            }
            else
            {
                Node stCurrent = cRoot;
                Node stParent;

                while (true)
                {
                    stParent = stCurrent;
                    if (cData.uGetID() < stCurrent.uGetID())
                    {
                        stCurrent = stCurrent.pLeft;
                        if (stCurrent == null)
                        {
                            stNewNode.pParent = stParent;
                            stParent.pLeft    = stNewNode;
                            return;
                        }
                    }
                    else
                    {
                        stCurrent = stCurrent.pRight;
                        if (stCurrent == null)
                        {
                            stNewNode.pParent = stParent;
                            stParent.pRight   = stNewNode;
                            return;
                        }
                    }
                }
            }

            uCount++;
        }

        public bool bDeleteData(uint uIDToDelete)
        {
            Node cDelete = this.cGetNode(uIDToDelete);
            Node cParent_tmp;
            Node cChild_tmp;

            if (cDelete != null)
            {
                if ((cDelete.pLeft == null) && (cDelete.pRight == null))
                {
                    /* Leaf Node */
                    cParent_tmp = cDelete.pParent;
                    if (cDelete == cParent_tmp.pLeft)
                    {
                        cParent_tmp.pLeft = null;
                    }
                    else
                    {
                        cParent_tmp.pRight = null;
                    }
                }
                else if ((cDelete.pLeft == null) || (cDelete.pRight == null))
                {
                    /* Left or Right child */
                    cChild_tmp   = (cDelete.pLeft == null) ? cDelete.pRight : cDelete.pLeft;
                    cParent_tmp = cDelete.pParent;

                    if (cDelete == cParent_tmp.pLeft)
                    {
                        cParent_tmp.pLeft  = cChild_tmp;
                    }
                    else
                    {
                        cParent_tmp.pRight = cChild_tmp;
                    }
                }
                else if ((cDelete.pLeft != null) || (cDelete.pRight != null))
                {
                    /* Node with two children */
                    cChild_tmp = cMinValueNode(cDelete.pRight);

                    /* Copy the inorder successor's content to this node */
                    cDelete.vCopyNodeInfo(cChild_tmp);

                    /* Delete the inorder successor */
                    this.bDeleteData(cChild_tmp.uGetID());
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public Node cGetNode(uint uNodeID)
        {
            Node cCurrent = cRoot;

            while (cCurrent != null)
            {
                if (cCurrent.uGetID() == uNodeID)
                {
                    return cCurrent;
                }
                else if (cCurrent.uGetID() < uNodeID)
                {
                    cCurrent = cCurrent.pRight;
                }
                else if (cCurrent.uGetID() > uNodeID)
                {
                    cCurrent = cCurrent.pLeft;
                }
            }

            return null;
        }

        public  void vPrintInorder(Node cRoot)
        {
            if (cRoot != null)
            {
                vPrintInorder(cRoot.pLeft);
                Console.Write(cRoot.uGetID() + " ");
                vPrintInorder(cRoot.pRight);
            }
        }

        private Node cMinValueNode(Node cNode)
        {
            Node cCurrent = cNode;
 
            /* loop down to find the leftmost leaf */
            while (cCurrent.pLeft != null)
            {
                cCurrent = cCurrent.pLeft;
            }

            return cCurrent;
        }
 
    }
}
