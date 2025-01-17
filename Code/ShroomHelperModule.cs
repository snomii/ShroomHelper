﻿using Celeste.Mod.ShroomHelper.Effects;
using Celeste.Mod.ShroomHelper.Entities;
using Monocle;
using System;

namespace Celeste.Mod.ShroomHelper {
    public class ShroomHelperModule : EverestModule {
        public static ShroomHelperModule Instance;
        public static SpriteBank spriteBank;

        public ShroomHelperModule() {
            Instance = this;
        }

        public override Type SessionType => typeof(ShroomHelperSession);
        public static ShroomHelperSession Session => (ShroomHelperSession)Instance._Session;

        public override void Load() {
            DoubleRefillBooster.Load();
            OneDashWingedStrawberry.Load();
            Everest.Events.Level.OnLoadBackdrop += Level_OnLoadBackdrop;
        }

        public override void Unload() {
            DoubleRefillBooster.Unload();
            OneDashWingedStrawberry.Unload();
            Everest.Events.Level.OnLoadBackdrop -= Level_OnLoadBackdrop;
        }

        public override void LoadContent(bool firstLoad) {
            base.LoadContent(firstLoad);
            spriteBank = new SpriteBank(GFX.Game, "Graphics/ShroomHelper/Sprites.xml");
        }

        private Backdrop Level_OnLoadBackdrop(MapData map, BinaryPacker.Element child, BinaryPacker.Element above) {
            if (child.Name.Equals("ShroomHelper/ShroomPetals", StringComparison.OrdinalIgnoreCase)) {
                ShroomPetals shroomPetals = new();
                if (child.HasAttr("color")) {
                    shroomPetals.shroomColor = child.Attr("color");
                }

                return shroomPetals;
            }

            return null;
        }
    }
}