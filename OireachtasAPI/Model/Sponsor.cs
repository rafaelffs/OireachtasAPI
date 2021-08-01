using Newtonsoft.Json;

public class SponsorBase
{
    [JsonProperty("sponsor")]
    public Sponsor Sponsor { get; set; }
}
public class Sponsor
{
    [JsonProperty("by")]
    public By By{ get; set; }
}