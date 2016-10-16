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

        public Node  cGetRoot()
        {
            return cRoot;
        }

        public void  vInsertData(Node cData)
        {
            cRoot = this.cInsertNode(cRoot, cData);
            uCount++;
        }

        private Node cInsertNode(Node cCurrent, Node cInsert)
        {
            /* 1.  Perform the normal BST rotation */
            if (null == cCurrent)
            {
                Node cNewNode = new Node();
                cNewNode      = cInsert;
                return cNewNode;
            }

            if (cInsert.uGetID() < cCurrent.uGetID())
            {
                cInsert.pParent = cCurrent;
                cCurrent.pLeft  = cInsertNode(cCurrent.pLeft, cInsert);
            }
            else
            {
                cInsert.pParent = cCurrent;
                cCurrent.pRight = cInsertNode(cCurrent.pRight, cInsert);
            }

            /* 2. Update height of this ancestor cNode */
            this.vUpdateHeight(cCurrent);

            /* 3. Get the balance factor of this ancestor cNode to check whether this cNode became unbalanced */
            int iBalance = this.iGetBalanceFactor(cCurrent);

            /* If this node becomes unbalanced, then there are 4 cases */

            /* Left Left Case */
            if ((iBalance > 1) && (cInsert.uGetID() < cCurrent.pLeft.uGetID()))
            {
                return cRotateRight(cCurrent);
            }

            /* Right Right Case */
            if ((iBalance < -1) && (cInsert.uGetID() > cCurrent.pRight.uGetID()))
            {
                return cRotateLeft(cCurrent);
            }

            /* Left Right Case */
            if ((iBalance > 1) && (cInsert.uGetID() > cCurrent.pLeft.uGetID()))
            {
                cCurrent.pLeft = cRotateLeft(cCurrent.pLeft);
                return cRotateRight(cCurrent);
            }

            /* Right Left Case */
            if ((iBalance < -1) && (cInsert.uGetID() < cCurrent.pRight.uGetID()))
            {
                cCurrent.pRight = cRotateRight(cCurrent.pRight);
                return cRotateLeft(cCurrent);
            }

            /* Return the (unchanged) cNode pointer */
            return cCurrent;
        }

        public bool  bDeleteData(uint uIDToDelete)
        {
            bool bDeleted = false;

            cRoot = this.cDeleteNode(cRoot, uIDToDelete, ref bDeleted);
            uCount--;

            return bDeleted;
        }

        private Node cDeleteNode(Node cCurrent, uint uIDToDelete, ref bool rbDeleted)
        {
            /* 1: Perform a standard BST deletion */
            if (null == cCurrent)
            {
                return cCurrent;
            }
            /* If the uIDToDelete to be deleted is smaller than the cCurrent's uIDToDelete, then it lies in left subtree */
            if ( uIDToDelete < cCurrent.uGetID() )
            {
                cCurrent.pLeft = this.cDeleteNode(cCurrent.pLeft, uIDToDelete, ref rbDeleted);
            }
            /* If the uIDToDelete to be deleted is greater than the cCurrent's uIDToDelete, then it lies in right subtree */
            else if( uIDToDelete > cCurrent.uGetID())
            {
                cCurrent.pRight = this.cDeleteNode(cCurrent.pRight, uIDToDelete, ref rbDeleted);
            }
            /* If uIDToDelete is same as cCurrent's uIDToDelete, then This is the node to be deleted */
            else
            {
                /* Node with only one child or no child */
                if( (null == cCurrent.pLeft) || (null == cCurrent.pRight) )
                {
                    Node cTemp = (null != cCurrent.pLeft) ? cCurrent.pLeft : cCurrent.pRight;
 
                    /* No child case */
                    if(null == cTemp)
                    {
                        cTemp    = cCurrent;
                        cCurrent = null;
                    }
                    else /* One child case */
                    {
                        cCurrent = cTemp;
                    }
                }
                else
                {
                    /* Node with two children: Get the inorder successor (smallest in the right subtree) */
                    Node cTemp = this.cMinValueNode(cCurrent.pRight);
 
                    /* Copy the inorder successor's data to this node */
                    cCurrent.vCopyNodeInfo(cTemp);
 
                    /* Delete the inorder successor */
                    cCurrent.pRight = this.cDeleteNode(cCurrent.pRight, cTemp.uGetID(), ref rbDeleted);
                }
            }
 
            /* If the tree had only one node then return */
            if (null == cCurrent)
            {
                return cCurrent;
            }

            /* 2: Update height of the current Node */
            this.vUpdateHeight(cCurrent);
 
            /* 3: Get the balance factor of the node */
            int iBalance = this.iGetBalanceFactor(cCurrent);

            /* If this node becomes unbalanced, then there are 4 cases */

            /* Left Left Case */
            if ((iBalance > 1) && (this.iGetBalanceFactor(cCurrent.pLeft) >= 0))
            {
                return cRotateRight(cCurrent);
            }

            /* Left Right Case */
            if ((iBalance > 1) && (this.iGetBalanceFactor(cCurrent.pLeft) < 0))
            {
                cCurrent.pLeft = cRotateLeft(cCurrent.pLeft);
                return cRotateRight(cCurrent);
            }

            /* Right Right Case */
            if ((iBalance < -1) && (this.iGetBalanceFactor(cCurrent.pRight) <= 0))
            {
                return cRotateLeft(cCurrent);
            }

            /* Right Left Case */
            if ((iBalance < -1) && (this.iGetBalanceFactor(cCurrent.pRight) > 0))
            {
                cCurrent.pRight = cRotateRight(cCurrent.pRight);
                return cRotateLeft(cCurrent);
            }

            /* Return the (unchanged) cNode pointer */
            return cCurrent;
        }

        public Node  cGetNode(uint uNodeID)
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

        /* Get height of the tree */
        private uint uGetHeight(Node cNode)
        {
            return (cNode == null) ? 0 : cNode.uHeight;
        }

        private int  iGetBalanceFactor(Node cNode)
        {
            if (null == cNode)
            {
                return 0;
            }
            else
            {
                return (int)uGetHeight(cNode.pLeft) - (int)uGetHeight(cNode.pRight);
            }
        }

        private void vUpdateHeight(Node cNode)
        {
            uint uHeightLeft  = uGetHeight(cNode.pLeft);
            uint uHeightRight = uGetHeight(cNode.pRight);

            /* Get maximum of two integers */
            cNode.uHeight = ((uHeightLeft > uHeightRight) ? uHeightLeft : uHeightRight) + 1;
        }

        /* Right rotate subtree rooted with cNode */
        private Node cRotateRight(Node cNode)
        {
            Node cTempNode   = cNode.pLeft;

            /* Rotate */
            cNode.pLeft      = cTempNode.pRight;
            cTempNode.pRight = cNode;

            /* Update Parents */
            cTempNode.pParent        = cNode.pParent;
            cNode.pParent            = cTempNode;
            cTempNode.pRight.pParent = cNode;

            /* Update heights */
            vUpdateHeight(cNode);
            vUpdateHeight(cTempNode);

            return cTempNode;
        }

        /* Left rotate subtree rooted with cNode */
        private Node cRotateLeft(Node cNode)
        {
            Node cTempNode  = cNode.pRight;

            /* Rotate */
            cNode.pRight    = cTempNode.pLeft;
            cTempNode.pLeft = cNode;

            /* Update Parents */
            cTempNode.pParent       = cNode.pParent;
            cNode.pParent           = cTempNode;
            cTempNode.pLeft.pParent = cNode;

            /* Update heights */
            vUpdateHeight(cNode);
            vUpdateHeight(cTempNode);

            return cTempNode;
        }

        private Node cBalance(Node cNode)
        {
            vUpdateHeight(cNode);
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
