﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.Catalog;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.HabboHotel.Items;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class IsOfferGiftableMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            uint itemId = message.PopWiredUInt();
            CatalogItem item = Skylight.GetGame().GetCatalogManager().GetItemByID(itemId);
            if (item != null)
            {
                ServerMessage message_ = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
                message_.Init(r63aOutgoing.OfferIsGiftable);
                message_.AppendUInt(itemId);

                bool allowGift = true;
                foreach(Tuple<Item, int> data in item.GetItems())
                {
                    if (!data.Item1.AllowGift)
                    {
                        allowGift = false;
                        break;
                    }
                }

                message_.AppendBoolean(allowGift);
                session.SendMessage(message_);
            }
        }
    }
}
