using System.Runtime.Serialization;

namespace UserAccount.Contracts
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public string Activity { get; set; }

        [DataMember]
        public bool IsSuccessful { get; set; }
       
        [DataMember]
        public string Reason { get; set; }

        [IgnoreDataMember]
        public Account Account { get; set; }
    }
}
