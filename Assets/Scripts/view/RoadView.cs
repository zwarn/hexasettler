using System.Collections.Generic;
using model.map;
using model.position;
using UnityEngine;

namespace view
{
    public class RoadView : MonoBehaviour {

        private Road _road;

        public GameObject roadE;
        public GameObject roadSE;
        public GameObject roadSW;
        public GameObject roadW;
        public GameObject roadNW;
        public GameObject roadNE;

        public void UpdateView(Dictionary<BaseDirection, Road> neighboRoads)
        {
            roadE.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.East] != null;
            roadSE.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.SouthEast] != null;
            roadSW.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.SouthWest] != null;
            roadW.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.West] != null;
            roadNW.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.NorthWest] != null;
            roadNE.GetComponent<SpriteRenderer>().enabled = neighboRoads[BaseDirection.NorthEast] != null;
        }
    }
}
