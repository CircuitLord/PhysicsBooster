using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace PhysicsBooster {

	public class PhysicsBoosterMod : MelonMod {

		private const string PREF_CATAGORY = "PhysicsBooster";

		private const string PREF_PHYSICS_FPS = "PhysicsFPS";

		private int targetPhysicsFPS = 144;
		private float targetPhysicsTick = 0.006944f;

		public override void OnApplicationStart() {
			base.OnApplicationStart();

			MelonPreferences.Load();
			
			MelonPreferences.CreateCategory(PREF_CATAGORY, "Settings");

			MelonPreferences.CreateEntry(PREF_CATAGORY, PREF_PHYSICS_FPS, 144, "Physics FPS");

			targetPhysicsFPS = MelonPreferences.GetEntryValue<int>(PREF_CATAGORY, PREF_PHYSICS_FPS);
			targetPhysicsTick = 1f / targetPhysicsFPS;
			
			MelonPreferences.Save();

			MelonLogger.Msg("Physics booster init... Target framerate is " + targetPhysicsFPS + ". Target physics tick is " + targetPhysicsTick.ToString("F4"));

			Time.fixedDeltaTime = targetPhysicsTick;
			
		}
		
		public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
			base.OnSceneWasLoaded(buildIndex, sceneName);
			
			Time.fixedDeltaTime = targetPhysicsTick;
		}

	}

}