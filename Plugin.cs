using MediaBrowser.Common.Plugins;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Model.Plugins;
using System.Collections.Generic;

namespace VirtualCable
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "VirtualCable";
        public override string Description => "Create virtual cable-style channels using your Jellyfin library.";

        public Plugin(IApplicationPaths appPaths, IXmlSerializer xmlSerializer)
            : base(appPaths, xmlSerializer)
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            yield return new PluginPageInfo
            {
                Name = "VirtualCable",
                EmbeddedResourcePath = GetType().Namespace + ".Web.virtualcable.html"
            };
        }
    }
}