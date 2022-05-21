using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace agartha
{
    public class PatternManager {

        public Core core;

        public int[] index;
        public Texture2D[][] table;

        public void initialize(Core core) {

            this.core = core;

            index = new int[2];
            index[0] = 1;
            index[1] = 0;

            table = new Texture2D[2][];
            table[0] = new Texture2D[256];
            table[1] = new Texture2D[256];

        return; }

        public void add(int id, String name) {

            int index = this.index[id];
            Texture2D[] table = this.table[id];

            table[index] = core.Content.Load<Texture2D>(name);
            this.index[id]++;

        return; }

        public void load() {

            for (int count = 1; count < 103; count++)
                add(0, "sprite-"+count.ToString("D4"));

            for (int count = 0; count < 51; count++)
                add(1, "tile-"+count.ToString("D4"));

        return; }

    }
}
