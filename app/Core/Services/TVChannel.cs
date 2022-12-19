using AntDesign;

namespace app.Core.Services;
using app.Core.Model;
using System.Text.Json;

public struct AddChannelArgs
{
    public string Name;
    public string Description;
}
public class TVChannel
{
    MasterContext dbContext = new ();

    public void AddChannel(AddChannelArgs args)
    {
        var newTvChannel = new Tvchannel
        {
            Name = args.Name,
            Description = args.Description
        };

        dbContext.Add<Tvchannel>(newTvChannel);
    }
}