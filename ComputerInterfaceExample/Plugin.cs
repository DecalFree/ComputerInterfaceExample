using System;
using BepInEx;

namespace ComputerInterfaceExample;

[BepInDependency("tonimacaroni.computerinterface", "1.8.0")]
[BepInPlugin(Constants.Guid, Constants.Name, Constants.Version)]
public class Plugin : BaseUnityPlugin {
    public Plugin() {
        GorillaTagger.OnPlayerSpawned(delegate {
            try {
                // Calls the 'Initialize' method in ExampleCommandManager.
                new ExampleCommandManager().Initialize();
            }
            catch (Exception exception) {
                Logger.LogError($"Failed to load {Constants.Name}: {exception}");
            }
        });
    }
}