using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Wave
    {
        public GameManager.Dialog[] StartDialogue;
        public GameManager.Dialog[] EndDialogue;

        public MobSpawnEvent[] Mobs;
    }

    public class MobSpawnEvent
    {
        public GameObject EnemyPrefab;
        public int Num;
    }
}
