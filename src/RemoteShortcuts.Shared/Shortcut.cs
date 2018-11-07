using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RemoteShortcuts.Shared
{
    [DataContract]
    public class Shortcut
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid Id { get; set; }
        
        public Action<IKeyboardCommands> Command { get; set; }
    }
}
