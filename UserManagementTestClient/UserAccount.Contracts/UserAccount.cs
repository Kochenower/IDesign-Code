using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UserAccount.Contracts
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public List<string> Password { get; set; }

        [DataMember]
        public UserSecurityLevel UserSecurityLevel { get; set; }

        [DataMember]
        public int LoginAttempts { get; set; }

        [DataMember]
        public bool IsLocked { get; set; }

        [DataMember]
        public DateTime PasswordLastChangedDate { get; set; }
    }

    public enum UserSecurityLevel
    {
        Administrator = 0,
        Standard = 1
    }
}
