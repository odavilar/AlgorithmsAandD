﻿using System;
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
        public string sLastName;
        public string sAddress;
        public string sPhone;
        public string sMobile;
    }

    /* Node Class */
    public class Node
    {
        /* Unique ID Generator */
        private static uint uUniqueID = 1U;

        /* Data Members */
        private uint     uID;
        public  uint     uHeight;
        public  Node     pLeft;
        public  Node     pRight;
        public  Node     pParent;
        private UserInfo stUserInfo;

        /* Functions */
        public Node()
        {
            pLeft   = null;
            pRight  = null;
            pParent = null;
            stUserInfo.sName     = "";
            stUserInfo.sLastName = "";
            stUserInfo.sAddress  = "";
            stUserInfo.sPhone    = "";
            stUserInfo.sMobile   = "";
        }

        public Node(string sName, string sLastName, string sAddress, string sPhone, string sMobile)
        {
            uID     = uGenerateID(sName, sLastName); ;
            pLeft   = null;
            pRight  = null;
            pParent = null;
            uHeight = 1;
            /* User Information */
            this.vSetName(sName);
            this.vSetLastName(sLastName);
            this.vSetAddress(sAddress);
            this.vSetPhone(sPhone);
            this.vSetMobile(sMobile);
        }

        ~Node()
        {

        }

        public uint   uGetID()
        {
            return this.uID;
        }

        public string sGetName()
        {
            return stUserInfo.sName;
        }

        public string sGetLastName()
        {
            return stUserInfo.sLastName;
        }

        public string sGetAddress()
        {
            return stUserInfo.sAddress;
        }

        public string sGetPhone()
        {
            return stUserInfo.sPhone;
        }

        public string sGetMobile()
        {
            return stUserInfo.sMobile;
        }

        public void   vSetName(string sName)
        {
            if (0 == this.uID)
            {
                this.uID = this.uGenerateID(sName, this.stUserInfo.sLastName);
            }

            this.stUserInfo.sName = (sName.Length <= 32) ? sName : sName.Substring(0, 32);
        }

        public void   vSetLastName(string sLastName)
        {
            if (0 == this.uID)
            {
                this.uID = this.uGenerateID(this.stUserInfo.sName, sLastName);
            }

            this.stUserInfo.sLastName = (sLastName.Length <= 32) ? sLastName : sLastName.Substring(0, 32);
        }

        public void   vSetPhone(string sPhone)
        {
            if (0 == this.uID)
            {
                this.uID = this.uGenerateID(this.stUserInfo.sName, this.stUserInfo.sLastName);
            }

            this.stUserInfo.sPhone = (sPhone.Length <= 12) ? sPhone : sPhone.Substring(0, 12);
        }

        public void   vSetMobile(string sMobile)
        {
            if (0 == this.uID)
            {
                this.uID = this.uGenerateID(this.stUserInfo.sName, this.stUserInfo.sLastName);
            }

            this.stUserInfo.sMobile = (sMobile.Length <= 12) ? sMobile : sMobile.Substring(0, 12);
        }

        public void   vSetAddress(string sAddress)
        {
            if (0 == this.uID)
            {
                this.uID = this.uGenerateID(this.stUserInfo.sName, this.stUserInfo.sLastName);
            }

            this.stUserInfo.sAddress = (sAddress.Length <= 64) ? sAddress : sAddress.Substring(0, 64);
        }

        public void   vCopyNodeInfo(Node cSource)
        {
            uID                  = cSource.uGetID();
            stUserInfo.sName     = cSource.sGetName();
            stUserInfo.sLastName = cSource.sGetLastName();
            stUserInfo.sAddress  = cSource.sGetAddress();
            stUserInfo.sPhone    = cSource.sGetPhone();
            stUserInfo.sMobile   = cSource.sGetMobile();
        }

        public uint   uGenerateID(string sName, string sLastName)
        {
            uint uID       = 0;
            char[] cArray = sName.ToCharArray(0, sName.Length);

            for (uint i = 0; i < sName.Length; i++)
            {
                uID += cArray[i] * i;
            }
            uID = uID << 16;

            cArray = sLastName.ToCharArray(0, sLastName.Length);
            for (int i = 0; i < sLastName.Length; i++)
            {
                uID += cArray[i];
            }
            return uID;
        }
    }
}
