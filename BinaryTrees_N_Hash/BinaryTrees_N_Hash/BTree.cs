using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{
    public class BTree
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
                            break;
                        }
                    }
                    else
                    {
                        stCurrent = stCurrent.pRight;
                        if (stCurrent == null)
                        {
                            stNewNode.pParent = stParent;
                            stParent.pRight   = stNewNode;
                            break;
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
                    cParent_tmp  = cDelete.pParent;
                    /* Check if parent is root */
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


        private uint uGetHeight(Node cNode)
        {
            return (cNode == null) ? 0 : cNode.uHeight;
        }

        private int iGetBalanceFactor(Node cNode)
        {
            return (int)uGetHeight(cNode.pRight) - (int)uGetHeight(cNode.pLeft);
        }

        private void vFixHeight(Node cNode)
        {
            uint uHeightLeft = uGetHeight(cNode.pLeft);
            uint uHeightRight = uGetHeight(cNode.pRight);
            cNode.uHeight = ((uHeightLeft > uHeightRight) ? uHeightLeft : uHeightRight) + 1;
        }

        private Node cRotateRight(Node cNode)
        {
            Node cTempNode = cNode.pLeft;
            cNode.pLeft = cTempNode.pRight;
            cTempNode.pRight = cNode;
            vFixHeight(cNode);
            vFixHeight(cTempNode);
            return cTempNode;
        }

        private Node cRotateLeft(Node cNode)
        {
            Node cTempNode = cNode.pRight;
            cNode.pRight = cTempNode.pLeft;
            cTempNode.pLeft = cNode;
            vFixHeight(cNode);
            vFixHeight(cTempNode);
            return cTempNode;
        }

        private Node cBalance(Node cNode)
        {
            vFixHeight(cNode);
            if (iGetBalanceFactor(cNode) == 2)
            {
                if (iGetBalanceFactor(cNode.pRight) < 0)
                {
                    cNode.pRight = cRotateRight(cNode.pRight);
                }
                return cRotateLeft(cNode);
            }
            if (iGetBalanceFactor(cNode) == -2)
            {
                if (iGetBalanceFactor(cNode.pLeft) > 0)
                {
                    cNode.pLeft = cRotateLeft(cNode.pLeft);
                }
                return cRotateRight(cNode);
            }
            return cNode;
        }
 
    }
}
