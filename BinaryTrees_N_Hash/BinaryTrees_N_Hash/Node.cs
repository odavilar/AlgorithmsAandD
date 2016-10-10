using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees_N_Hash
{

    /* Structs */
    struct UserInfo
    {
        public string sName;
        public string sAddress;
        public string sPhone;
    }

    /* Node Class */
    class Node
    {
        /* Unique ID Generator */
        private static uint uUniqueID = 1U;

        /* Data Members */
        private uint     uID;
        public  Node     pLeft;
        public  Node     pRight;
        public  Node     pParent;
        private UserInfo stUserInfo;

        /* Functions */
        public Node()
        {
            pLeft  = null;
            pRight = null;
            stUserInfo.sName    = "";
            stUserInfo.sAddress = "";
            stUserInfo.sPhone   = "";
        }

        public Node(string sName, string sAddress, string sPhone)
        {
            uID    = uUniqueID++;
            pLeft  = null;
            pRight = null;
            stUserInfo.sName    = sName;
            stUserInfo.sAddress = sAddress;
            stUserInfo.sPhone   = sPhone;
        }

        ~Node()
        {

        }

        public uint   uGetID()
        {
            return uID;
        }

        public string sGetName()
        {
            return stUserInfo.sName;
        }

        public string sGetAddress()
        {
            return stUserInfo.sAddress;
        }

        public string sGetPhone()
        {
            return stUserInfo.sPhone;
        }

        public void vSetName(string sName)
        {
            if (0 == this.uID)
            {
                uID = uUniqueID++;
            }
            stUserInfo.sName = sName;
        }

        public void vSetPhone(string sPhone)
        {
            if (0 == this.uID)
            {
                uID = uUniqueID++;
            }
            stUserInfo.sPhone = sPhone;
        }

        public void vSetAddress(string sAddress)
        {
            if (0 == this.uID)
            {
                uID = uUniqueID++;
            }
            stUserInfo.sName = sAddress;
        }

        public void vCopyNodeInfo(Node cSource)
        {
            uID                 = cSource.uGetID();
            stUserInfo.sName    = cSource.sGetName();
            stUserInfo.sAddress = cSource.sGetAddress();
            stUserInfo.sPhone   = cSource.sGetPhone();
        }
    }
}
