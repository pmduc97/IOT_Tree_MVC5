using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOT_Tree_MVC5.Models
{
    public class TreeLite
    {
        private string cayXanh;
        private double lat;
        private double lng;

        public TreeLite(string cayXanh, double lat, double lng)
        {
            this.cayXanh = cayXanh;
            this.lat = lat;
            this.lng = lng;
        }

        public string CayXanh
        {
            get
            {
                return cayXanh;
            }

            set
            {
                cayXanh = value;
            }
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