﻿/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System.Collections.Generic;
using Mooege.Common.MPQ.FileFormats.Types;
using Mooege.Core.GS.Common.Types.Math;
using Mooege.Core.GS.Map;
using Mooege.Net.GS.Message;

namespace Mooege.Core.GS.Actors.Implementations.Artisans
{
    [HandledSNO(56949 /* PT_Jewler.acr */)]
    public class Jeweler : Artisan
    {
        public Jeweler(World world, int actorSNO, Vector3D position, Dictionary<int, TagMapEntry> tags)
            : base(world, actorSNO, position, tags)
        {
        }

        public void OnAddSocket(Player.Player player, Core.Common.Items.Item item)
        {
            // Animate Jeweler? Who knows. /fasbat
            item.Attributes[GameAttribute.Sockets] += 1;
            item.Attributes[GameAttribute.Sockets_Filled] = item.Attributes[GameAttribute.Sockets_Filled];
            item.Attributes.SendChangedMessage(player.InGameClient, item.DynamicID);
        }
    }
}
