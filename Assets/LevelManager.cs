using FIMSpace.Generating.PathFind;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif  
using UnityEngine;

namespace FIMSpace.Generating
{
    public class LevelManager : PGGPlanGeneratorBase
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            base.GenerateObjects();
        }
    }
}

