namespace VirtualCable.Models
{
    public class ChannelDefinition
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public bool AutoGenerate { get; set; }
        public bool Shuffle { get; set; }
        public bool RespectEpisodeOrder { get; set; }
        public int CommercialIntervalMinutes { get; set; }
    }
}