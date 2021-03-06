﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r26
{
    class ShoutMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            ServerMessage Message = BasicUtilies.GetRevisionServerMessage(Revision.R26_20080915_0408_7984_61ccb5f8b8797a3aba62c1fa2ca80169);
            Message.Init(r26Outgoing.Shout);
            Message.AppendInt32(valueHolder.GetValue<int>("VirtualID"));
            Message.AppendString(valueHolder.GetValue<string>("Message"));
            return Message;
        }
    }
}
