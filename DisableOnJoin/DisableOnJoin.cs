﻿using System;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;

namespace DisableOnJoin
{
    [ApiVersion(2, 1)]
    public class DisableOnJoin : TerrariaPlugin
    {

        public override string Author => "Quinci";

        public override string Description => "Prevents some ssc exploits.";

        public override string Name => "DisableOnJoin";

        public override Version Version => new Version(1, 4, 2, 2);

        public DisableOnJoin(Main game) : base(game)
        {
            
        }

        public override void Initialize()
        {
            PlayerHooks.PlayerPostLogin += OnPlayerPostLoginAsync;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PlayerHooks.PlayerPostLogin -= OnPlayerPostLoginAsync;
            }
            base.Dispose(disposing);

        }

        private async void OnPlayerPostLoginAsync(PlayerPostLoginEventArgs args)
        {
            
            if (Main.ServerSideCharacter)
            {

                try
                {
                    args.Player.Disable(reason: "");
                    args.Player.SendData(PacketTypes.NpcTalk, "", 0);
                    for (int index = 0; index < 41; index++)
                    {
                        args.Player.SendData(PacketTypes.NpcShopItem, "", index, 0, 0, 0, 0);
                    }
                    args.Player.Disable(reason: "");
                    args.Player.SetBuff(149, 3600, true);
                    await Task.Delay(600);
                    args.Player.Disable(reason: "");
                    args.Player.SendData(PacketTypes.PlayerAnimation, "", 0, 0);
                    args.Player.SendServerCharacter();
                    args.Player.Spawn();
                    args.Player.SetBuff(149, 3600, true);
                    await Task.Delay(600);
                    args.Player.Disable(reason: "");
                    args.Player.SendData(PacketTypes.PlayerAnimation, "", 0, 0);
                    args.Player.SendServerCharacter();
                    args.Player.Spawn();
                    args.Player.SetBuff(149, 3600, true);
                    await Task.Delay(600);
                    args.Player.Disable(reason: "");
                    args.Player.SendData(PacketTypes.PlayerAnimation, "", 0, 0);
                    args.Player.SendServerCharacter();
                    args.Player.Spawn();
                    args.Player.SetBuff(149, 1000, true);

                }

                catch (Exception e)

                {
                    Console.WriteLine($"DisableOnJoin threw an exception: {e}");
                }
            }
        }
    }
}
