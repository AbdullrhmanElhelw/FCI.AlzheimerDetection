namespace FCI.AlzheimerDetection.DAL.Settings.TokenSettings;

public class JWTSetting
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audicne { get; set; }

    public int DurationInMinutes { get; set; }
}