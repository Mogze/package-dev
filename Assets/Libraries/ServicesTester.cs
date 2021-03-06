using Mogze.Core.Services;
using Mogze.Audio;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class ServicesTester
{
    public ServicesTester(Transform parent, AudioDictionary audioDictionary)
    {
        var testService = new TestService();
        var testService2 = new TestService2();

        Services.AddService<TestService>(testService);
        Services.AddService<TestService2>(testService2);
        Services.AddService<AudioService>(new AudioService(parent, audioDictionary));

        Services.Initialize();
    }

    class TestService : IService
    {
        public async Task Initialize()
        {
            Debug.Log($"Test Service initializing {DateTime.Now}");
            await Task.Delay(1000);
            Debug.Log($"Test Service Initialized {DateTime.Now}");
        }

        public void Pause(bool isPaused)
        {

        }

        public void Close()
        {
            Debug.Log("Test Service closed");
        }
    }

    class TestService2 : IService
    {
        public async Task Initialize()
        {
            Debug.Log($"Test Service 2 Initializing {DateTime.Now}");
            await Task.Delay(2000);
            Debug.Log($"Test Service 2 Initialized {DateTime.Now}");
        }

        public void Pause(bool isPaused)
        {

        }

        public void Close()
        {

        }
    }
}