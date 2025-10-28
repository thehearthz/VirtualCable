using MediaBrowser.Model.Plugins;
using System.Collections.Generic;
using VirtualCable.Models;

namespace VirtualCable
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public List<ChannelDefinition> Channels { get; set; } = new();
        public int DefaultCommercialIntervalMinutes { get; set; } = 20;
    }
}