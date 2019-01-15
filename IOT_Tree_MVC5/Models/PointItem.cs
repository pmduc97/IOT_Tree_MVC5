namespace IOT_Tree_MVC5.Models
{
    public class PointItem
    {
        private double lat;
        private double lng;

        public PointItem(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public double Lat
        {
            get
            {
                return lat;
            }

            set
            {
                lat = value;
            }
        }

        public double Lng
        {
            get
            {
                return lng;
            }

            set
            {
                lng = value;
            }
        }
    }
}