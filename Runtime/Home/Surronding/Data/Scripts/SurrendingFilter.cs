namespace Surronding.SharedTypes
{
    public class SurrendingFilter
    {
        public WalkingDistanceType[] Distances { get; private set; } = new WalkingDistanceType[0];
        //public MapGuideType[] MapGuides { get; private set; } = new MapGuideType[0];

        public SurrendingFilter UpdateDistances(WalkingDistanceType[] distances)
        {
            Distances = distances;
            return this;
        }

        //public SurrendingFilter UpdateMapGuide(MapGuideType[] mapGuides)
        //{
        //    MapGuides = mapGuides;
        //    return this;
        //}

        public bool IsDistanceCountins(WalkingDistanceType value)
        {
            for (int i = 0; i < Distances.Length; i++)
                if (Distances[i] == value)
                    return true;

            return false;
        }

        //public bool IsMapGuideCountins(MapGuideType value)
        //{
        //    return true;
        //    for (int i = 0; i < MapGuides.Length; i++)
        //        if (MapGuides[i] == value)
        //            return true;

        //    return false;
        //}
    }
}