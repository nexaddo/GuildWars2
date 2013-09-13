﻿using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

using GuildWars2.ArenaNet.Model;
using GuildWars2.SyntaxError.Model;

namespace GuildWars2.ArenaNet.Mapper
{
    public class PointOfInterestPushpin : ImagePushpin
    {
        private static IDictionary<PointOfInterestType, BitmapImage> IMAGES = new Dictionary<PointOfInterestType, BitmapImage>() {
                { PointOfInterestType.Landmark, LoadImageResource("/Resources/poi.png") },
                { PointOfInterestType.Vista, LoadImageResource("/Resources/vista.png") },
                { PointOfInterestType.Waypoint, LoadImageResource("/Resources/waypoint.png") }
            };

        public PointOfInterestPushpin(PointOfInterest poi)
            : base()
        {
            if (IMAGES.ContainsKey(poi.TypeEnum))
                Image = IMAGES[poi.TypeEnum];

            if (!string.IsNullOrWhiteSpace(poi.Name))
            {
                ToolTip = poi.Name;

                PopupContent = new PopupContentFactory()
                        .AppendWikiLink(poi.Name)
                        .AppendChatCode(ChatCode.CreateMapLink((uint)poi.PoiId))
                        .GetContent();
            }
        }
    }
}
