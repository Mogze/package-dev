using Mogze.Core.Services;
using UnityEngine;

public class ServicesTester
{
    public ServicesTester()
    {
        var testService = new TestService();

        Services.AddService<TestService>(testService);

        Services.Initialize();
    }

    class TestService : IService
    {
        public void Initialize()
        {
            Debug.Log("Test Service Initialized");
        }

        public void Close()
        {
            Debug.Log("Test Service closed");
        }
    }
}