﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63a
{
    class UpdateActivityPointsSilenceMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            Dictionary<int, int> currnecy = valueHolder.GetValue<Dictionary<int, int>>("ActivityPoints");

            ServerMessage Message = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
            Message.Init(r63aOutgoing.UpdateActivityPointsSilence);
            Message.AppendInt32(currnecy.Count); //count
            foreach (KeyValuePair<int, int> data in currnecy)
            {
                Message.AppendInt32(data.Key); //id
                Message.AppendInt32(data.Value); //amount
            }
            return Message;
        }
    }
}
