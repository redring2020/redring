using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RedRing.Model
{
    public class Cube : ObservableObject, I3DModel
    {
        public Point point { get; set; }

        private Geometry geometry;

        public Geometry Geometry
        {
            get
            {
                if (geometry == null)
                {
                    geometry = new Geometry(
                        new[]
                        {
                            point + new Vector(1, 1, 1),
                            point + new Vector(-1, 1, 1),
                            point + new Vector(-1, -1, 1),
                            point + new Vector(1, -1, 1),
                            point + new Vector(1, 1, -1),
                            point + new Vector(1, -1, -1),
                            point + new Vector(-1, -1, -1),
                            point + new Vector(-1, 1, -1),
                            point + new Vector(1, 1, -1),
                            point + new Vector(1, 1, 1),
                            point + new Vector(1, -1, 1),
                            point + new Vector(1, -1, -1),
                            point + new Vector(1, -1, -1),
                            point + new Vector(1, -1, 1),
                            point + new Vector(-1, -1, 1),
                            point + new Vector(-1, -1, -1),
                            point + new Vector(-1, -1, -1),
                            point + new Vector(-1, -1, 1),
                            point + new Vector(-1, 1, 1),
                            point + new Vector(-1, 1, -1),
                            point + new Vector(1, 1, 1),
                            point + new Vector(1, 1, -1),
                            point + new Vector(-1, 1, -1),
                            point + new Vector(-1, 1, 1),

                        },
                        new[]
                        {
                            Tuple.Create(4, 5, 6),
                            Tuple.Create(4, 6, 7),
                            Tuple.Create(0, 1, 2),
                            Tuple.Create(0, 2, 3),
                            Tuple.Create(8, 9, 10),
                            Tuple.Create(8, 10, 11),
                            Tuple.Create(12, 13, 14),
                            Tuple.Create(12, 14, 15),
                            Tuple.Create(16, 17, 18),
                            Tuple.Create(16, 18, 19),
                            Tuple.Create(20, 21, 22),
                            Tuple.Create(20, 22, 23),
                        });
                }
                return geometry;
            }
        }

        public Cube()
        {
            point = new Point(0, 0, 0);
            point.PropertyChanged +=
                (sender, e) =>
            {
                geometry = null;
            };
        }
    }
}
