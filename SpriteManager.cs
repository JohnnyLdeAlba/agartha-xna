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

    public class _spritetable {

        public int state;

        public int pattern_id;
        public int x, y;
        
        public _spritetable() {

            state = 0;

            pattern_id = 0;
            x = 0; y = 0;

        return; }
    }

    public class SpriteManager {

        public Core core;
        public Texture2D[] pattern_table;

        public int index;
        public _spritetable[] table;
        
        public void initialize(Core core) {

            this.core = core;
            pattern_table = core.pattern_manager.table[0];

            index = 0;
            table = new _spritetable[128];

            for (int count = 0; count < 128; count++)
                table[count] = new _spritetable();

        return; }

        public void reset() {

            index = 0;

            for (int count = 0; count < 128; count++) {

                table[count].state = 0;
                table[count].x = 0;
                table[count].y = 0;
                
            table[count].pattern_id = 0; }

        return; }

        public void generate_next_id() {
            
            if (index >= 128) return;
            if (table[index].state == 0) return;

            index++;

        return; }

        public void add(int pattern_id, int x, int y) {

            if ((x > 255) || (y > 255)) return;
            if ((x < -32) || (y < -32)) return;

            table[index].state = 1;
            table[index].pattern_id = pattern_id;

            table[index].x = x;
            table[index].y = y;

            generate_next_id();

        return; }

        public void draw() {

            int count = 0;

            int pattern_id = 0;
            Vector2 position = new Vector2(0, 0);

            while (table[count].state > 0) {
 
                pattern_id = table[count].pattern_id;
                
                position.X = table[count].x;
                position.Y = table[count].y;

                core.display_manager.sprite_batch.Draw(pattern_table[pattern_id],
                    position, Color.White);

            count++; }

        return; }
    }
}
