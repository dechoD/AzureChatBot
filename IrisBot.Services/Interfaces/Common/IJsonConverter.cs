namespace IrisBot.Services.Interfaces.Common
{
    public interface IJsonConverter
    {
        TDestinationType DeserializeObject<TDestinationType>(string json);
    }
}
