using System;
using BepInEx;

namespace ComputerInterfaceExample;

[BepInDependency("tonimacaroni.computerinterface", "2.0.0")]
[BepInPlugin(Constants.Guid, Constants.Name, Constants.Version)]
internal class Plugin : BaseUnityPlugin {
    public Plugin() {
        GorillaTagger.OnPlayerSpawned(delegate {
            try {
                // Other code for mod...
            }
            catch (Exception exception) {
                Logger.LogError($"Failed to load {Constants.Name}: {exception}");
            }
        });
    }
}