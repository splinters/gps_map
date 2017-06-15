using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gmap_Map
{
    class RouteClass
    {
        public class Hints
        {
            public string visited_nodes_average { get; set; }
            public string visited_nodes_sum { get; set; }
        }

        public class Instruction
        {
            public double distance { get; set; }
            public int sign { get; set; }
            public List<int> interval { get; set; }
            public string text { get; set; }
            public int time { get; set; }
            public string street_name { get; set; }
            public int exit_number { get; set; }
            public bool exited { get; set; }
        }

        public class Points
        {
            public List<List<double>> coordinates { get; set; }
            public string type { get; set; }
        }

        public class SnappedWaypoints
        {
            public List<List<double>> coordinates { get; set; }
            public string type { get; set; }
        }

        public class Path
        {
            public List<Instruction> instructions { get; set; }
            public int descend { get; set; }
            public int ascend { get; set; }
            public double distance { get; set; }
            public List<double> bbox { get; set; }
            public double weight { get; set; }
            public int time { get; set; }
            public bool points_encoded { get; set; }
            public Points points { get; set; }
            public SnappedWaypoints snapped_waypoints { get; set; }
        }

        public class Info
        {
            public int took { get; set; }
            public List<string> copyrights { get; set; }
        }

        public class RootObject
        {
            public Hints hints { get; set; }
            public List<Path> paths { get; set; }
            public Info info { get; set; }
        }
    }
}
