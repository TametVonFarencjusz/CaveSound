using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;

using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Default;
using Terraria.ModLoader.Exceptions;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace CaveSound
{
	public class CavePlayer: ModPlayer
	{
		public int noiseTimer = 0;

		private void PlaySound()
		{
			switch(Main.rand.Next(21))
			{
				//case 0: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave1"), player.position); break;
				case 0: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave2"), player.position); break;
				case 1: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave2B"), player.position); break;
				case 2: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave3"), player.position); break;
				case 3: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave4"), player.position); break;			
				case 4: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave5"), player.position); break;
				case 5: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave6"), player.position); break;
				case 6: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave7"), player.position); break;
				//case 7: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave8"), player.position); break; //ERROR
				case 7: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave10A"), player.position); break;
				case 8: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave9"), player.position); break;
				case 9: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave10"), player.position); break;
				case 10: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave11"), player.position); break;
				case 11: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave12"), player.position); break;
				case 12: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave13"), player.position); break;
				
				case 13: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto1"), player.position); break;
				case 14: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto2"), player.position); break;
				case 15: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto3"), player.position); break;
				case 16: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto4"), player.position); break;
				case 17: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto5"), player.position); break;
				case 18: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto6"), player.position); break;
				case 19: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/grotto7"), player.position); break;
				
				default: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/cave13A"), player.position); break;
			}
			  //Don't work online and I don't know why (PreUpdate don't sync sounds?)
		}

        public override void PreUpdate()
        {		
			//Underground
			if (player.position.Y/16 > Main.worldSurface && player.position.Y/16 <= Main.rockLayer)
			{
				noiseTimer += Main.rand.Next(2);
				if (noiseTimer >= 1800)
				{
					PlaySound();
					noiseTimer = 0;
				}
			}	
			//Cave
			if (player.position.Y/16 > Main.rockLayer && player.position.Y/16 <= Main.maxTilesY - 190)
			{
				noiseTimer += Main.rand.Next(2);
				if (noiseTimer >= 600)
				{
					PlaySound();
					noiseTimer = 0;
				}
			}	
			//Hell
			if (player.position.Y/16 > Main.maxTilesY - 190)
			{
				noiseTimer += Main.rand.Next(2);
				if (noiseTimer >= 1200)
				{
					PlaySound();
					noiseTimer = 0;
				}
			}	

			base.PreUpdate();			
		}
	}
}