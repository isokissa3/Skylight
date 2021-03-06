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
    class NewItemAddedMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            List<uint> newFloorItems = valueHolder.GetValueOrDefault<List<uint>>("Floors");
            List<uint> newWallItems = valueHolder.GetValueOrDefault<List<uint>>("Walls");
            List<uint> newPets = valueHolder.GetValueOrDefault<List<uint>>("Pets");
 
            ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
            message.Init(r63aOutgoing.NewItemAdded);
            int amount_ = 0;
            if (newFloorItems.Count > 0 | newWallItems.Count > 0 | newPets.Count > 0)
            {
                amount_++;
            }
            message.AppendInt32(amount_);

            if (newFloorItems.Count > 0)
            {
                message.AppendInt32(1);
                message.AppendInt32(newFloorItems.Count);
                foreach (uint itemId_ in newFloorItems)
                {
                    message.AppendUInt(itemId_);
                }
            }

            if (newWallItems.Count > 0)
            {
                message.AppendInt32(2);
                message.AppendInt32(newWallItems.Count);
                foreach (uint itemId_ in newWallItems)
                {
                    message.AppendUInt(itemId_);
                }
            }

            if (newPets.Count > 0)
            {
                message.AppendInt32(3);
                message.AppendInt32(newPets.Count);
                foreach (uint petId in newPets)
                {
                    message.AppendUInt(petId);
                }
            }
            return message;
        }
    }
}
