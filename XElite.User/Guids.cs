// Guids.cs
// MUST match guids.h
using System;

namespace MicroSmadio.XElite.User
{
    static class GuidList
    {
        public const string guidUserPkgString = "4575842b-d4ee-46a4-9d2d-7fd63f04e5b4";
        public const string guidUserCmdSetString = "dbaf2cf8-e9d9-4f8e-b947-15922e292b30";
        public const string guidToolWindowPersistanceString = "fff1bd71-1017-4bcc-8697-86caa9073525";

        public static readonly Guid guidUserCmdSet = new Guid(guidUserCmdSetString);
    };
}