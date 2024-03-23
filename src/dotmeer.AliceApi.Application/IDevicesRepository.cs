using dotmeer.AliceApi.Models;
using dotmeer.AliceApi.Models.Requests;
using System.Collections.Generic;

namespace dotmeer.AliceApi.Application;

public interface IDevicesRepository
{
    IList<Device> GetDevices(string[]? ids = null);

    IList<Device> UpdateDeviceState(List<SetUSerDevicesStateRequestItem> actions);
}