//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BowlingService.Business
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class turn
    {
        public turn()
        {
            this.throws = new HashSet<@throw>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Nullable<int> Player_id { get; set; }

        [DataMember]
        public Nullable<int> Game_id { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Created_at { get; set; }

        [DataMember]
        public Nullable<int> Score { get; set; }

        [DataMember]
        public virtual game game { get; set; }

        [DataMember]
        public virtual player player { get; set; }

        [DataMember]
        public virtual ICollection<@throw> throws { get; set; }
    }
}
