﻿using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Game.Simulation;
using Unity.Entities;

namespace DummyTrafficRemover
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(DummyTrafficRemover)}.{nameof(Mod)}")
            .SetShowsErrorsInUI(false);

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<TrafficSpawnerAISystem>().Enabled = false;
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
        }
    }
}