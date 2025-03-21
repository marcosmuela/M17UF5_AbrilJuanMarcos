/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using Oculus.Interaction.Throw;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.BuildingBlocks.Editor;

namespace Oculus.Interaction.Editor.BuildingBlocks
{
    public class OVRHandPhysicsBlockData : BlockData
    {
        protected override List<GameObject> InstallRoutine(GameObject selectedGameObject)
        {
            var handPhysicsBlocks = new List<GameObject>();
            foreach (var hand in BlocksUtils.GetHands())
            {
                var handPhysicsBlock = InstantiateHandPhysicsBlock(hand);
                var grabInteractor = hand.GetComponentInChildren<HandGrabInteractor>();
#pragma warning disable CS0618 // Type or member is obsolete
                grabInteractor.InjectOptionalVelocityCalculator(handPhysicsBlock.GetComponent<RANSACVelocityCalculator>());
#pragma warning restore CS0618 // Type or member is obsolete
                handPhysicsBlocks.Add(handPhysicsBlock);
            }
            return handPhysicsBlocks;
        }

        private GameObject InstantiateHandPhysicsBlock(Hand hand)
        {
            var handPhysicsBlock = Instantiate(Prefab, hand.transform, false);
            handPhysicsBlock.SetActive(true);
            handPhysicsBlock.name = $"[BuildingBlock] {hand.Handedness} Hand Physics";
            handPhysicsBlock.GetComponent<HandPoseInputDevice>().InjectHand(hand);
            BlocksUtils.UpdateForAutoWiring(handPhysicsBlock);
            return handPhysicsBlock;
        }
    }
}
